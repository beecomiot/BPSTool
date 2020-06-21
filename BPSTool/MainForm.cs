using BPSTool.BPSPacket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;

namespace BPSTool
{
    public partial class MainForm : Form
    {
        enum EnBPSParseStep
        {
            EN_BPS_PARSE_HEADER,
            EN_BPS_PARSE_VERSION,
            EN_BPS_PARSE_ADDR,
            EN_BPS_PARSE_RMN_LEN1,
            EN_BPS_PARSE_RMN_LEN2,
            EN_BPS_PARSE_DATA,
            EN_BPS_PARSE_CHKSUM,
        }

        private const string STR_COMM_ERR = "通信错误";
        private const string STR_NEWEST_VERSION = "已经是最新版本";
        private const string STR_NEW_VERSION_CHECK = "检测到新版：";
        private const string STR_BUTTON_CONNECT = "连接";
        private const string STR_BUTTON_DISCONNECT = "断开";
        private const string STR_TT_DEBUG_SEND = "仅支持16进制发送，例如“BB CC 00 01 00 01 00 02”";
        private const string STR_TT_DEBUG_ENABLE = "使能串口发送/接收调试";
        private const string STR_TT_BLE_NAME = "最长20字节";
        private const string STR_DEBUG_SEND_PREFIX = "发送→：";
        private const string STR_DEBUG_RECV_PREFIX = "接收←：";
        private const string STR_NOTE = "提示";
        private const string STR_MB_SETTING_NOT_NULL = "设置内容不可为空";

        public const uint BPSTOOL_VERSION_MAIN = 1;
        public const uint BPSTOOL_VERSION_SUB = 0;
        public const uint BPSTOOL_VERSION_PATCH = 1;

        public delegate void DelUpdateUI_VV();
        public delegate void DelUpdateUI_VL(ref List<Byte> msg);
        //public delegate void DelUartErrorUI_VV();


        private DelUpdateUI_VV DelUpdateChecker;
        private DelUpdateUI_VL DelUartRecv;
        private DelUpdateUI_VV DelUartError;

        private SerialErrorReceivedEventHandler serialErrorReceivedEvent;
        private SerialDataReceivedEventHandler serialDataReceivedEvent;


        private Updater UpdateChecker;
        private UartMng uartMng;

        private List<byte> RecvBuffer;
        private EnBPSParseStep enBPSParseStep;
        private int remainLength;



        public MainForm()
        {
            InitializeComponent();

            UpdateChecker = new Updater(this);
            DelUpdateChecker = new DelUpdateUI_VV(UpdateLabelCallback);

            if (UpdateChecker.EndFlag)
            {
                UpdateChecker.StartWebRequest(DelUpdateChecker);
            }
            linkLabelVersionUpdate.Text = "";

            /** append version info to title */
            this.Text += "-V" + BPSTOOL_VERSION_MAIN + "." + BPSTOOL_VERSION_SUB + "." + BPSTOOL_VERSION_PATCH;

            uartMng = new UartMng(this);
            DelUartRecv = new DelUpdateUI_VL(UartDataReceiedCallback);
            DelUartError = new DelUpdateUI_VV(UartErrorCallback);

            serialErrorReceivedEvent = new SerialErrorReceivedEventHandler(UartErrorReceivedCallback);
            uartMng.ErrorCallback(serialErrorReceivedEvent);
            serialDataReceivedEvent = new SerialDataReceivedEventHandler(UartDataeceivedCallback);
            uartMng.ReadCallback(serialDataReceivedEvent);

            RefreshUartList();
            if (comboBoxUart.Items.Count > 0)
            {
                comboBoxUart.SelectedIndex = 0;
            }

            /** TODO: need to move to uartMng */
            RecvBuffer = new List<byte>();
            HeadClear();
            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
            remainLength = 0;

            /** read configurature */
            try
            {
                //指定config文件读取
                string file = System.Windows.Forms.Application.ExecutablePath;
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);

                bool debug_checked = Boolean.Parse(config.AppSettings.Settings["debug_checked"].Value);
                String baudrate = config.AppSettings.Settings["baudrate"].Value;

                checkBoxDebugEnable.Checked = debug_checked;
                comboBoxBaudrate.Text = baudrate;
            }
            catch
            {

            }
        }


        private void printMsg(ref List<Byte> msgList, string prefix)
        {
            string msgSendPrint = prefix;
            foreach (byte b in msgList)
            {
                msgSendPrint += " " + b.ToString("X").PadLeft(2, '0');
            }
            textBoxDebugMsg.AppendText(msgSendPrint + "\r\n");
        }

        private void sendMsg(ref List<Byte> msgList)
        {
            if (msgList.Count > 0)
            {
                if(uartMng.write(msgList.ToArray()))
                {
                    if(checkBoxDebugEnable.Checked)
                    {
                        printMsg(ref msgList, STR_DEBUG_SEND_PREFIX);
                    }
                }
            }
        }

        private bool IsBPSChksumOK(ref List<byte> msg)
        {
            UInt16 len;
            int checksum;

            checksum = 0;
            for(int i = BpsUtils.BPSHeader.Length; i < msg.Count-1; i++)
            {
                checksum += (msg[i] & 0xFF);
            }

            return (checksum & 0xFF) == (msg[msg.Count-1] & 0xFF);
        }

        private void HeadClear()
        {
            RecvBuffer.Clear();
            RecvBuffer.Add(0);
        }

        private void UartErrorReceivedCallback(object sender, SerialErrorReceivedEventArgs e)
        {
            Console.WriteLine("error");
            BpsToolCallback(DelUartError);
        }

        private void UartDataeceivedCallback(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("data");
            byte[] buffer = new byte[uartMng.serialPort.BytesToRead];
            uartMng.serialPort.Read(buffer, 0, buffer.Length);
            List<byte> msg = new List<byte>(buffer);
            BpsToolCallback(DelUartRecv, ref msg);
        }

        private void RefreshUartList()
        {
            string currentPortTmp = null;
            if(comboBoxUart.Items.Count > 0)
            {
                currentPortTmp = (string)comboBoxUart.SelectedItem;
            }

            uartMng.RefreshPortList();
            comboBoxUart.Items.Clear();

            foreach (string port in uartMng.PortList)
            {
                comboBoxUart.Items.Add(port);
                if(null != currentPortTmp && port.Equals(currentPortTmp))
                {
                    comboBoxUart.SelectedIndex = comboBoxUart.Items.Count - 1;
                }
            }
        }

        public void BpsToolCallback(DelUpdateUI_VV del_vv)
        {
            try
            {
                BeginInvoke(del_vv);
            }
            catch
            {

            }
        }

        public void BpsToolCallback(DelUpdateUI_VL del_vl, ref List<Byte> l)
        {
            try
            {
                object[] args = new object[1];
                args[0] = l;
                BeginInvoke(del_vl, args);
            }
            catch
            {

            }
        }

        private void UpdateLabelCallback()
        {
            if(0 == UpdateChecker.LastestVersion.Trim().Length)
            {
                /** Communication error*/
                if (!UpdateChecker.LaunchCheckFlag)
                {
                    linkLabelVersionUpdate.LinkColor = Color.Red;
                    linkLabelVersionUpdate.Text = STR_COMM_ERR;
                    linkLabelVersionUpdate.Enabled = false;
                }
            }
            else
            {
                string lastestVersion = UpdateChecker.LastestVersion.Trim();
                Regex regex = new Regex(@"([0-9]+)\.([0-9]+)\.([0-9]+)");
                GroupCollection groups = regex.Match(lastestVersion).Groups;
                bool newVersionProbed = false;

                try
                {
                    do
                    {
                        uint verTemp = uint.Parse(groups[1].Value);
                        if (BPSTOOL_VERSION_MAIN < verTemp)
                        {
                            newVersionProbed = true;
                            break;
                        }
                        else if(BPSTOOL_VERSION_MAIN > verTemp)
                        {
                            break;
                        }

                        verTemp = uint.Parse(groups[2].Value);
                        if (BPSTOOL_VERSION_SUB < verTemp)
                        {
                            newVersionProbed = true;
                            break;
                        }
                        else if(BPSTOOL_VERSION_SUB > verTemp)
                        {
                            break;
                        }

                        verTemp = uint.Parse(groups[3].Value);
                        if (BPSTOOL_VERSION_PATCH < verTemp)
                        {
                            newVersionProbed = true;
                            break;
                        }
                        else if(BPSTOOL_VERSION_PATCH > verTemp)
                        {
                            break;
                        }

                    } while (false);
                }
                catch
                {
                    newVersionProbed = false;
                }

                if(newVersionProbed)
                {
                    linkLabelVersionUpdate.Text = STR_NEW_VERSION_CHECK + UpdateChecker.LastestVersion;
                    linkLabelVersionUpdate.LinkColor = Color.Blue;
                    linkLabelVersionUpdate.Enabled = true;
                }
                else
                {
                    if (!UpdateChecker.LaunchCheckFlag)
                    {
                        linkLabelVersionUpdate.Enabled = true;
                        linkLabelVersionUpdate.LinkColor = Color.Green;
                        linkLabelVersionUpdate.Text = STR_NEWEST_VERSION;
                    }
                }
            }

            if (UpdateChecker.LaunchCheckFlag)
            {
                UpdateChecker.LaunchCheckFlag = false;
                return;
            }

        }

        private void UIDoBPSPacket(ref BPSPacketCommTest bps)
        {
            // textBoxName.Text = "hello";
        }

        private void UIDoBPSPacket(ref BPSPacketBaudrate bps)
        {
            textBoxBaudrate.Text = bps.Baudrate.ToString();
        }

        private void UIDoBPSPacket(ref BPSPacketSysPara bps)
        {
            switch(bps.ParaId)
            {
                case BPSPacketSysPara.SysParaID.NAME:
                    if(bps.CmdTypeSysPara == BPSPacketSysPara.CmdType.READ)
                    {
                        textBoxName.Text = bps.ToString();
                    }
                    break;
            }
        }

        private void UIDoBPSPacket(ref BPSPacketReset bps)
        {
            // textBoxName.Text = "hello";
        }

        private void UIDoBPSPacket(ref BPSPacketRestoreFac bps)
        {
            // textBoxName.Text = "hello";
        }

        private void UartDataReceiedCallback(ref List<Byte> msg)
        {
            bool recvOK = false;
            for(int i = 0; i < msg.Count; i++)
            {
                byte dataTmp = msg[i];
                switch (enBPSParseStep)
                {
                    case EnBPSParseStep.EN_BPS_PARSE_HEADER:
                        if (RecvBuffer[0] == BpsUtils.BPSHeader[0] && dataTmp == BpsUtils.BPSHeader[1])
                        {
                            //s_recvSize = 1;
                            //g_RecvBuffer[s_recvSize++] = dataTmp;
                            //s_toAllocMemory = BPS_TRUE;
                            RecvBuffer.Add(dataTmp);
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_VERSION;
                        }
                        else
                        {
                            RecvBuffer[0] = dataTmp;
                        }
                        break;
                    case EnBPSParseStep.EN_BPS_PARSE_VERSION:
                        if (dataTmp <= BpsUtils.BPSVersion[0])
                        {
                            RecvBuffer.Add(dataTmp);
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_ADDR;
                        }
                        else
                        {
                            HeadClear();
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
                        }
                        break;
                    case EnBPSParseStep.EN_BPS_PARSE_ADDR:
                        RecvBuffer.Add(dataTmp);
                        enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_RMN_LEN1;
                        break;
                    case EnBPSParseStep.EN_BPS_PARSE_RMN_LEN1:
                        RecvBuffer.Add(dataTmp);
                        enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_RMN_LEN2;
                        break;
                    case EnBPSParseStep.EN_BPS_PARSE_RMN_LEN2:
                        RecvBuffer.Add(dataTmp);
                        remainLength = ((RecvBuffer[RecvBuffer.Count-2] & 0xFF) << 8) + (dataTmp & 0xFF);
                        if (remainLength < BpsUtils.BPS_CMD_WORD_SIZE)
                        {
                            HeadClear();
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
                        }
                        else
                        {
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_DATA;
                        }
                        break;
                    case EnBPSParseStep.EN_BPS_PARSE_DATA:
                        //if (s_toAllocMemory)
                        //{
                        //    /* the first byte of data is the command. judge it whether to alloc memory */
                        //    s_toAllocMemory = BPS_FALSE;
                        //    /*
                        //    switch(dataTmp) {
                        //  case CMD_REPORT_SIG_WORD_REQ:
                        //    s_parseData.pu.reportSigReq.fieldArray = &reportSigField;
                        //    reportSigField.value.t_str = sigStringBuf;
                        //    s_parseData.pu.reportSigReq.maxFieldNum = 1;
                        //    break;
                        //  case CMD_SYSTEM_PARA_WORD_REQ:
                        //    s_parseData.pu.sysParaReq.data = sigStringBuf;
                        //    break;
                        //  }
                        //    */
                        //}
                        RecvBuffer.Add(dataTmp);
                        if (0 == --remainLength)
                        {
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_CHKSUM;
                        }
                        break;
                    case EnBPSParseStep.EN_BPS_PARSE_CHKSUM:
                        RecvBuffer.Add(dataTmp);
                        // for(s_rmnLen = 0; s_rmnLen < s_recvSize; s_rmnLen++) {
                        // bc_printf("%02x ", g_RecvBuffer[s_rmnLen]);
                        // }
                        // bc_printf("\r\n");
                        if (IsBPSChksumOK(ref RecvBuffer))
                        {
                            recvOK = true;
                        }
                        // HeadClear();
                        enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
                        break;
                    default:
                        HeadClear();
                        enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
                        break;
                }
            }

            if (recvOK)
            {
                try
                {
                    switch (RecvBuffer[BpsUtils.DATA_INDEX])
                    {
                        case BPSPacketCommTest.RESPONSE_CMD:
                            {
                                BPSPacketCommTest bpsPacket = new BPSPacketCommTest();
                                bpsPacket.ResponseParse(ref RecvBuffer);
                                UIDoBPSPacket(ref bpsPacket);
                                break;
                            }
                        case BPSPacketBaudrate.RESPONSE_CMD:
                            {
                                BPSPacketBaudrate bpsPacket = new BPSPacketBaudrate();
                                bpsPacket.ResponseParse(ref RecvBuffer);
                                UIDoBPSPacket(ref bpsPacket);
                                break;
                            }
                        case BPSPacketReset.RESPONSE_CMD:
                            {
                                BPSPacketReset bpsPacket = new BPSPacketReset();
                                bpsPacket.ResponseParse(ref RecvBuffer);
                                UIDoBPSPacket(ref bpsPacket);
                                break;
                            }
                        case BPSPacketRestoreFac.RESPONSE_CMD:
                            {
                                BPSPacketRestoreFac bpsPacket = new BPSPacketRestoreFac();
                                bpsPacket.ResponseParse(ref RecvBuffer);
                                UIDoBPSPacket(ref bpsPacket);
                                break;
                            }
                            /** System Parameter Commands */
                        case BPSPacketSysPara.RESPONSE_CMD:
                            {
                                BPSPacketSysPara bpsPacket = BPSPacketSysPara.CreateObj(ref RecvBuffer);
                                if(null != bpsPacket)
                                {
                                    bpsPacket.ResponseParse(ref RecvBuffer);
                                    UIDoBPSPacket(ref bpsPacket);
                                }

                                break;
                            }

                    }
                    if (checkBoxDebugEnable.Checked)
                    {
                        printMsg(ref RecvBuffer, STR_DEBUG_RECV_PREFIX);
                    }
                }
                catch(Exception e)
                {

                }
                HeadClear();
            }
        }

        private void UartErrorCallback()
        {
            uartMng.Close();
            buttonUartLink.Text = STR_BUTTON_CONNECT;
            comboBoxUart.Enabled = true;

        }

        private void ButtonCheckVersion_Click(object sender, EventArgs e)
        {
            linkLabelVersionUpdate.Text = "";
            linkLabelVersionUpdate.Enabled = false;
            if (UpdateChecker.EndFlag)
            {
                UpdateChecker.StartWebRequest(DelUpdateChecker);
            }
        }

        private void LinkLabelVersionUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(UpdateChecker.DownloadLinkUrl);
            }
            catch
            {

            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDebugSend_MouseHover(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.buttonDebugSend, STR_TT_DEBUG_SEND);
        }

        private void textBoxDebugSend_MouseHover(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.textBoxDebugSend, STR_TT_DEBUG_SEND);
        }

        private void comboBoxBaudrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxBaudrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDebugSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != ' ' && !Char.IsDigit(e.KeyChar) && !(e.KeyChar <= 'f' && e.KeyChar >= 'a') && !(e.KeyChar <= 'F' && e.KeyChar >= 'A'))
            {
                e.Handled = true;
            }
        }

        private void checkBoxDebugEnable_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxDebugEnable.Checked)
            {
                buttonDebugSend.Enabled = true;
            }
            else
            {
                buttonDebugSend.Enabled = false;
            }
        }

        private void checkBoxDebugEnable_MouseHover(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.checkBoxDebugEnable, STR_TT_DEBUG_ENABLE);
        }

        private void tabPageBC1110_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonNameSet_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text.Length == 0)
            {
                DialogResult dr = MessageBox.Show(STR_MB_SETTING_NOT_NULL, STR_NOTE);
                return;
            }
            BPSPacketName bpsPacket = new BPSPacketName();
            bpsPacket.CmdTypeSysPara = BPSPacketSysPara.CmdType.WRITE;
            bpsPacket.SetData(textBoxName.Text);
            bpsPacket.RequestAssemble();
            List<byte> refList = bpsPacket.MsgList();
            sendMsg(ref refList);
        }

        private void buttonNameRead_Click(object sender, EventArgs e)
        {
            BPSPacketName bpsPacket = new BPSPacketName();
            bpsPacket.CmdTypeSysPara = BPSPacketSysPara.CmdType.READ;
            bpsPacket.RequestAssemble();
            List<byte> refList = bpsPacket.MsgList();
            sendMsg(ref refList);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxUart_MouseHover(object sender, EventArgs e)
        {
            RefreshUartList();

        }

        private void buttonUartLink_Click(object sender, EventArgs e)
        {
            if(uartMng.IsOpen())
            {
                uartMng.Close();
                buttonUartLink.Text = STR_BUTTON_CONNECT;
                comboBoxUart.Enabled = true;
            }
            else
            {
                try
                {
                    uartMng.Baudrate = int.Parse(comboBoxBaudrate.Text);
                    if (uartMng.Open((string)comboBoxUart.SelectedItem))
                    {
                        buttonUartLink.Text = STR_BUTTON_DISCONNECT;
                        comboBoxUart.Enabled = false;
                    }
                    else
                    {
                        uartMng.Close();
                        comboBoxUart.Enabled = true;
                        buttonUartLink.Text = STR_BUTTON_CONNECT;
                    }
                } 
                catch(Exception ex)
                {
                    uartMng.Close();
                    comboBoxUart.Enabled = true;
                    buttonUartLink.Text = STR_BUTTON_CONNECT;
                }
            }
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.textBoxDebugSend, STR_TT_BLE_NAME);
        }

        private void buttonDebugSend_Click(object sender, EventArgs e)
        {
            List<byte> msgList = new List<byte>();
            msgList.Clear();
            try
            {
                string[] hexMsg = textBoxDebugSend.Text.Split(' ');
                if (hexMsg != null && hexMsg.Length > 0)
                {
                    for (int i = 0; i < hexMsg.Length; i++)
                    {
                        string tmp = hexMsg[i];
                        if (tmp.Length < 1 || tmp.Length > 2)
                        {
                            break;
                        }

                        msgList.Add((byte)Convert.ToInt32(tmp, 16));

                    }
                }
            }
            catch (Exception ex)
            {
                msgList.Clear();
            }

            sendMsg(ref msgList);
        }

        private void textBoxDebugSend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                if (Clipboard.ContainsText())
                {
                    try
                    {
                        string ct = Clipboard.GetText();
                        if (ct.Length > 0)
                        {
                            textBoxDebugSend.AppendText(ct);
                        }
                    }
                    catch (Exception)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetSet_Click(object sender, EventArgs e)
        {
            BPSPacketReset bpsPacket = new BPSPacketReset();
            bpsPacket.RequestAssemble();
            List<byte> refList = bpsPacket.MsgList();
            sendMsg(ref refList);
        }

        private void textBoxDebugSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPageBC1110_MouseHover(object sender, EventArgs e)
        {

        }

        private void textBoxBaudrate_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string name = textBoxName.Text;
            Encoding utf8 = Encoding.UTF8;
            byte[] bytes = utf8.GetBytes(name);
            if(null != bytes && bytes.Length >= BPSPacketName.MAX_NAME_LEN)
            {
                if (e.KeyChar != '\b')
                {
                    DialogResult dr = MessageBox.Show(STR_TT_BLE_NAME, STR_NOTE);
                    e.Handled = true;
                }
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonBaudrateSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxBaudrate.Text.Length == 0)
                {
                    DialogResult dr = MessageBox.Show(STR_MB_SETTING_NOT_NULL, STR_NOTE);
                    return;
                }
                BPSPacketBaudrate bpsPacket = new BPSPacketBaudrate();
                bpsPacket.CmdTypeBaudrate = BPSPacketBaudrate.CmdType.WRITE;
                bpsPacket.Baudrate = UInt32.Parse(textBoxBaudrate.Text);
                bpsPacket.RequestAssemble();
                List<byte> refList = bpsPacket.MsgList();
                sendMsg(ref refList);
            } 
            catch
            {

            }
        }

        private void buttonBaudrateRead_Click(object sender, EventArgs e)
        {
            BPSPacketBaudrate bpsPacket = new BPSPacketBaudrate();
            bpsPacket.CmdTypeBaudrate = BPSPacketBaudrate.CmdType.READ;
            bpsPacket.RequestAssemble();
            List<byte> refList = bpsPacket.MsgList();
            sendMsg(ref refList);
            // uartMng.write(bpsPacket.MsgBuffer());
        }

        private void buttonFacRestoreSet_Click(object sender, EventArgs e)
        {
            BPSPacketRestoreFac bpsPacket = new BPSPacketRestoreFac();
            bpsPacket.RequestAssemble();
            List<byte> refList = bpsPacket.MsgList();
            sendMsg(ref refList);
        }

        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxBaudrate.Text = comboBoxBaudrate.SelectedItem.ToString();

                if (uartMng.IsOpen())
                {
                    uartMng.Close();

                    try
                    {
                        uartMng.Baudrate = int.Parse(comboBoxBaudrate.Text);
                        if (uartMng.Open((string)comboBoxUart.SelectedItem))
                        {
                            buttonUartLink.Text = STR_BUTTON_DISCONNECT;
                            comboBoxUart.Enabled = false;
                        }
                        else
                        {
                            uartMng.Close();
                            comboBoxUart.Enabled = true;
                            buttonUartLink.Text = STR_BUTTON_CONNECT;
                        }
                    }
                    catch (Exception ex)
                    {
                        uartMng.Close();
                        comboBoxUart.Enabled = true;
                        buttonUartLink.Text = STR_BUTTON_CONNECT;
                    }
                }
            }
            catch
            {

            }
        }
    }
}

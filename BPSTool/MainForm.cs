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

        public const string STR_COMM_ERR = "通信错误";
        public const string STR_NEWEST_VERSION = "已经是最新版本";
        public const string STR_NEW_VERSION_CHECK = "检测到新版：";
        public const string STR_BUTTON_CONNECT = "连接";
        public const string STR_BUTTON_DISCONNECT = "断开";
        public const string STR_TT_DEBUG_SEND = "仅支持16进制发送，例如“BB CC 00 01 00 01 00 02”";
        public const string STR_TT_DEBUG_ENABLE = "使能串口发送/接收调试";
        public const string STR_TT_BLE_NAME = "最长20字节";
        public const string STR_DEBUG_SEND_PREFIX = "发送→：";
        public const string STR_DEBUG_RECV_PREFIX = "接收←：";
        public const string STR_NOTE = "提示";
        public const string STR_MB_SETTING_NOT_NULL = "设置内容不可为空";
        public const string STR_NO_SERIAL_PORT = "无串口设备";
        public const string STR_NO_BPS_PORT_FOUND = "没有发现BPS设备";

        public const uint BPSTOOL_VERSION_MAIN = 1;
        public const uint BPSTOOL_VERSION_SUB = 0;
        public const uint BPSTOOL_VERSION_PATCH = 2;

        public delegate void DelUpdateUI_VV();
        public delegate void DelUpdateUI_VL(ref List<Byte> msg);
        public delegate void DelDebugMsg(List<Byte> msgList, string prefix);
        public delegate void DelRecvBPSPacket(BaseBPSPacket baseBPSPacket);
        //public delegate void DelUartErrorUI_VV();


        private DelUpdateUI_VV DelUpdateChecker;
        private BpsMng.DelBPSRecvHandler DelUartRecv;

        private SerialErrorReceivedEventHandler serialErrorReceivedEvent;
        private SerialDataReceivedEventHandler serialDataReceivedEvent;

        private BpsMng.DelBPSSendDebugHandler DelUartSendDebug;
        private BpsMng.DelBPSRecvDebugHandler DelUartRecvDebug;
        private BpsMng.DelUartErrorHandler DelUartError;

        private Updater UpdateChecker;
        // private UartMng uartMng;
        private BpsMng bpsMngObj;
        public Dictionary<string, int> searchSerialPortMap;
        public string searchPortSelected;

        public BpsMng BpsMngObj { get => bpsMngObj; set => bpsMngObj = value; }

        //private List<byte> RecvBuffer;
        //private EnBPSParseStep enBPSParseStep;
        //private int remainLength;


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

            //uartMng = new UartMng(this);
            bpsMngObj = new BpsMng();
            DelUartRecv = new BpsMng.DelBPSRecvHandler(UartDataReceivedHandler);
            DelUartSendDebug = new BpsMng.DelBPSSendDebugHandler(SendDebugHandler);
            DelUartRecvDebug = new BpsMng.DelBPSRecvDebugHandler(RecvDebugHandler);
            DelUartError = new BpsMng.DelUartErrorHandler(UartErrorHandler);

            AddBPSDelegate();
            // DelUartError = new DelUpdateUI_VV(UartErrorCallback);

            //serialErrorReceivedEvent = new SerialErrorReceivedEventHandler(UartErrorReceivedCallback);
            //uartMng.ErrorCallbackAdd(serialErrorReceivedEvent);
            //serialDataReceivedEvent = new SerialDataReceivedEventHandler(UartDataeceivedCallback);
            //uartMng.ReadCallbackAdd(serialDataReceivedEvent);

            RefreshUartList();
            if (comboBoxUart.Items.Count > 0)
            {
                comboBoxUart.SelectedIndex = 0;
            }
            searchSerialPortMap = new Dictionary<string, int>();

            /** TODO: need to move to uartMng */
            //RecvBuffer = new List<byte>();
            //HeadClear();
            //enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
            //remainLength = 0;

            /** read configurature */
            bool debug_checked = true;
            String baudrate = "9600";
            try
            {
                //指定config文件读取
                string file = System.Windows.Forms.Application.ExecutablePath;
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);
                if(!config.HasFile)
                {
                    string[] ConfigFileOrigin = new string[] {
@"<?xml version=""1.0"" encoding=""utf-8"" ?>",
@"<configuration>",
@"  <appSettings>",
@"    <add key=""debug_checked"" value=""TRUE"" />",
@"    <add key=""baudrate"" value=""9600"" />",
@"  </appSettings>",
@"</configuration>"
                    };
                    using (StreamWriter sw = new StreamWriter(config.FilePath))
                    {
                        foreach (string s in ConfigFileOrigin)
                        {
                            sw.WriteLine(s);

                        }
                    }
                }

                debug_checked = Boolean.Parse(config.AppSettings.Settings["debug_checked"].Value);
                baudrate = config.AppSettings.Settings["baudrate"].Value;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            checkBoxDebugEnable.Checked = debug_checked;
            comboBoxBaudrate.Text = baudrate;
        }

        private void AddBPSDelegate()
        {
            bpsMngObj.AddRecvHandler(DelUartRecv);
            bpsMngObj.AddSendDebugHandler(DelUartSendDebug);
            bpsMngObj.AddRecvDebugHandler(DelUartRecvDebug);
            bpsMngObj.AddErrorHandler(DelUartError);
        }

        private void ClearBPSDelegate()
        {
            bpsMngObj.RemoveRecvHandler(DelUartRecv);
            bpsMngObj.RemoveSendDebugHandler(DelUartSendDebug);
            bpsMngObj.RemoveRecvDebugHandler(DelUartRecvDebug);
            bpsMngObj.RemoveErrorHandler(DelUartError);
        }

        private void SendDebugHandler(BpsMng.IReadonlyMsgList msgList)
        {
            if (checkBoxDebugEnable.Checked)
            {
                DelDebugMsg del = new DelDebugMsg(printMsg);
                object[] args = new object[2];
                args[0] = msgList.msgList;
                args[1] = STR_DEBUG_SEND_PREFIX;
                BeginInvoke(del, args);
            }
        }

        private void RecvDebugHandler(BpsMng.IReadonlyMsgList msgList)
        {
            if (checkBoxDebugEnable.Checked)
            {
                DelDebugMsg del = new DelDebugMsg(printMsg);
                object[] args = new object[2];
                args[0] = msgList.msgList;
                args[1] = STR_DEBUG_RECV_PREFIX;
                BeginInvoke(del, args);
            }
        }

        private void UartErrorHandler()
        {
            if (!bpsMngObj.IsUartOpen())
            {
                bpsMngObj.UartClose();
                DelUpdateUI_VV del = new DelUpdateUI_VV(RefreshUartList);
                BeginInvoke(del);
                del = new DelUpdateUI_VV(StateDisconnected);
                BeginInvoke(del);
            }
        }

        private void printMsg(List<Byte> msgList, string prefix)
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
                bpsMngObj.SendDebugData(msgList);
            }
        }

        //private bool IsBPSChksumOK(ref List<byte> msg)
        //{
        //    UInt16 len;
        //    int checksum;

        //    checksum = 0;
        //    for(int i = BpsUtils.BPSHeader.Length; i < msg.Count-1; i++)
        //    {
        //        checksum += (msg[i] & 0xFF);
        //    }

        //    return (checksum & 0xFF) == (msg[msg.Count-1] & 0xFF);
        //}

        //private void HeadClear()
        //{
        //    RecvBuffer.Clear();
        //    RecvBuffer.Add(0);
        //}

        private void UartErrorReceivedCallback(object sender, SerialErrorReceivedEventArgs e)
        {
            Console.WriteLine("error");
            // BpsToolCallback(DelUartError);
        }

        //private void UartDataeceivedCallback(object sender, SerialDataReceivedEventArgs e)
        //{
        //    Console.WriteLine("data");
        //    byte[] buffer = new byte[uartMng.serialPort.BytesToRead];
        //    uartMng.serialPort.Read(buffer, 0, buffer.Length);
        //    List<byte> msg = new List<byte>(buffer);
        //    BpsToolCallback(DelUartRecv, ref msg);
        //}

        private void RefreshUartList()
        {
            string currentPortTmp = null;
            if (comboBoxUart.Items.Count > 0)
            {
                currentPortTmp = (string)comboBoxUart.SelectedItem;
            }

            comboBoxUart.Items.Clear();

            foreach (string port in bpsMngObj.PortList())
            {
                comboBoxUart.Items.Add(port);
                if (null != currentPortTmp && port.Equals(currentPortTmp))
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

        private void UIDoBPSPacket(BPSPacketCommTest bps)
        {
            if(null == bps)
            {
                return;
            }
        }

        private void UIDoBPSPacket(BPSPacketBaudrate bps)
        {
            if(null == bps)
            {
                return;
            }
            textBoxBaudrate.Text = bps.Baudrate.ToString();
        }

        private void UIDoBPSPacket(BPSPacketSysPara bps)
        {
            if (null == bps)
            {
                return;
            }

            switch (bps.ParaId)
            {
                case BPSPacketSysPara.SysParaID.NAME:
                    if(bps.CmdTypeSysPara == BPSPacketSysPara.CmdType.READ)
                    {
                        textBoxName.Text = bps.ToString();
                    }
                    break;
            }
        }

        private void UIDoBPSPacket(BPSPacketReset bps)
        {
            if (null == bps)
            {
                return;
            };
        }

        private void UIDoBPSPacket(BPSPacketRestoreFac bps)
        {
            if (null == bps)
            {
                return;
            }
        }

        private void UartDataReceivedHandler(BaseBPSPacket baseBPSPacket)
        {
            DelRecvBPSPacket del = new DelRecvBPSPacket(UartDataReceiedCallback);
            object[] args = new object[1];
            args[0] = baseBPSPacket;
            BeginInvoke(del, args);
        }

        private void UartDataReceiedCallback(BaseBPSPacket baseBPSPacket)
        {
            try
            {
                switch (baseBPSPacket.ResponseCmd)
                {
                    case BPSPacketCommTest.RESPONSE_CMD:
                        {
                            BPSPacketCommTest p = baseBPSPacket as BPSPacketCommTest;
                            UIDoBPSPacket(p);
                            break;
                        }
                    case BPSPacketBaudrate.RESPONSE_CMD:
                        {
                            BPSPacketBaudrate p = baseBPSPacket as BPSPacketBaudrate;
                            UIDoBPSPacket(p);
                            break;
                        }
                    case BPSPacketReset.RESPONSE_CMD:
                        {
                            BPSPacketReset p = baseBPSPacket as BPSPacketReset;
                            UIDoBPSPacket(p);
                            break;
                        }
                    case BPSPacketRestoreFac.RESPONSE_CMD:
                        {
                            BPSPacketRestoreFac p = baseBPSPacket as BPSPacketRestoreFac;
                            UIDoBPSPacket(p);
                            break;
                        }
                    /** System Parameter Commands */
                    case BPSPacketSysPara.RESPONSE_CMD:
                        {
                            BPSPacketSysPara p = baseBPSPacket as BPSPacketSysPara;
                            UIDoBPSPacket(p);
                            break;
                        }
                }
            }
            catch (Exception e)
            {

            }
        }

        private void UartErrorCallback()
        {
            bpsMngObj.UartClose();
            buttonUartLink.Text = STR_BUTTON_CONNECT;
            comboBoxUart.Enabled = true;
            buttonSearch.Enabled = true;
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
            bpsMngObj.SendBPSPacketReq(bpsPacket);
        }

        private void buttonNameRead_Click(object sender, EventArgs e)
        {
            BPSPacketName bpsPacket = new BPSPacketName();
            bpsPacket.CmdTypeSysPara = BPSPacketSysPara.CmdType.READ;
            bpsMngObj.SendBPSPacketReq(bpsPacket);
            //bpsPacket.RequestAssemble();
            //List<byte> refList = bpsPacket.MsgList();
            //sendMsg(ref refList);


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxUart_MouseHover(object sender, EventArgs e)
        {
            RefreshUartList();

        }

        private void StateConnected()
        {
            buttonUartLink.Text = STR_BUTTON_DISCONNECT;
            comboBoxUart.Enabled = false;
            buttonSearch.Enabled = false;
        }

        private void StateDisconnected()
        {
            buttonUartLink.Text = STR_BUTTON_CONNECT;
            comboBoxUart.Enabled = true;
            buttonSearch.Enabled = true;
        }

        private void buttonUartLink_Click(object sender, EventArgs e)
        {
            if(bpsMngObj.IsUartOpen())
            {
                bpsMngObj.UartClose();
                StateDisconnected();
            }
            else
            {
                try
                {
                    if (bpsMngObj.UartOpen((string)comboBoxUart.SelectedItem, int.Parse(comboBoxBaudrate.Text)))
                    {
                        StateConnected();
                    }
                    else
                    {
                        bpsMngObj.UartClose();
                        StateDisconnected();
                    }
                } 
                catch(Exception ex)
                {
                    bpsMngObj.UartClose();
                    StateDisconnected();
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
            string copy = this.textBoxDebugMsg.SelectedText;
            if(copy != null && copy.Length > 0)
            {
                Clipboard.SetDataObject(copy);
            }
            
        }

        private void buttonResetSet_Click(object sender, EventArgs e)
        {
            BPSPacketReset bpsPacket = new BPSPacketReset();
            bpsMngObj.SendBPSPacketReq(bpsPacket);
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
                bpsMngObj.SendBPSPacketReq(bpsPacket);
            } 
            catch
            {

            }
        }

        private void buttonBaudrateRead_Click(object sender, EventArgs e)
        {
            BPSPacketBaudrate bpsPacket = new BPSPacketBaudrate();
            bpsPacket.CmdTypeBaudrate = BPSPacketBaudrate.CmdType.READ;
            bpsMngObj.SendBPSPacketReq(bpsPacket);
        }

        private void buttonFacRestoreSet_Click(object sender, EventArgs e)
        {
            BPSPacketRestoreFac bpsPacket = new BPSPacketRestoreFac();
            bpsMngObj.SendBPSPacketReq(bpsPacket);
        }

        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxBaudrate.Text = comboBoxBaudrate.SelectedItem.ToString();

                if (bpsMngObj.IsUartOpen())
                {
                    bpsMngObj.UartClose();

                    try
                    {
                        // uartMng.Baudrate = int.Parse(comboBoxBaudrate.Text);
                        if (bpsMngObj.UartOpen((string)comboBoxUart.SelectedItem, int.Parse(comboBoxBaudrate.Text)))
                        {
                            StateConnected();
                        }
                        else
                        {
                            bpsMngObj.UartClose();
                            StateDisconnected();
                        }
                    }
                    catch (Exception ex)
                    {
                        bpsMngObj.UartClose();
                        StateDisconnected();
                    }
                }
            }
            catch
            {

            }
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            textBoxDebugMsg.Clear();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (bpsMngObj.IsUartOpen())
            {
                return;
            }
            ClearBPSDelegate();
            searchSerialPortMap.Clear();
            SearchingForm searchForm = new SearchingForm(this);
            searchForm.ShowDialog(this);
            if (searchSerialPortMap.Count > 0)
            {
                SearchListForm searchListForm = new SearchListForm(this);
                searchListForm.ShowDialog(this);

                if(null == searchPortSelected)
                {
                    return;
                }

                try
                {
                    comboBoxBaudrate.Text = searchSerialPortMap[searchPortSelected].ToString();
                    for (int i = 0; i < comboBoxUart.Items.Count; i++)
                    {
                        if(comboBoxUart.Items[i].ToString() == searchPortSelected)
                        {
                            comboBoxUart.SelectedIndex = i;
                            break;
                        }
                    }
                    
                    if (bpsMngObj.UartOpen((string)comboBoxUart.SelectedItem, int.Parse(comboBoxBaudrate.Text)))
                    {
                        StateConnected();
                    }
                    else
                    {
                        bpsMngObj.UartClose();
                        StateDisconnected();
                    }
                }
                catch (Exception ex)
                {
                    bpsMngObj.UartClose();
                    StateDisconnected();
                }

                searchSerialPortMap.Clear();
            }
            else
            {
                MessageBox.Show(this, STR_NO_BPS_PORT_FOUND, STR_NOTE);
            }
            
            AddBPSDelegate();
        }

        private void splitContainerTop1Title_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxUart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

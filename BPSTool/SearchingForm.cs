using BPSTool.BPSPacket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BPSTool
{
    public partial class SearchingForm : Form
    {
        private const int TIMEOUT = 500; // 2000 milliseconds
        private string strBPSSearch;
        private int timeoutLeft;
        private int currentSearchBaudrate;
        private string currentPort;
        private BpsMng bpsMngObj;
        private List<int> baudrateList;
        private List<string> portList;
        private int baudrateListIndex;
        private int portListIndex;
        private bool startNewSearch;
        private bool devFound;
        private MainForm parentForm;

        private BpsMng.DelBPSRecvHandler DelUartRecv;

        public delegate void DelRecvBPSPacket(BaseBPSPacket baseBPSPacket);

        public SearchingForm(MainForm mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
            bpsMngObj = mainForm.BpsMngObj;
            DelUartRecv = new BpsMng.DelBPSRecvHandler(UartDataReceivedHandler);
            bpsMngObj.AddRecvHandler(DelUartRecv);
            timeoutLeft = 0;

            // strBPSSearch = labeSearchlNote.Text;
            // ResourceManager rm = UITools.getResourceMng();
            // strBPSSearch = rm.GetString("StrSearch", System.Threading.Thread.CurrentThread.CurrentUICulture);
            strBPSSearch = UITools.GetString("StrSearch");

            baudrateList = new List<int>(BpsUtils.StdBaudrate);
            baudrateListIndex = (baudrateList.Count > 0) ? (baudrateList.Count - 1) : -1;
            portList = new List<string>(bpsMngObj.PortList());
            portListIndex = (portList.Count > 0) ? (portList.Count - 1) : -1;
            startNewSearch = false;
            devFound = false;

            if (portListIndex >= 0)
            {
                currentPort = portList[portListIndex];
            }
            else
            {
                timerSearchEndCheck.Enabled = false;
            }

            if (baudrateListIndex >= 0)
            {
                currentSearchBaudrate = baudrateList[baudrateListIndex];
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
                    case BPSPacketDevInfo.RESPONSE_CMD:
                        {
                            BPSPacketDevInfo p = baseBPSPacket as BPSPacketDevInfo;
                            UIDoBPSPacket(p);   
                            break;
                        }
                }
            }
            catch (Exception e)
            {

            }
        }

        private void UIDoBPSPacket(BPSPacketCommTest bps)
        {
            if (null == bps)
            {
                return;
            }
            if(!devFound)
            {
                devFound = true;
            }
        }

        private void UIDoBPSPacket(BPSPacketDevInfo bps)
        {
            if (null == bps)
            {
                return;
            }
            timeoutLeft = TIMEOUT;
        }

        private void timerSearchEndCheck_Tick(object sender, EventArgs e)
        {
            if (devFound)
            {
                devFound = false;
                timeoutLeft = -1;
                if (!parentForm.searchSerialPortMap.ContainsKey(currentPort))
                {
                    parentForm.searchSerialPortMap.Add(currentPort, currentSearchBaudrate);
                    portList.Remove(currentPort);
                    portListIndex--;
                }
                
            }
            else
            {
                timeoutLeft -= timerSearchEndCheck.Interval;
            }

            if(timeoutLeft < 0)
            {
                /** check if ports iterating completed */
                if(portListIndex < 0)
                {
                    if(baudrateListIndex < 0 || portList.Count <= 0)
                    {
                        /** completed */
                        bpsMngObj.UartClose();
                        bpsMngObj.RemoveRecvHandler(DelUartRecv);
                        this.Close();
                        return;
                    }
                    else
                    {
                        currentSearchBaudrate = baudrateList[baudrateListIndex--];
                        portListIndex = portList.Count - 1;
                        currentPort = portList[portListIndex];
                    }
                }
                else
                {
                    currentPort = portList[portListIndex--];
                }

                timeoutLeft = TIMEOUT;
                labeSearchlNote.Text = strBPSSearch + ":" + currentSearchBaudrate + "@" + currentPort;
                startNewSearch = true;
            }

            SearchPort();
        }

        private void SearchPort()
        {
            if(startNewSearch)
            {
                startNewSearch = false;
                bpsMngObj.UartClose();
                if (bpsMngObj.UartOpen(currentPort, currentSearchBaudrate))
                {
                    /** do nothing */
                }
                else
                {
                    timeoutLeft = 0;
                }
            }

            if (bpsMngObj.IsUartOpen())
            {
                BPSPacketCommTest bpsPacket = new BPSPacketCommTest();
                bpsMngObj.SendBPSPacketReq(bpsPacket);
            }
        }

        private void SearchingForm_Shown(object sender, EventArgs e)
        {
            if (portListIndex < 0)
            {
                MessageBox.Show(this, UITools.GetString("StrNoSerialDev"), UITools.GetString("StrNote"));
                bpsMngObj.UartClose();
                bpsMngObj.RemoveRecvHandler(DelUartRecv);
                this.Close();
                return;
            }
        }
    }
}

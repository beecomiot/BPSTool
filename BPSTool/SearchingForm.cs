using BPSTool.BPSPacket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BPSTool
{
    public partial class SearchingForm : Form
    {
        private const int TIMEOUT = 500; // 2000 milliseconds
        private const string STR_BPS_SEARCH = "BPS搜索";
        private int timeoutLeft;
        private int currentSearchBaudrate;
        private string currentPort;
        private BpsMng bpsMngObj;
        private List<int> baudrateList;
        private List<string> portList;
        private int baudrateListIndex;
        private int portListIndex;

        private BpsMng.DelBPSRecvHandler DelUartRecv;

        public delegate void DelRecvBPSPacket(BaseBPSPacket baseBPSPacket);

        public SearchingForm()
        {
            InitializeComponent();
            bpsMngObj = new BpsMng();
            DelUartRecv = new BpsMng.DelBPSRecvHandler(UartDataReceivedHandler);
            bpsMngObj.AddRecvHandler(DelUartRecv);
            timeoutLeft = 0;
            

            baudrateList = new List<int>(BpsUtils.StdBaudrate);
            baudrateListIndex = (baudrateList.Count > 0) ? (baudrateList.Count - 1) : -1;
            portList = new List<string>(bpsMngObj.PortList());
            portListIndex = (portList.Count > 0) ? (portList.Count - 1) : -1;

            if (portListIndex >= 0)
            {
                currentPort = portList[portListIndex];
            }
            else
            {
                /** TODO: to show no port available */
                this.Close();
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
            timeoutLeft = TIMEOUT;
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
            timeoutLeft -= timerSearchEndCheck.Interval;

            if(timeoutLeft < 0)
            {
                /** check if ports iterating completed */
                if(portListIndex < 0)
                {
                    if(baudrateListIndex < 0)
                    {
                        /** completed */
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
                labeSearchlNote.Text = STR_BPS_SEARCH + ":" + currentSearchBaudrate + "@" + currentPort;
                SearchPort();
            }
        }

        private void SearchPort()
        {

        }

        private void SearchingForm_Shown(object sender, EventArgs e)
        {

        }
    }
}

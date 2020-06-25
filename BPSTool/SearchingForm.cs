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
        private const int TIMEOUT = 5; // 5 seconds
        private bool searchCompleted;
        private int timeoutHalfSecond;
        private int currentSearchBaudrate;
        private UartMng uartMng;

        public SearchingForm(ref UartMng uartMngTmp)
        {
            InitializeComponent();

            searchCompleted = false;
            uartMng = uartMngTmp;
        }

        private void timerSearchEndCheck_Tick(object sender, EventArgs e)
        {
            string suffix = "";
            for(int i = 0; i < timeoutHalfSecond % 4; i++)
            {
                suffix += ".";
            }
            labeSearchlNote.Text = "波特率" + currentSearchBaudrate + "搜索(" + timeoutHalfSecond/2 + ")" + suffix;
            timeoutHalfSecond--;

            if (searchCompleted)
            {
                this.Close();
            }

        }

        private void SetSearchingBaudrate(int baudrate)
        {
            if(baudrate != currentSearchBaudrate)
            {
                currentSearchBaudrate = baudrate;
                timeoutHalfSecond = TIMEOUT*2;
                uartMng.Baudrate = baudrate;
            }
        }

        private void SearchingForm_Shown(object sender, EventArgs e)
        {
            foreach (int baudrate in BpsUtils.StdBaudrate)
            {
                SetSearchingBaudrate(baudrate);
                foreach (string port in uartMng.PortList)
                {
                    if(timeoutHalfSecond <= 0)
                    {
                        break;
                    }

                    if(uartMng.IsOpen())
                    {
                        uartMng.Close();
                    }
                    if(uartMng.Open(port))
                    {

                    }

                }
            }

            searchCompleted = true;
        }
    }
}

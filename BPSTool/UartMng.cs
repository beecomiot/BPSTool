using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace BPSTool
{
    public class UartMng
    {
        public const int DEF_BAUDRATE = 9600;

        public System.IO.Ports.SerialPort serialPort;
        private int currentPort;
        private List<String> portList;
        private int baudrate;
        private bool disposed;
        private MainForm form;

        public int Baudrate { get => baudrate; set => baudrate = value; }
        public List<string> PortList { get => portList; }
        public int CurrentPort { get => currentPort; set => currentPort = value; }

        public UartMng(MainForm f)
        {
            serialPort = new System.IO.Ports.SerialPort();
            baudrate = DEF_BAUDRATE;
            RefreshPortList();
            
            if (portList.Count > 0)
            {
                SetCurrentPort(0);
            }
            else
            {
                SetCurrentPort(-1);
            }
            disposed = false;
            form = f;
        }

        public bool IsCommPortValid(string port)
        {
            bool ret = true;
            //try
            //{
            //    SerialPort sp = new SerialPort(port);
            //    sp.Open();
            //    sp.Close();
            //    sp.Dispose();
            //    sp = null;
            //}
            //catch(Exception e)
            //{
            //    ret = false;
            //}

            return ret;
        }

        public void RefreshPortList()
        {
            portList = new List<string>();
            portList.Clear();

            String[] serialPortArray = SerialPort.GetPortNames();
            if (serialPortArray != null && serialPortArray.Length != 0)
            {
                //对串口进行排序
                Array.Sort<String>(serialPortArray);
                foreach (String port in serialPortArray)
                {
                    if (port != null && port.Length != 0)
                    {
                        if (IsCommPortValid(port))
                        {
                            portList.Add(port);
                        }
                    }
                }
            }

        }

        public void SetCurrentPort(int portIndex)
        {
            if (portIndex < 0) currentPort = portIndex; // set null port 
            if (portIndex < portList.Count) currentPort = portIndex; // set valid port
        }

        //public void Dispose()
        //{
        //    if (this.serialPort == null)
        //        return;
        //    if (this.serialPort.IsOpen)
        //        this.Close();
        //    this.serialPort.Dispose();
        //    this.serialPort = null;
        //    disposed = true;
        //}


        public bool Open(string port)
        {
            try
            {
                if (serialPort == null)
                {
                    return this.IsOpen();
                }

                if (serialPort.IsOpen)
                {
                    this.Close();
                }

                // 串口名
                serialPort.PortName = port;
                // 波特率 9600
                serialPort.BaudRate = baudrate;
                // 数据位为 8 位
                serialPort.DataBits = 8;
                // 停止位为 1 位
                serialPort.StopBits = StopBits.One;
                // 无奇偶校验位
                serialPort.Parity = Parity.None;
                // 读取串口超时时间为500ms
                serialPort.ReadTimeout = 500;
                // 读取串口超时时间为500ms
                serialPort.WriteTimeout = 500;

                serialPort.Open();
            }
            catch (Exception e)
            {
                serialPort.Close();
            }

            return this.IsOpen();
        }

        public void Close()
        {
            if (this.IsOpen())
            {
                serialPort.Close();
            }

        }

        public bool IsOpen()
        {
            bool ret = false;
            if (serialPort != null)
            {
                ret = serialPort.IsOpen;
            }
            return ret;
        }

        public bool write(byte[] buffer)
        {
            bool ret = true;
            try
            {
                serialPort.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public void ReadCallback(SerialDataReceivedEventHandler callback)
        {
            this.serialPort.DataReceived += callback;
        }

        public void ReadCallbackClear(SerialDataReceivedEventHandler callback)
        {
            this.serialPort.DataReceived -= callback;
        }

        public void ErrorCallback(SerialErrorReceivedEventHandler callback)
        {
            this.serialPort.ErrorReceived += callback;
        }

        public void ErrorCallbackClear(SerialErrorReceivedEventHandler callback)
        {
            this.serialPort.ErrorReceived -= callback;
        }
        public void PinChangedCallback(SerialPinChangedEventHandler callback)
        {
            this.serialPort.PinChanged += callback;
        }

        public void PinChangedCallbackClear(SerialPinChangedEventHandler callback)
        {
            this.serialPort.PinChanged -= callback;
        }
    }
}

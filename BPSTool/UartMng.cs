using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using System.Management;

namespace BPSTool
{
    public class UartMng
    {
        public const int DEF_BAUDRATE = 9600;

        public System.IO.Ports.SerialPort serialPort;
        //private int currentPort;
        private List<String> portList;
        private int baudrate;
        private MainForm form;
        private SerialErrorReceivedEventHandler errorHandler;

        public int Baudrate { get => baudrate; set => baudrate = value; }
        public List<string> PortList { get => portList; }

        //public int CurrentPort { get => currentPort; set => currentPort = value; }

        private static UartMng uartMngInstance = null;

        public static UartMng GetUartMngInstance()
        {
            if(null == uartMngInstance)
            {
                uartMngInstance = new UartMng();
            }

            SerialPortService.PortsChanged += new EventHandler<PortsChangedArgs>(PortPlugEventHandler);
            return uartMngInstance;
        
        }

        //public UartMng(MainForm f)
        //{
        //    serialPort = new System.IO.Ports.SerialPort();
        //    baudrate = DEF_BAUDRATE;
        //    RefreshPortList();
        //    errorHandler = null;

        //    //if (portList.Count > 0)
        //    //{
        //    //    SetCurrentPort(0);
        //    //}
        //    //else
        //    //{
        //    //    SetCurrentPort(-1);
        //    //}

        //    form = f;
        //}

        private UartMng()
        {
            serialPort = new System.IO.Ports.SerialPort();
            baudrate = DEF_BAUDRATE;
            RefreshPortList();
            errorHandler = null;

            //if (portList.Count > 0)
            //{
            //    SetCurrentPort(0);
            //}
            //else
            //{
            //    SetCurrentPort(-1);
            //}
        }

        public string GetCurrentPort()
        {
            string ret = "";
            if(null != serialPort.PortName && serialPort.PortName.Length > 0)
            {
                ret = serialPort.PortName;
            }
            return ret;
        }

        public bool IsCommPortValid(string port)
        {
            bool ret = true;

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

        //public void SetCurrentPort(int portIndex)
        //{
        //    if (portIndex < 0) currentPort = portIndex; // set null port 
        //    else if (portIndex < portList.Count) currentPort = portIndex; // set valid port
        //}

        public bool Open(string port)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    this.Close();
                }

                // serial port name
                serialPort.PortName = port;
                // set baudrate rate 
                serialPort.BaudRate = baudrate;
                // data bits: 8
                serialPort.DataBits = 8;
                // stop bit: 1
                serialPort.StopBits = StopBits.One;
                // no parity
                serialPort.Parity = Parity.None;
                // reading timeout: 500ms
                serialPort.ReadTimeout = 500;
                // writing timeout: 500ms
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
            return serialPort.IsOpen;
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

        public void ReadCallbackAdd(SerialDataReceivedEventHandler callback)
        {
            
            this.serialPort.DataReceived += callback;
        }

        public void ReadCallbackClear(SerialDataReceivedEventHandler callback)
        {
            this.serialPort.DataReceived -= callback;
        }

        public void ErrorCallbackAdd(SerialErrorReceivedEventHandler callback)
        {
            errorHandler += callback;
            this.serialPort.ErrorReceived += callback;
        }

        public void ErrorCallbackClear(SerialErrorReceivedEventHandler callback)
        {
            errorHandler -= callback;
            this.serialPort.ErrorReceived -= callback;
        }
        public void PinChangedCallbackAdd(SerialPinChangedEventHandler callback)
        {
            this.serialPort.PinChanged += callback;
        }

        public void PinChangedCallbackClear(SerialPinChangedEventHandler callback)
        {
            this.serialPort.PinChanged -= callback;
        }



        private static void PortPlugEventHandler(object sender, PortsChangedArgs e)
        {
            UartMng obj = GetUartMngInstance();
            if(null != obj)
            {
                obj.RefreshPortList();
                if(e.EventType == EventType.Removal)
                {
                    bool currentPortRemoved = true;
                    List<string> portList = obj.PortList;
                    foreach(string port in portList)
                    {
                        if(port == obj.GetCurrentPort())
                        {
                            currentPortRemoved = false;
                            break;
                        }
                    }

                    if(currentPortRemoved)
                    {
                        obj.errorHandler(null, null);
                    }
                }
            }
        }
    }

    public static class SerialPortService
    {
        private static SerialPort _serialPort;

        private static string[] _serialPorts;

        private static ManagementEventWatcher arrival;

        private static ManagementEventWatcher removal;

        /// <summary>
        /// Tell subscribers, if any, that this event has been raised.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler">The generic event handler</param>
        /// <param name="sender">this or null, usually</param>
        /// <param name="args">Whatever you want sent</param>
        public static void Raise<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs
        {
            // Copy to temp var to be thread-safe (taken from C# 3.0 Cookbook - don't know if it's true)
            EventHandler<T> copy = handler;
            if (copy != null)
            {
                copy(sender, args);
            }
        }

        static SerialPortService()
        {
            _serialPorts = GetAvailableSerialPorts();
            MonitorDeviceChanges();
        }

        /// <summary>
        /// If this method isn't called, an InvalidComObjectException will be thrown (like below):
        /// System.Runtime.InteropServices.InvalidComObjectException was unhandled
        ///Message=COM object that has been separated from its underlying RCW cannot be used.
        ///Source=mscorlib
        ///StackTrace:
        ///     at System.StubHelpers.StubHelpers.StubRegisterRCW(Object pThis, IntPtr pThread)
        ///     at System.Management.IWbemServices.CancelAsyncCall_(IWbemObjectSink pSink)
        ///     at System.Management.SinkForEventQuery.Cancel()
        ///     at System.Management.ManagementEventWatcher.Stop()
        ///     at System.Management.ManagementEventWatcher.Finalize()
        ///InnerException: 
        /// </summary>
        public static void CleanUp()
        {
            arrival.Stop();
            removal.Stop();
        }

        public static event EventHandler<PortsChangedArgs> PortsChanged;

        private static void MonitorDeviceChanges()
        {
            try
            {
                var deviceArrivalQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
                var deviceRemovalQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");

                arrival = new ManagementEventWatcher(deviceArrivalQuery);
                removal = new ManagementEventWatcher(deviceRemovalQuery);

                arrival.EventArrived += (o, args) => RaisePortsChangedIfNecessary(EventType.Insertion);
                removal.EventArrived += (sender, eventArgs) => RaisePortsChangedIfNecessary(EventType.Removal);

                // Start listening for events
                arrival.Start();
                removal.Start();
            }
            catch (ManagementException err)
            {

            }
        }

        private static void RaisePortsChangedIfNecessary(EventType eventType)
        {
            lock (_serialPorts)
            {
                var availableSerialPorts = GetAvailableSerialPorts();
                if (!_serialPorts.SequenceEqual(availableSerialPorts))
                {
                    _serialPorts = availableSerialPorts;
                    PortsChanged.Raise(null, new PortsChangedArgs(eventType, _serialPorts));
                }
            }
        }

        public static string[] GetAvailableSerialPorts()
        {
            return SerialPort.GetPortNames();
        }
    }

    public enum EventType
    {
        Insertion,
        Removal,
    }

    public class PortsChangedArgs : EventArgs
    {
        private readonly EventType _eventType;

        private readonly string[] _serialPorts;

        public PortsChangedArgs(EventType eventType, string[] serialPorts)
        {
            _eventType = eventType;
            _serialPorts = serialPorts;
        }

        public string[] SerialPorts
        {
            get
            {
                return _serialPorts;
            }
        }

        public EventType EventType
        {
            get
            {
                return _eventType;
            }
        }
    }

}

using BPSTool.BPSPacket;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace BPSTool
{
    public class BpsMng
    {
        private enum EnBPSParseStep
        {
            EN_BPS_PARSE_HEADER,
            EN_BPS_PARSE_VERSION,
            EN_BPS_PARSE_ADDR,
            EN_BPS_PARSE_RMN_LEN1,
            EN_BPS_PARSE_RMN_LEN2,
            EN_BPS_PARSE_DATA,
            EN_BPS_PARSE_CHKSUM,
        }

        public interface IReadonlyMsgList
        {
            List<byte> msgList { get; }
        }

        public class WritableMsgList : IReadonlyMsgList
        {
            public List<byte> msgList { get; }
            public WritableMsgList(List<byte> list)
            {
                msgList = new List<byte>(list);
            }
        }

        public delegate void DelUpdateUI_VV();

        public delegate void DelBPSRecvHandler(BaseBPSPacket baseBPSPacket);
        public delegate void DelUartErrorHandler();
        public delegate void DelBPSSendDebugHandler(IReadonlyMsgList msgList);
        public delegate void DelBPSRecvDebugHandler(IReadonlyMsgList msgList);

        private DelBPSRecvHandler bpsRecvHandler;
        private DelUartErrorHandler bpsErrorHandler;
        private SerialDataReceivedEventHandler serialDataReceivedEvent;
        private SerialErrorReceivedEventHandler serialErrorEvent;
        private DelBPSSendDebugHandler bpsSendDebugHandler;
        private DelBPSRecvDebugHandler bpsRecvDebugHandler;

        private UartMng uartMngObj;
        private EnBPSParseStep enBPSParseStep;
        private List<byte> RecvBuffer;
        private int remainLength;

        public BpsMng()
        {
            uartMngObj = UartMng.GetUartMngInstance();
            // bpsRecvHandler = BPSRecvIdleHandler;
            bpsErrorHandler = BPSErrorIdleHandler;
            bpsSendDebugHandler = null;
            bpsRecvDebugHandler = null;
            serialDataReceivedEvent = new SerialDataReceivedEventHandler(UartDataeceivedCallback);
            uartMngObj.ReadCallbackAdd(serialDataReceivedEvent);
            serialErrorEvent = new SerialErrorReceivedEventHandler(UartErrorCallback);
            uartMngObj.ErrorCallbackAdd(serialErrorEvent);
            RecvBuffer = new List<byte>();
            BpsHeaderClear();
            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
            remainLength = 0;
        }

        private void BpsHeaderClear()
        {
            RecvBuffer.Clear();
            RecvBuffer.Add(0);
        }

        private bool IsBPSChksumOK(List<byte> msg)
        {
            UInt16 len;
            int checksum;

            checksum = 0;
            for (int i = BpsUtils.BPSHeader.Length; i < msg.Count - 1; i++)
            {
                checksum += (msg[i] & 0xFF);
            }

            return (checksum & 0xFF) == (msg[msg.Count - 1] & 0xFF);
        }

        public bool SendBPSPacketReq(BaseBPSPacket baseBPSPacket)
        {
            bool ret = false;
            try
            {
                if (baseBPSPacket != null && uartMngObj.IsOpen())
                {
                    baseBPSPacket.RequestAssemble();
                    ret = uartMngObj.write(baseBPSPacket.MsgBuffer());
                    IReadonlyMsgList msgList = new WritableMsgList(new List<byte>(baseBPSPacket.MsgBuffer()));
                    bpsSendDebugHandler(msgList);
                }
            }
            catch (Exception e)
            {
                ret = false;
            }

            return ret;
        }

        public bool SendDebugData(List<byte> msg)
        {
            bool ret = false;
            try
            {
                if (msg != null && uartMngObj.IsOpen())
                {
                    ret = uartMngObj.write(msg.ToArray());
                    IReadonlyMsgList msgList = new WritableMsgList(new List<byte>(msg.ToArray()));
                    bpsSendDebugHandler(msgList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ret = false;
            }

            return ret;
        }

        private void UartDataeceivedCallback(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("data");
            byte[] buffer = new byte[uartMngObj.serialPort.BytesToRead];
            uartMngObj.serialPort.Read(buffer, 0, buffer.Length);
            List<byte> msg = new List<byte>(buffer);
            int parseIndex = 0;
            while(parseIndex < msg.Count)
            {
                if(BpsParseGeneral(msg, ref parseIndex))
                {
                    BaseBPSPacket baseBPSPacketRecv = BpsParse();
                    if (null != baseBPSPacketRecv && null != bpsRecvHandler)
                    {
                        bpsRecvHandler(baseBPSPacketRecv);
                    }
                }
            }
            if (null != bpsRecvDebugHandler)
            {
                IReadonlyMsgList msgList = new WritableMsgList(msg);
                bpsRecvDebugHandler(msgList);
            }
        }

        private void UartErrorCallback(object sender, SerialErrorReceivedEventArgs e)
        {
            bpsErrorHandler();
        }

        private bool BpsParseGeneral(List<Byte> msg, ref int index)
        {
            bool ret = false;
            int i;
            
            for (i = index; i < msg.Count; i++)
            {
                index = i+1;
                byte dataTmp = msg[i];
                switch (enBPSParseStep)
                {
                    case EnBPSParseStep.EN_BPS_PARSE_HEADER:
                        if (RecvBuffer[0] == BpsUtils.BPSHeader[0] && dataTmp == BpsUtils.BPSHeader[1])
                        {
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
                            BpsHeaderClear();
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
                        remainLength = ((RecvBuffer[RecvBuffer.Count - 2] & 0xFF) << 8) + (dataTmp & 0xFF);
                        if (remainLength < BpsUtils.BPS_CMD_WORD_SIZE)
                        {
                            BpsHeaderClear();
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
                        }
                        else
                        {
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_DATA;
                        }
                        break;
                    case EnBPSParseStep.EN_BPS_PARSE_DATA:
                        RecvBuffer.Add(dataTmp);
                        if (0 == --remainLength)
                        {
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_CHKSUM;
                        }
                        break;
                    case EnBPSParseStep.EN_BPS_PARSE_CHKSUM:
                        RecvBuffer.Add(dataTmp);
                        if (IsBPSChksumOK(RecvBuffer))
                        {
                            ret = true;
                            enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
                            return ret;
                        }
                        BpsHeaderClear();
                        enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
                        break;
                    default:
                        BpsHeaderClear();
                        enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
                        break;
                }
            }

            return ret;
        }

        private BaseBPSPacket BpsParse()
        {
            BaseBPSPacket ret = null;
            try
            {
                switch (RecvBuffer[BpsUtils.DATA_INDEX])
                {
                    case BPSPacketCommTest.RESPONSE_CMD:
                        {
                            ret = new BPSPacketCommTest();
                            ret.ResponseParse(ref RecvBuffer);
                            break;
                        }
                    case BPSPacketBaudrate.RESPONSE_CMD:
                        {
                            ret = new BPSPacketBaudrate();
                            ret.ResponseParse(ref RecvBuffer);
                            break;
                        }
                    case BPSPacketReset.RESPONSE_CMD:
                        {
                            ret = new BPSPacketReset();
                            ret.ResponseParse(ref RecvBuffer);
                            break;
                        }
                    case BPSPacketRestoreFac.RESPONSE_CMD:
                        {
                            ret = new BPSPacketRestoreFac();
                            ret.ResponseParse(ref RecvBuffer);
                            break;
                        }
                    case BPSPacketAddrSet.RESPONSE_CMD:
                        {
                            ret = new BPSPacketAddrSet();
                            ret.ResponseParse(ref RecvBuffer);
                            break;
                        }
                    /** System Parameter Commands */
                    case BPSPacketSysPara.RESPONSE_CMD:
                        {
                            ret = BPSPacketSysPara.CreateObj(ref RecvBuffer);
                            if (null != ret)
                            {
                                ret.ResponseParse(ref RecvBuffer);
                            }

                            break;
                        }
                }
            }
            catch (Exception e)
            {
                ret = null;
            }
            BpsHeaderClear();

            return ret;
        }

        public void BPSRecvIdleHandler(BaseBPSPacket baseBPSPacket)
        {
            /** do nothing */
        }

        public void BPSErrorIdleHandler()
        {
            /** do nothing */
        }

        public void AddRecvHandler(DelBPSRecvHandler del)
        {
            if(del != null)
            {
                bpsRecvHandler += del;
            }
        }

        public void RemoveRecvHandler(DelBPSRecvHandler del)
        {
            if (del != null)
            {
                bpsRecvHandler -= del;
            }
        }

        public void AddErrorHandler(DelUartErrorHandler del)
        {
            if (del != null)
            {
                bpsErrorHandler += del;
            }
        }

        public void RemoveErrorHandler(DelUartErrorHandler del)
        {
            if (del != null)
            {
                bpsErrorHandler -= del;
            }
        }

        public void AddSendDebugHandler(DelBPSSendDebugHandler del)
        {
            if (del != null)
            {
                bpsSendDebugHandler += del;
            }
        }

        public void RemoveSendDebugHandler(DelBPSSendDebugHandler del)
        {
            if (del != null)
            {
                bpsSendDebugHandler -= del;
            }
        }

        public void AddRecvDebugHandler(DelBPSRecvDebugHandler del)
        {
            if (del != null)
            {
                bpsRecvDebugHandler += del;
            }
        }

        public void RemoveRecvDebugHandler(DelBPSRecvDebugHandler del)
        {
            if (del != null)
            {
                bpsRecvDebugHandler -= del;
            }
        }

        public bool UartOpen(string port, int baudrate)
        {
            bool ret = false;

            try
            {
                enBPSParseStep = EnBPSParseStep.EN_BPS_PARSE_HEADER;
                BpsHeaderClear();

                uartMngObj.Baudrate = baudrate;
                ret = uartMngObj.Open(port);
            }
            catch(Exception e)
            {
                ret = false;
            }

            return ret;
        }

        public bool IsUartOpen()
        {
            return uartMngObj.IsOpen();
        }

        public void UartClose()
        {
            uartMngObj.Close();
        }

        public List<string> PortList()
        {
            return uartMngObj.PortList;
        }
    }
}

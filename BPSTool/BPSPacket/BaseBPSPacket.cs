using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool.BPSPacket
{
    abstract class BaseBPSPacket
    {
        protected List<Byte> sendBuffer;
        private int remainLenIndex;
        private int dataIndex;

        public BaseBPSPacket()
        {
            sendBuffer = new List<byte>();
            remainLenIndex = BpsUtils.BPSHeader.Length + BpsUtils.BPSVersion.Length + BpsUtils.BPSAddr.Length;
            dataIndex = remainLenIndex + BpsUtils.REMAIN_LEN_SIZE;
        }

        protected void PackHeader()
        {
            sendBuffer.Clear();
            BpsUtils.PackHeader(ref sendBuffer);
        }

        protected int PackRemainLen()
        {
            return BpsUtils.PackRemainLen(ref sendBuffer);
        }

        protected Byte CalcChecksum()
        {
            return BpsUtils.CalcChecksum(ref sendBuffer);
        }

        protected int ParseRemainLen(ref List<Byte> recvBuffer)
        {
            return BpsUtils.ParseRemainLen(ref recvBuffer);
        }

        public byte[] MsgBuffer()
        {
            return sendBuffer.ToArray();
        }

        public List<byte> MsgList()
        {
            return sendBuffer;
        }
        abstract public Byte RequestCmd { get; }
        abstract public Byte ResponseCmd { get; }
        public int RemainLenIndex { get => remainLenIndex; }
        public int DataIndex { get => dataIndex; set => dataIndex = value; }

        abstract public void RequestAssemble();
        abstract public bool RequestParse(ref List<Byte> request);
        abstract public void ResponseAssemble();
        abstract public bool ResponseParse(ref List<Byte> response);
    }
}

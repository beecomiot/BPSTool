using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool.BPSPacket
{
    abstract class BPSPacketSysPara : BaseBPSPacket
    {
        public enum CmdType
        {
            READ,
            WRITE,
        }

        public enum SysParaID
        {
            NAME,
            LINK_MAINTAIN_TIME,
            ADV_INTERVAL
        }

        public const byte REQUEST_CMD = 0xEE;
        public const byte RESPONSE_CMD = 0xEF;

        private CmdType cmdTypeSysPara = CmdType.READ;
        private SysParaID paraId;
        protected List<byte> data;
        protected byte responseCode;

        public override byte RequestCmd { get => REQUEST_CMD; }

        public override byte ResponseCmd { get => RESPONSE_CMD; }
        public CmdType CmdTypeSysPara { get => cmdTypeSysPara; set => cmdTypeSysPara = value; }
        public SysParaID ParaId { get => paraId; set => paraId = value; }

        public static BPSPacketSysPara CreateObj(ref List<byte> msg)
        {
            BPSPacketSysPara ret = null;

            try
            {
                int dataIndex = BpsUtils.DATA_INDEX + 2;
                switch(msg[dataIndex])
                {
                    case 0x00:
                        ret = new BPSPacketName();
                        break;
                    case 0x01:
                        ret = new BPSPacketLinkMaintainTime();
                        break;
                    case 0x02:
                        ret = new BPSPacketAdvInterval();
                        break;
                    default:
                        ret = null;
                        break;
                }
            }
            catch(Exception e)
            {
                ret = null;
            }

            return ret;
        }

        public void SetData(String d)
        {
            Encoding utf8 = Encoding.UTF8;
            byte[] bytes = utf8.GetBytes(d);
            data = new List<byte>(bytes);
        }

        abstract public override void RequestAssemble();
       

        public override bool RequestParse(ref List<byte> request)
        {
            throw new NotImplementedException();
        }

        public override void ResponseAssemble()
        {
            throw new NotImplementedException();
        }

        abstract public override bool ResponseParse(ref List<byte> response);
    }
}

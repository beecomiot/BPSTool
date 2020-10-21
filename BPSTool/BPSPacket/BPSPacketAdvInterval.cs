using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool.BPSPacket
{
    class BPSPacketAdvInterval : BPSPacketSysPara
    {
        public const int MAX_NAME_LEN = 20;

        public const byte SYS_PARA_ID = 0x02;

        private UInt32 advInterval;

        public BPSPacketAdvInterval()
        {
            ParaId = SysParaID.ADV_INTERVAL;
            data = new List<byte>();
            advInterval = 0;
        }

        public uint AdvInterval { get => advInterval; set => advInterval = value; }

        public override void RequestAssemble()
        {
            try
            {
                /** pack header */
                PackHeader();

                /** pack request command word */
                sendBuffer.Add(RequestCmd);

                ///** pack request data */
                switch (CmdTypeSysPara)
                {
                    case CmdType.READ:
                        sendBuffer.Add(0x00);
                        sendBuffer.Add(SYS_PARA_ID);
                        break;
                    case CmdType.WRITE:
                        sendBuffer.Add(0x01);
                        sendBuffer.Add(SYS_PARA_ID);

                        sendBuffer.Add(2); // sizeof UINT16

                        sendBuffer.Add((byte)((advInterval >> 8) & 0xFF));
                        sendBuffer.Add((byte)((advInterval >> 0) & 0xFF));
                        break;
                }

                /** pack remain length */
                int remainLen = PackRemainLen();

                /** pack checksum */
                Byte checksum = CalcChecksum();
                sendBuffer.Add(checksum);
            }
            catch
            {

            }
        }

        public override bool ResponseParse(ref List<byte> response)
        {
            bool ret = true;

            int dataIndex = BpsUtils.DATA_INDEX + 1;

            try
            {
                byte tmp = response[dataIndex++];
                if (1 == tmp)
                {
                    CmdTypeSysPara = CmdType.WRITE;
                }
                else
                {
                    CmdTypeSysPara = CmdType.READ;
                }

                tmp = response[dataIndex++];
                if (tmp == SYS_PARA_ID)
                {
                    ParaId = SysParaID.ADV_INTERVAL;
                }

                responseCode = response[dataIndex++];

                if (CmdTypeSysPara == CmdType.READ && 0 == responseCode)
                {
                    int len = response[dataIndex++] & 0xFF;
                    advInterval = 0;
                    if (2 != len)
                    {
                        return false;
                    }
                    advInterval = (advInterval << 8) + (UInt16)(response[dataIndex++] & 0xFF);
                    advInterval = (advInterval << 8) + (UInt16)(response[dataIndex++] & 0xFF);
                }
            }
            catch (Exception e)
            {
                ret = false;
            }

            return ret;
        }

        public override string ToString()
        {
            return advInterval.ToString();
        }
    }
}

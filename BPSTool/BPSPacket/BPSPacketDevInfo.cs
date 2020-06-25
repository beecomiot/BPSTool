using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool.BPSPacket
{
    class BPSPacketDevInfo : BaseBPSPacket
    {
        public const byte REQUEST_CMD = 0x02;
        public const byte RESPONSE_CMD = 0x03;

        private Dictionary<byte, List<byte>> dataMap;

        public BPSPacketDevInfo()
        {
            this.dataMap = new Dictionary<byte, List<byte>>();
        }

        public override byte RequestCmd { get => REQUEST_CMD; }

        public override byte ResponseCmd { get => RESPONSE_CMD; }

        public override void RequestAssemble()
        {
            /** pack header */
            PackHeader();

            /** pack request command word */
            sendBuffer.Add(RequestCmd);

            ///** pack request data */

            /** pack remain length */
            int remainLen = PackRemainLen();

            /** pack checksum */
            Byte checksum = CalcChecksum();
            sendBuffer.Add(checksum);
        }

        public override bool RequestParse(ref List<byte> request)
        {
            throw new NotImplementedException();
        }

        public override void ResponseAssemble()
        {
            throw new NotImplementedException();
        }

        public override bool ResponseParse(ref List<byte> response)
        {
            bool ret = true;

            int dataIndex = BpsUtils.DATA_INDEX + 1;

            try
            {
                int num = response[dataIndex++] & 0xFF;
                for(int i = 0; i < num; i++)
                {
                    byte type = response[dataIndex++];
                    int len = response[dataIndex++] & 0xFF;
                    List<byte> data = new List<byte>();
                    data.Clear();
                    for(int j = 0; j < len; j++)
                    {
                        data.Add(response[dataIndex++]);
                    }
                    dataMap.Add(type, data);
                }
            }
            catch (Exception e)
            {
                ret = false;
            }

            return ret;
        }
    }
}

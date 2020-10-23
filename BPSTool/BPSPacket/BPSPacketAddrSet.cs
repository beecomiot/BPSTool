using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool.BPSPacket
{
    class BPSPacketAddrSet : BaseBPSPacket
    {

        public const byte REQUEST_CMD = 0x12;
        public const byte RESPONSE_CMD = 0x13;

        public override byte RequestCmd { get => REQUEST_CMD; }

        public override byte ResponseCmd { get => RESPONSE_CMD; }

        private static byte[] safeWord = { 0xCC, 0xBB };
        public static byte[] SafeWord { get => safeWord; }

        public byte ResponseCode { get => responseCode; set => responseCode = value; }
        public byte Addr { get => addr; set => addr = value; }

        private byte addr;
        private byte responseCode;



        public override void RequestAssemble()
        {
            /** pack header */
            PackHeader();

            /** pack request command word */
            sendBuffer.Add(RequestCmd);

            ///** pack request data */
            sendBuffer.AddRange(safeWord);
            sendBuffer.Add((byte)(Addr & 0x0f));

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
                responseCode = response[dataIndex++];
            }
            catch (Exception e)
            {
                ret = false;
            }

            return ret;
        }
    }
}

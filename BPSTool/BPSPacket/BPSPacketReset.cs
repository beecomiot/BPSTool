using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool.BPSPacket
{
    class BPSPacketReset : BaseBPSPacket
    {
        public const byte REQUEST_CMD = 0x0E;
        public const byte RESPONSE_CMD = 0x0F;

        private byte responseCode;
        private static byte[] safeWord = { 0xBC, 0xBC };
        public static byte[] SafeWord { get => safeWord; }

        public override byte RequestCmd { get => 0x0E; }

        public override byte ResponseCmd { get => 0x0F; }

        public override void RequestAssemble()
        {
            /** pack header */
            PackHeader();

            /** pack request command word */
            sendBuffer.Add(RequestCmd);

            ///** pack request data */
            //deviceType = BpsUtils.DEVICE_TYPE_C;
            sendBuffer.AddRange(safeWord);

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

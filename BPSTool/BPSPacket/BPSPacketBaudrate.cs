using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool.BPSPacket
{
    class BPSPacketBaudrate : BaseBPSPacket
    {
        public enum CmdType
        {
            READ,
            WRITE,
        }

        public const byte REQUEST_CMD = 0x04;
        public const byte RESPONSE_CMD = 0x05;

        private CmdType cmdTypeBaudrate = CmdType.READ;
        private UInt32 baudrate;
        private byte responseCode;

        public override byte RequestCmd { get => REQUEST_CMD; }

        public override byte ResponseCmd { get => RESPONSE_CMD; }
        public uint Baudrate { get => baudrate; set => baudrate = value; }
        public CmdType CmdTypeBaudrate { get => cmdTypeBaudrate; set => cmdTypeBaudrate = value; }
        public byte ResponseCode { get => responseCode; set => responseCode = value; }

        public override void RequestAssemble()
        {
            /** pack header */
            PackHeader();

            /** pack request command word */
            sendBuffer.Add(RequestCmd);

            ///** pack request data */
            switch (cmdTypeBaudrate)
            {
                case CmdType.READ:
                    sendBuffer.Add(0);
                    break;
                case CmdType.WRITE:
                    sendBuffer.Add(1);
                    sendBuffer.Add((byte)((baudrate >> 24)&0xFF));
                    sendBuffer.Add((byte)((baudrate >> 16) & 0xFF));
                    sendBuffer.Add((byte)((baudrate >> 8) & 0xFF));
                    sendBuffer.Add((byte)((baudrate >> 0) & 0xFF));
                    break;
            }


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

            int dataIndex = BpsUtils.DATA_INDEX+1;

            try
            {
                baudrate = 0;
                responseCode = response[dataIndex++];
                baudrate = (baudrate << 8) + (UInt32)(response[dataIndex++] & 0xFF);
                baudrate = (baudrate << 8) + (UInt32)(response[dataIndex++] & 0xFF);
                baudrate = (baudrate << 8) + (UInt32)(response[dataIndex++] & 0xFF);
                baudrate = (baudrate << 8) + (UInt32)(response[dataIndex++] & 0xFF);
            }
            catch(Exception e)
            {

            }

            return ret;
        }
    }
}

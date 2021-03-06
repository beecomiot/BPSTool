﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool.BPSPacket
{
    class BPSPacketCommTest : BaseBPSPacket
    {
        public const byte REQUEST_CMD = 0x00;
        public const byte RESPONSE_CMD = 0x01;

        private byte deviceType;
        public byte DeviceType { get => deviceType; set => deviceType = value; }

        public override byte RequestCmd { get => REQUEST_CMD; }

        public override byte ResponseCmd { get => RESPONSE_CMD; }

        public override void RequestAssemble()
        {
            /** pack header */
            PackHeader();

            /** pack request command word */
            sendBuffer.Add(RequestCmd);

            ///** pack request data */
            //deviceType = BpsUtils.DEVICE_TYPE_C;
            //sendBuffer.Add(deviceType);

            /** pack remain length */
            int remainLen = PackRemainLen();

            /** pack checksum */
            Byte checksum = CalcChecksum();
            sendBuffer.Add(checksum);

        }

        public override bool RequestParse(ref List<byte> request)
        {
            bool ret = true;

            try
            {
                int remainLen = ParseRemainLen(ref request);
                deviceType = request[DataIndex];
            }
            catch(Exception e)
            {
                ret = false;
            }

            return ret;
        }

        public override void ResponseAssemble()
        {
            PackHeader();
            /** TODO: test response logic */
            int remainLen = PackRemainLen();
            Byte checksum = CalcChecksum();
        }

        public override bool ResponseParse(ref List<byte> response)
        {
            bool ret = true;

            return ret;
        }
    }
}

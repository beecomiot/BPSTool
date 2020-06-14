﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool
{
    class BpsUtils
    {
        private static int hostAddress;
        private static int moduleAddress;
        private static byte[] bpsHeader = { 0xBB, 0xCC };
        private static byte[] bpsVersion = { 0x00 };

        public const byte DEVICE_TYPE_B = (byte)'B';
        public const byte DEVICE_TYPE_T = (byte)'T';
        public const byte DEVICE_TYPE_C = (byte)'C';

        public static int HostAddress { get => hostAddress; set => hostAddress = value; }
        public static int ModuleAddress { get => moduleAddress; set => moduleAddress = value; }
        private static byte[] bpsAddr = { (byte)((HostAddress << 4) | ModuleAddress) };

        public static byte[] BPSHeader { get => bpsHeader; }
        public static byte[] BPSVersion { get => bpsVersion; }
        public static byte[] BPSAddr { get => bpsAddr; }
        public const int REMAIN_LEN_SIZE = 2;

        public static void PackHeader(ref List<Byte> buf)
        {

            buf.AddRange(BPSHeader);
            buf.AddRange(BPSVersion);
            buf.AddRange(BPSAddr);

            for (int i = 0; i < REMAIN_LEN_SIZE; i++)
            {
                buf.Add(0x00);
            }

        }

        public static int PackRemainLen(ref List<Byte> buf)
        {
            int ret = 0;
            int remainLenIndex = BPSHeader.Length + BPSVersion.Length + BPSAddr.Length;

            try
            {
                ret = buf.Count - remainLenIndex - REMAIN_LEN_SIZE;
                if(ret >= 0)
                {
                    buf[remainLenIndex++] = (byte)((ret >> 8) & 0xFF);
                    buf[remainLenIndex] = (byte)(ret & 0xFF);
                }
            }
            catch(Exception e)
            {
                ret = 0;
            }

            return ret;
        }

        public static int ParseRemainLen(ref List<Byte> mesage)
        {
            int ret = 0;
            int remainLenIndex = BPSHeader.Length + BPSVersion.Length + BPSAddr.Length;

            try
            {
                ret = (mesage[remainLenIndex] & 0xFF) << 8;
                ret += mesage[remainLenIndex] & 0xFF;
            }
            catch(Exception e)
            {
                ret = 0;
            }

            return ret;
        }

        public static Byte CalcChecksum(ref List<Byte> buf)
        {
            int ret = 0;

            try
            {
                for (int i = BPSHeader.Length; i < buf.Count; i++)
                {
                    ret += (buf[i] & 0xFF);
                }
            }
            catch(Exception e)
            {

            }

            return (byte)(ret & 0xFF);
        }
    }
}
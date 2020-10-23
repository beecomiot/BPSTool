using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool
{
    class BpsUtils
    {
        public static int DEFAULT_MASTER_ADDR = 0;
        public static int DEFAULT_MODULE_ADDR = 1;
        private static int hostAddress = DEFAULT_MASTER_ADDR;
        private static int moduleAddress = DEFAULT_MODULE_ADDR;
        private static byte[] bpsHeader = { 0xBB, 0xCC };
        private static byte[] bpsVersion = { 0x00 };

        private static int[] stdBaudrate = { 9600, 19200, 38400, 57600, 115200};

        public const byte DEVICE_TYPE_B = (byte)'B';
        public const byte DEVICE_TYPE_T = (byte)'T';
        public const byte DEVICE_TYPE_C = (byte)'C';

        public static int HostAddress { get => hostAddress; set => hostAddress = value; }
        public static int ModuleAddress { get => moduleAddress; set => moduleAddress = value; }
        private static byte[] bpsAddr = { (byte)((HostAddress << 4) | ModuleAddress) };

        public static byte[] BPSHeader { get => bpsHeader; }
        public static byte[] BPSVersion { get => bpsVersion; }
        public static byte[] BPSAddr { get => bpsAddr; }
        public static int[] StdBaudrate { get => stdBaudrate; }

        public const int REMAIN_LEN_SIZE = 2;
        public const int BPS_CMD_WORD_SIZE = 1;

        public static int REMAIN_LEN_INDEX = BPSHeader.Length + BpsUtils.BPSVersion.Length + BpsUtils.BPSAddr.Length;
        public static int DATA_INDEX = REMAIN_LEN_INDEX + BpsUtils.REMAIN_LEN_SIZE;

        public static int MAX_ADDR = 0xE;
        public static int MIN_ADDR = 0x0;

        public static void updateBpsAddr(int masterAddr, int slaveAddr)
        {
            if(masterAddr == slaveAddr)
            {
                return;
            }
            if(masterAddr < MIN_ADDR || masterAddr > MAX_ADDR)
            {
                return;
            }
            if (slaveAddr < MIN_ADDR || slaveAddr > MAX_ADDR)
            {
                return;
            }
            HostAddress = masterAddr;
            ModuleAddress = slaveAddr;
            BPSAddr[0] = (byte)((HostAddress << 4) | ModuleAddress);
        }

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

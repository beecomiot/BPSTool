using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPSTool.BPSPacket
{
    class BPSPacketName : BPSPacketSysPara
    {
        public const int MAX_NAME_LEN = 20;

        public const byte SYS_PARA_ID = 0x00;

        private string name;

        public BPSPacketName()
        {
            ParaId = SysParaID.NAME;
            data = new List<byte>();
            name = "BC1110";
        }

       

        public string Name { get => name; set => name = value; }

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
                        if(0 == data.Count || data.Count > MAX_NAME_LEN)
                        {
                            return;
                        }
                        sendBuffer.Add((byte)(data.Count & 0xFF));
                        sendBuffer.AddRange(data);
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
                if (tmp == 0)
                {
                    ParaId = SysParaID.NAME;
                }

                responseCode = response[dataIndex++];

                if(CmdTypeSysPara == CmdType.READ && 0 == responseCode)
                {
                    data.Clear();
                    int len = response[dataIndex++] & 0xFF;
                    for(int i = 0; i < len; i++)
                    {
                        data.Add(response[dataIndex++]);
                    }

                    name = System.Text.Encoding.UTF8.GetString(data.ToArray());
                }

            }
            catch (Exception e)
            {

            }

            return ret;
        }

        public override string ToString()
        {
            return name;
        }
    }
}

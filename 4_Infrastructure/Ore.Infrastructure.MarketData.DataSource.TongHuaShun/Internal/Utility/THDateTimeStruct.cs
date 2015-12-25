using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct THDateTimeStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private readonly byte[] data;

        internal DateTime Value
        {
            get { return ByteToDateTime(data); }
        }

        internal int IntValue
        {
            get { return BitConverter.ToInt32(data, 0); }
        }

        private static DateTime ByteToDateTime(byte[] data)
        {
            DateTime dt;

            int intValue = BitConverter.ToInt32(data, 0);
            if(intValue > 19600101 && intValue < 21000101)
            {
                dt = IntToDateTime(intValue);
            }
            else
            {
                uint value = BitConverter.ToUInt32(data, 0);

                int min = Convert.ToInt32(value & 0x3F);
                value = value >> 0x6;

                int hour = Convert.ToInt32(value & 0x1F);
                value = value >> 0x5;

                int day = Convert.ToInt32(value & 0x1F);
                value = value >> 0x5;

                int month = Convert.ToInt32(value & 0xF);
                value = value >> 0x4;

                int year = Convert.ToInt32((value & 0xFFF)) + 1900;

                dt = new DateTime(year, month, day, hour, min, 0);
            }
            return dt;
            /*
            数据块开头是4个字节时间例如：DE 62 03 07
先倒顺序  070362DE 转而二进制 111 0000 0011 0110 0010 1101 1110
从低位到高位：
    6bit 分钟
    5bit 时
    5bit 日
    4bit 月
    12bit 年减去1900后的数值，所以解析的时候要再加上
变为
1110000 0011 01100 01011 011110  分别是112+1900=2012年  3月 12日  11时 30分
            */
        }

        private static DateTime IntToDateTime(int value)
        {
            return new DateTime(value / 10000, (value % 10000) / 100, value % 100);
        }
    }
}

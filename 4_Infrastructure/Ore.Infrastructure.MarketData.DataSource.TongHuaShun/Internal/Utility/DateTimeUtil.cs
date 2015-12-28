using System;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal static class DateTimeUtil
    {
        public static DateTime ConvertToDailyDateTime(byte[] byteArray)
        {
            int intValue = BitConverter.ToInt32(byteArray, 0);
            if(intValue < 10000)
            {
                return DateTime.MinValue;
            }
            else
            {
                return new DateTime(intValue / 10000, (intValue % 10000) / 100, intValue % 100);
            }
        }

        public static DateTime ConverterToMinDateTime(byte[] byteArray)
        {
            uint value = BitConverter.ToUInt32(byteArray, 0);

            int min = Convert.ToInt32(value & 0x3F);
            value = value >> 0x6;

            int hour = Convert.ToInt32(value & 0x1F);
            value = value >> 0x5;

            int day = Convert.ToInt32(value & 0x1F);
            value = value >> 0x5;

            int month = Convert.ToInt32(value & 0xF);
            value = value >> 0x4;

            int year = Convert.ToInt32((value & 0xFFF)) + 1900;

            return new DateTime(year, month, day, hour, min, 0);
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
    }
}

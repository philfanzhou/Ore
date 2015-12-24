using System;
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
                dt = DateTime.MinValue;
            }
            return dt;

            /*
            201512231500 121420736 143 

            201512220935 121418339  48

            201512211500 121416640  47

            201512211400 121416576  35

            201512210935 121416291  0 
            */
        }

        private static DateTime IntToDateTime(int value)
        {
            return new DateTime(value / 10000, (value % 10000) / 100, value % 100);
        }
    }
}

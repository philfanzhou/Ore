using System.Runtime.InteropServices;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    /// <summary>
    /// 同花顺的个股数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal class THKLineStockDay : THKLine
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] w1;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] w2;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] w3;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] w4;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] w5;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
        private byte[] otherData;

        internal double W1
        {
            get { return GetValue(w1); }
        }

        internal double W2
        {
            get { return GetValue(w2); }
        }

        internal double W3
        {
            get { return GetValue(w3); }
        }

        internal double W4
        {
            get { return GetValue(w4); }
        }

        internal double W5
        {
            get { return GetValue(w5); }
        }
    }
}

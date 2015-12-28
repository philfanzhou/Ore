using System;
using System.Runtime.InteropServices;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    [StructLayout(LayoutKind.Sequential)]
    internal class THKLineStockMin : THKLine
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 108)]
        private byte[] otherData;

        public override DateTime Time
        {
            get
            {
                return DateTimeUtil.ConverterToMinDateTime(base.date);
            }
        }
    }
}

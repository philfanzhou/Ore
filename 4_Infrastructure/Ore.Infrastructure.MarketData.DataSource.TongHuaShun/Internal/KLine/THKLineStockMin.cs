using System.Runtime.InteropServices;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    [StructLayout(LayoutKind.Sequential)]
    internal class THKLineStockMin : THKLine
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 112)]
        private byte[] otherData;
    }
}

using System.Runtime.InteropServices;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    /// <summary>
    /// 同花顺的个股数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal class THKLineStockDay : THKLine
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 140)]
        private byte[] otherData;
    }
}

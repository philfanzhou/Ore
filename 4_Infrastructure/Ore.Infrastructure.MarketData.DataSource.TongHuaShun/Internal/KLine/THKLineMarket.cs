using System.Runtime.InteropServices;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    /// <summary>
    /// 同花顺的板块K线数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal class THKLineMarket : THKLine
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 136)]
        private byte[] otherData;
    }
}

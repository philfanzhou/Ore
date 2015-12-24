using System.Collections.Generic;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    public interface ITongHuaShunReader
    {
        /// <summary>
        /// 获取日线数据
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<IStockKLine> GetKLine(string stockCode, KLineType type);

        /// <summary>
        /// 获取分红配股数据
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        IDividendData GetDividendData(string stockCode);
    }
}

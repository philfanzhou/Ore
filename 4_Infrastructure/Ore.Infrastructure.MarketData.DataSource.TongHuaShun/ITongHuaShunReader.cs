using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    public interface ITongHuaShunReader
    {
        /// <summary>
        /// 获取日线数据
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        IEnumerable<IStockKLine> GetKLineDay(string stockCode);

        /// <summary>
        /// 获取分红配股数据
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        IDividendData GetDividendData(string stockCode);
    }
}

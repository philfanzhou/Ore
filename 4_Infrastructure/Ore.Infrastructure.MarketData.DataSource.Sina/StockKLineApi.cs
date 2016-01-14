using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    public class StockKLineApi
    {
        public IEnumerable<IStockKLine> GetLatest(IEnumerable<string> stockCodes)
        {
            // 每天下午3点20之后，调用StockRealTimeApi.GetData(IEnumerable<string> stockCodes)，
            // 就可以获取到当天的日线K线。
            throw new NotImplementedException();
        }
    }
}

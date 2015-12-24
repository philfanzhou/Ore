using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal class DataReaderV2 : ITongHuaShunReader
    {
        public IEnumerable<IStockKLine> GetKLine(string stockCode, KLineType type)
        {
            string filePath = PathHelper.GetKLineFilePath(stockCode, Market.XSHG, type);
            if (!File.Exists(filePath))
            {
                filePath = PathHelper.GetKLineFilePath(stockCode, Market.XSHE, type);
            }

            if (!File.Exists(filePath))
            {
                return null;
            }

            var file = new KLineFile(filePath);
            return file.GetItems(DateTime.MinValue);
        }

        public IDividendData GetDividendData(string stockCode)
        {
            DataReader reader = new DataReader();
            reader.AnalyseDividendFile(PathHelper.Dividend);
            return reader.GetDividendData(stockCode, DateTime.MinValue);
        }
    }
}

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
        private readonly PathHelper _pathHelper;

        public DataReaderV2(string dataFolder)
        {
            _pathHelper = new PathHelper(dataFolder);
        }

        public IEnumerable<IStockKLine> GetKLineDay(string stockCode)
        {
            DataReader reader = new DataReader();
            reader.AnalyseDayLineFiles(
                new[]
                {
                    _pathHelper.ShangHaiDay,
                    _pathHelper.ShenZhenDay
                });

            return reader.GetDaylineData(stockCode, DateTime.MinValue);
        }

        public IDividendData GetDividendData(string stockCode)
        {
            DataReader reader = new DataReader();
            reader.AnalyseDividendFile(_pathHelper.Dividend);
            return reader.GetDividendData(stockCode, DateTime.MinValue);
        }
    }
}

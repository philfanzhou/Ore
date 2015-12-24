using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal class DayLineFile : FileBase
    {
        public DayLineFile(string filePath)
            : base(filePath){}

        public string GetStockSymbol()
        {
            return Path.GetFileNameWithoutExtension(base.FilePath);
        }

        public IEnumerable<IStockKLine> GetItems(DateTime startTime)
        {
            return base.GetItems<IStockKLine>().Where(d => d.Time > startTime);
        }

        protected override IEnumerable<T> DoGetItems<T>(BinaryReader reader, THFileHeader header)
        {
            List<IStockKLine> result = new List<IStockKLine>();

            if (header.RecordLength == 164)
            {
                //读取板块K线数据
                THKLineMarket[] marketData = StructUtil<THKLineMarket>.ReadStructArray(reader, header.RecordCount);
                result.AddRange(marketData);
            }
            else if (header.RecordLength == 168)
            {
                //读取个股K线数据
                THKLineStock[] stockData = StructUtil<THKLineStock>.ReadStructArray(reader, header.RecordCount);
                result.AddRange(stockData);
            }

            return result.Cast<T>();
        }
    }
}
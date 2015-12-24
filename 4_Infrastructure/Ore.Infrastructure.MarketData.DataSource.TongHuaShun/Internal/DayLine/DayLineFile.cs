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

        public IKlineData GetData(DateTime startTime)
        {
            DayLineInfo info = new DayLineInfo();
            info.Symbol = this.GetStockSymbol();
            info.Items = this.GetItems().Where(d => d.Date > startTime).ToList();

            return info;
        }

        private List<IKlineItem> GetItems()
        {
            using (FileStream stream = File.OpenRead(base.FilePath))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    THFileHeader header = StructUtil<THFileHeader>.BytesToStruct(reader.ReadBytes(THFileHeader.StructSize));
                    THColumnHeader[] columnList = StructUtil<THColumnHeader>.ReadStructArray(reader, header.FieldCount);

                    return DoGetItems(reader, header);
                }
            }
        }

        private static List<IKlineItem> DoGetItems(BinaryReader reader, THFileHeader header)
        {
            List<IKlineItem> result = new List<IKlineItem>();

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

            return result;
        }

        protected override IEnumerable<T> DoGetItems<T>(BinaryReader reader, THFileHeader header)
        {
            List<IKlineItem> result = new List<IKlineItem>();

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
using System.Collections.Generic;
using System.Linq;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    public class StockKLineApi
    {
        public IStockKLine GetLatest(string stockCode)
        {
            StockRealTimeApi reader = new StockRealTimeApi();
            IStockRealTime data = reader.GetData(stockCode);
            return GetDataFromStockRealTime(data);
        }

        public IEnumerable<IStockKLine> GetLatest(IEnumerable<string> stockCodes)
        {
            StockRealTimeApi reader = new StockRealTimeApi();
            List<IStockRealTime> stockRealTimeDatas = reader.GetData(stockCodes).ToList();

            List<StockKLine> datas = new List<StockKLine>();
            foreach(var it in stockRealTimeDatas)
            {
                datas.Add(GetDataFromStockRealTime(it));
            }

            return datas;
        }

        private StockKLine GetDataFromStockRealTime(IStockRealTime stockRealTimeData)
        {
            StockKLine data = new StockKLine();
            // 日期与时间
            data.Time = stockRealTimeData.Time;
            // 今开
            data.Open = stockRealTimeData.TodayOpen;
            // 最高
            data.High = stockRealTimeData.High;
            // 最低
            data.Low = stockRealTimeData.Low;
            // 收盘
            data.Close = stockRealTimeData.Current;
            // 成交量
            data.Volume = stockRealTimeData.Volume;
            // 成交额
            data.Amount = stockRealTimeData.Amount;

            return data;
        }        
    }
}

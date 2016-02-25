using System.Collections.Generic;
using System.Linq;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    public class StockKLineDayApi
    {
        public IStockKLine GetLatest(string stockCode)
        {
            StockRealTimeApi reader = new StockRealTimeApi();
            IStockRealTime realTimeData = reader.GetData(stockCode);

            if (IsKLineDay(realTimeData))
            {
                return ConvertToDayLine(realTimeData);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<KeyValuePair<string, IStockKLine>> GetLatest(IEnumerable<string> stockCodes)
        {
            StockRealTimeApi reader = new StockRealTimeApi();
            var realTimeDatas = reader.GetData(stockCodes).ToList();

            Dictionary<string, IStockKLine> result = new Dictionary<string, IStockKLine>();
            foreach(var item in realTimeDatas)
            {
                if (IsKLineDay(item.Value))
                {
                    result.Add(item.Key, ConvertToDayLine(item.Value));
                }
            }

            return result;
        }

        private bool IsKLineDay(IStockRealTime realTimeData)
        {
            if(null == realTimeData)
            {
                return false;
            }

            // 今天未开盘
            if(realTimeData.TodayOpen - 0 < 0.000001)
            {
                return false;
            }

            return true;
        }

        private StockKLine ConvertToDayLine(IStockRealTime realTimeData)
        {
            StockKLine data = new StockKLine();
            // 日期与时间
            data.Time = realTimeData.Time.Date;
            // 今开
            data.Open = realTimeData.TodayOpen;
            // 最高
            data.High = realTimeData.High;
            // 最低
            data.Low = realTimeData.Low;
            // 收盘
            data.Close = realTimeData.Current;
            // 成交量
            data.Volume = realTimeData.Volume;
            // 成交额
            data.Amount = realTimeData.Amount;

            return data;
        }        
    }
}

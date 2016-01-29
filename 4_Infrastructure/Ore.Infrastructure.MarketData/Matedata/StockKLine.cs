using System;
using System.Collections.Generic;
using System.Linq;

namespace Ore.Infrastructure.MarketData
{
    public class StockKLine : IStockKLine
    {
        public double Amount { get; set; }

        public double Close { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Open { get; set; }

        public DateTime Time { get; set; }

        public double Volume { get; set; }
    }

    public static class KLineConverter
    {
        public static IEnumerable<StockKLine> ToDataObject(this IEnumerable<IStockKLine> self)
        {
            return self.Select(p => p.ToDataObject());
        }

        public static StockKLine ToDataObject(this IStockKLine self)
        {
            StockKLine outputData = new StockKLine
            {
                //
                // 摘要:
                //     成交额
                Amount = self.Amount,
                //
                // 摘要:
                //     收盘
                Close = self.Close,
                //
                // 摘要:
                //     最高
                High = self.High,
                //
                // 摘要:
                //     最低
                Low = self.Low,
                //
                // 摘要:
                //     今开
                Open = self.Open,
                //
                // 摘要:
                //     日期与时间
                Time = self.Time,
                //
                // 摘要:
                //     成交量
                Volume = self.Volume
            };

            return outputData;
        }
    }
}

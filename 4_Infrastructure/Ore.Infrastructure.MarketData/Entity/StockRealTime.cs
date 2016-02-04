using System.Collections.Generic;
using System.Linq;

namespace Ore.Infrastructure.MarketData
{
    public class StockRealTime : TimeSeries, IStockRealTime
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 交易市场
        /// </summary>
        public Market Market { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 今开
        /// </summary>
        public double TodayOpen { get; set; }

        /// <summary>
        /// 昨收
        /// </summary>
        public double YesterdayClose { get; set; }

        /// <summary>
        /// 成交价
        /// </summary>
        public double Current { get; set; }

        /// <summary>
        /// 最高
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// 最低
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        public double Amount { get; set; }

        #region 卖五
        /// <summary>
        /// 卖五价
        /// </summary>
        public double Sell5Price { get; set; }

        /// <summary>
        /// 卖五量
        /// </summary>
        public double Sell5Volume { get; set; }

        /// <summary>
        /// 卖四价
        /// </summary>
        public double Sell4Price { get; set; }

        /// <summary>
        /// 卖四量
        /// </summary>
        public double Sell4Volume { get; set; }

        /// <summary>
        /// 卖三价
        /// </summary>
        public double Sell3Price { get; set; }

        /// <summary>
        /// 卖三量
        /// </summary>
        public double Sell3Volume { get; set; }

        /// <summary>
        /// 卖二价
        /// </summary>
        public double Sell2Price { get; set; }

        /// <summary>
        /// 卖二量
        /// </summary>
        public double Sell2Volume { get; set; }

        /// <summary>
        /// 卖一价
        /// </summary>
        public double Sell1Price { get; set; }

        /// <summary>
        /// 卖一量
        /// </summary>
        public double Sell1Volume { get; set; }
        #endregion

        #region 买五
        /// <summary>
        /// 买一价
        /// </summary>
        public double Buy1Price { get; set; }

        /// <summary>
        /// 买一量
        /// </summary>
        public double Buy1Volume { get; set; }

        /// <summary>
        /// 买二价
        /// </summary>
        public double Buy2Price { get; set; }

        /// <summary>
        /// 买二量
        /// </summary>
        public double Buy2Volume { get; set; }

        /// <summary>
        /// 买三价
        /// </summary>
        public double Buy3Price { get; set; }

        /// <summary>
        /// 买三量
        /// </summary>
        public double Buy3Volume { get; set; }

        /// <summary>
        /// 买四价
        /// </summary>
        public double Buy4Price { get; set; }

        /// <summary>
        /// 买四量
        /// </summary>
        public double Buy4Volume { get; set; }

        /// <summary>
        /// 买五价
        /// </summary>
        public double Buy5Price { get; set; }

        /// <summary>
        /// 买五量
        /// </summary>
        public double Buy5Volume { get; set; }
        #endregion
    }

    public static class StockRealTimeConverter
    {
        public static IEnumerable<StockRealTime> ToDataObject(this IEnumerable<IStockRealTime> self)
        {
            return self.Select(p => p.ToDataObject());
        }

        public static StockRealTime ToDataObject(this IStockRealTime self)
        {
            StockRealTime outputData = new StockRealTime
            {
                Buy1Price = self.Buy1Price,
                Buy1Volume = self.Buy1Volume,
                Buy2Price = self.Buy2Price,
                Buy2Volume = self.Buy2Volume,
                Buy3Price = self.Buy3Price,
                Buy3Volume = self.Buy3Volume,
                Buy4Price = self.Buy4Price,
                Buy4Volume = self.Buy4Volume,
                Buy5Price = self.Buy5Price,
                Buy5Volume = self.Buy5Volume,

                Sell1Price = self.Sell1Price,
                Sell1Volume = self.Sell1Volume,
                Sell2Price = self.Sell2Price,
                Sell2Volume = self.Sell2Volume,
                Sell3Price = self.Sell3Price,
                Sell3Volume = self.Sell3Volume,
                Sell4Price = self.Sell4Price,
                Sell4Volume = self.Sell4Volume,
                Sell5Price = self.Sell5Price,
                Sell5Volume = self.Sell5Volume,

                Amount = self.Amount,
                ShortName = self.ShortName,
                Code = self.Code,
                Current = self.Current,
                High = self.High,
                Low = self.Low,
                Market = self.Market,
                Time = self.Time,
                TodayOpen = self.TodayOpen,
                Volume = self.Volume,
                YesterdayClose = self.YesterdayClose
            };

            return outputData;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Ore.Infrastructure.MarketData
{
    public class StockIntraday : IStockIntraday
    {
        public double Amount { get; set; }

        public double AveragePrice { get; set; }

        public double BuyVolume { get; set; }

        public double Current { get; set; }

        public double SellVolume { get; set; }

        public DateTime Time { get; set; }

        public double Volume { get; set; }

        public double YesterdayClose { get; set; }
    }

    public static class StockIntradayConverter
    {
        public static IEnumerable<StockIntraday> ToDataObject(this IEnumerable<IStockIntraday> self)
        {
            return self.Select(p => p.ToDataObject());
        }

        public static StockIntraday ToDataObject(this IStockIntraday self)
        {
            StockIntraday outputData = new StockIntraday
            {
                Amount = self.Amount,
                SellVolume = self.SellVolume,
                AveragePrice = self.AveragePrice,
                BuyVolume = self.BuyVolume,
                Current = self.Current,
                Time = self.Time,
                Volume = self.Volume,
                YesterdayClose = self.YesterdayClose
            };

            return outputData;
        }
    }
}
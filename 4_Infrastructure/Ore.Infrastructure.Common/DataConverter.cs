using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Ore.Infrastructure.Common
{
    public class DataConverter
    {
        public static string GetStockCodeWithMarket(string stockCode)
        {
            if (stockCode.StartsWith("5") ||
                stockCode.StartsWith("6") ||
                stockCode.StartsWith("9"))
            {
                return "sh" + stockCode;
            }
            else if (stockCode.StartsWith("009") ||
                stockCode.StartsWith("126") ||
                stockCode.StartsWith("110"))
            {
                return "sh" + stockCode;
            }
            else
            {
                return "sz" + stockCode;
            }
        }

        public static Market GetMarketByString(string market)
        {
            // 上海证券交易所
            if (market.Contains("上交所") || market == "sh")
                return Market.XSHG;

            // 深圳证券交易所
            if (market.Contains("深交所") || market == "sz")
                return Market.XSHE;

            // 中国金融期货交易所   
            if (market.Contains("中金"))
                return Market.CCFX;

            // 大连商品交易所
            if (market.Contains("大连"))
                return Market.XDCE;

            // 上海期货交易所       
            if (market.Contains("上海"))
                return Market.XSGE;

            // 郑州商品交易所
            if (market.Contains("郑州"))
                return Market.XZCE;

            // 香港证券交易所
            if (market.Contains("香港"))
                return Market.XHKG;

            return Market.Unknown;
        }        
    }
}

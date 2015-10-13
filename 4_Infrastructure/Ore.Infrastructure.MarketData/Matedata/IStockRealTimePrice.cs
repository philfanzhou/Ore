using System;

namespace Ore.Infrastructure.MarketData
{
    public interface IStockRealTimePrice
    {
        /// <summary>
        /// 代码
        /// </summary>
        string Code { get; }

        /// <summary>
        /// 交易市场
        /// </summary>
        Market Market { get; }

        /// <summary>
        /// 简称
        /// </summary>
        string ShortName { get; }

        /// <summary>
        /// 今开
        /// </summary>
        double TodayOpen { get; }

        /// <summary>
        /// 昨收
        /// </summary>
        double YesterdayClose { get; }

        /// <summary>
        /// 当前成交价
        /// </summary>
        double Current { get; }

        /// <summary>
        /// 最高
        /// </summary>
        double High { get; }

        /// <summary>
        /// 最低
        /// </summary>
        double Low { get; }

        /// <summary>
        /// 成交量
        /// </summary>
        double Volume { get; }

        /// <summary>
        /// 成交额
        /// </summary>
        double Amount { get; }

        /// <summary>
        /// 日期与时间
        /// </summary>
        DateTime Time { get; }

        #region 卖五
        /// <summary>
        /// 卖五价
        /// </summary>
        double Sell5Price { get; }

        /// <summary>
        /// 卖五量
        /// </summary>
        double Sell5Volume { get; }

        /// <summary>
        /// 卖四价
        /// </summary>
        double Sell4Price { get; }

        /// <summary>
        /// 卖四量
        /// </summary>
        double Sell4Volume { get; }

        /// <summary>
        /// 卖三价
        /// </summary>
        double Sell3Price { get; }

        /// <summary>
        /// 卖三量
        /// </summary>
        double Sell3Volume { get; }

        /// <summary>
        /// 卖二价
        /// </summary>
        double Sell2Price { get; }

        /// <summary>
        /// 卖二量
        /// </summary>
        double Sell2Volume { get; }

        /// <summary>
        /// 卖一价
        /// </summary>
        double Sell1Price { get; }

        /// <summary>
        /// 卖一量
        /// </summary>
        double Sell1Volume { get; }
        #endregion

        #region 买五
        /// <summary>
        /// 买一价
        /// </summary>
        double Buy1Price { get; }

        /// <summary>
        /// 买一量
        /// </summary>
        double Buy1Volume { get; }

        /// <summary>
        /// 买二价
        /// </summary>
        double Buy2Price { get; }

        /// <summary>
        /// 买二量
        /// </summary>
        double Buy2Volume { get; }

        /// <summary>
        /// 买三价
        /// </summary>
        double Buy3Price { get; }

        /// <summary>
        /// 买三量
        /// </summary>
        double Buy3Volume { get; }

        /// <summary>
        /// 买四价
        /// </summary>
        double Buy4Price { get; }

        /// <summary>
        /// 买四量
        /// </summary>
        double Buy4Volume { get; }

        /// <summary>
        /// 买五价
        /// </summary>
        double Buy5Price { get; }

        /// <summary>
        /// 买五量
        /// </summary>
        double Buy5Volume { get; }
        #endregion
    }
}

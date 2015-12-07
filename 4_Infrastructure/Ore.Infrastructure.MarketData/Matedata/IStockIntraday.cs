using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 分时数据定义
    /// </summary>
    public interface IStockIntraday
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
        /// 时间
        /// </summary>
        DateTime Time { get; }

        /// <summary>
        /// 当前价
        /// </summary>
        double Current { get; }

        /// <summary>
        /// 均价 = 当前时刻总成交额 / 当前时刻总成交量
        /// </summary>
        double AveragePrice { get; }

        /// <summary>
        /// 前一交易日收盘价
        /// </summary>
        double YesterdayClose { get; }

        ///// <summary>
        ///// 涨跌
        ///// </summary>
        //double Change { get; set; }

        ///// <summary>
        ///// 涨跌幅
        ///// </summary>
        //double ChangeRate { get; set; }

        /// <summary>
        /// 分时成交量
        /// </summary>
        double Volume { get; }

        /// <summary>
        /// 分时成交额
        /// </summary>
        double Amount { get; }

        /// <summary>
        /// 委买
        /// </summary>
        double BuyVolume { get; }

        /// <summary>
        /// 委卖
        /// </summary>
        double SellVolume { get; }
    }
}

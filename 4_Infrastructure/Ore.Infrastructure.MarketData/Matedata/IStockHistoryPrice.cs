using System;

namespace Ore.Infrastructure.MarketData
{
    public interface IStockHistoryPrice
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
        double Open { get; }

        /// <summary>
        /// 昨收
        /// </summary>
        double PreClose { get; }

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
    }
}

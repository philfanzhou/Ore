using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// K线数据定义
    /// </summary>
    public interface IStockKLine : ITimeSeries
    {
        /// <summary>
        /// 今开
        /// </summary>
        double Open { get; }

        /// <summary>
        /// 最高
        /// </summary>
        double High { get; }

        /// <summary>
        /// 最低
        /// </summary>
        double Low { get; }

        /// <summary>
        /// 收盘
        /// </summary>
        double Close { get; }

        /// <summary>
        /// 成交量
        /// </summary>
        double Volume { get; }

        /// <summary>
        /// 成交额
        /// </summary>
        double Amount { get; }
    }
}

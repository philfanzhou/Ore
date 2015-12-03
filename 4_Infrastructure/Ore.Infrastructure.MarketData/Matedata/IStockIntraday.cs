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
        DateTime Time { get; set; }

        /// <summary>
        /// 当前价
        /// </summary>
        double Current { get; set; }

        /// <summary>
        /// 均价
        /// </summary>
        double AveragePrice { get; set; }

        /// <summary>
        /// 涨跌
        /// </summary>
        double Change { get; set; }

        /// <summary>
        /// 涨跌幅
        /// </summary>
        double ChangeRate { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        double Volume { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        double Amount { get; set; }
    }
}

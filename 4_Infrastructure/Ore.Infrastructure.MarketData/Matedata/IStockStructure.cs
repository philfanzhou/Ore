using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 定义股票股本结构接口
    /// </summary>
    public interface IStockStructure
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
        /// 总股本
        /// </summary>
        double TotalShares { get; }

        /// <summary>
        /// A股合计
        /// </summary>
        double TotalSharesA { get; }

        /// <summary>
        /// 实际流通A股
        /// </summary>
        double SharesA { get; }

        /// <summary>
        /// B股
        /// </summary>
        double SharesB { get; }

        /// <summary>
        /// H股
        /// </summary>
        double SharesH { get; }

        /// <summary>
        /// 变动日期
        /// </summary>
        DateTime Date { get; }

        /// <summary>
        /// 变更原因
        /// </summary>
        string Reason { get; }
    }
}

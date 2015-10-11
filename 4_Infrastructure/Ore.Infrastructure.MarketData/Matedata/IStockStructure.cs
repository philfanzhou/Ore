using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 定义股票股本结构接口
    /// </summary>
    public interface IStockStructure
    {
        /// <summary>
        /// 未流通股份
        /// </summary>
        double NonTradableShares { get; }

        /// <summary>
        /// 流通受限股份
        /// </summary>
        double CirculationOfRestrictedShares { get; }

        /// <summary>
        /// 已流通股份 = 已上市流通A股 + 已上市流通B股 + 境外上市流通股 + 其它已流通股份
        /// </summary>
        double CirculatingShares { get; }

        /// <summary>
        /// 总股本 = 已流通股份 + 流通受限股份 + 未流通股份
        /// </summary>
        double TotalShares { get; }

        /// <summary>
        /// 已上市流通A股
        /// </summary>
        double SharesA { get; }

        /// <summary>
        /// 已上市流通B股
        /// </summary>
        double SharesB { get; }

        /// <summary>
        /// 境外上市流通股
        /// </summary>
        double SharesOverseas { get; }

        /// <summary>
        /// 其它已流通股份
        /// </summary>
        double SharesOther { get; }

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

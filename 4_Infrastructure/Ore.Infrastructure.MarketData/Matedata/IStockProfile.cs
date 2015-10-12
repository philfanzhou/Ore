using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 定义股票基本信息接口
    /// </summary>
    public interface IStockProfile
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        string Code { get; }

        /// <summary>
        /// 证券交易所
        /// </summary>
        Market Exchange { get; }

        /// <summary>
        /// 证券简称
        /// </summary>
        string ShortName { get; }

        /// <summary>
        /// 证券全称
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// 上市状态
        /// </summary>
        ListStatus ListStatus { get; }

        /// <summary>
        /// 上市日期
        /// </summary>
        DateTime ListDate { get; }

        /// <summary>
        /// 摘牌日期
        /// </summary>
        DateTime DelistDate { get; }

        /// <summary>
        /// 办公地址
        /// </summary>
        string OfficeAddress { get; }

        /// <summary>
        /// 主营业务范围
        /// </summary>
        string PrimeBusiness { get; }

        /// <summary>
        /// 财报日期
        /// </summary>
        DateTime FinancialReportDate { get; }

        /// <summary>
        /// 所有者权益合计
        /// </summary>
        double ShareholderEquity { get; }
    }
}

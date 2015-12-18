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
        /// 变动日期
        /// </summary>
        DateTime DateOfChange { get; }
        /// <summary>
        /// 公告日期
        /// </summary>
        DateTime DateOfDeclaration { get; }
        /// <summary>
        /// 变更原因
        /// </summary>
        string Reason { get; }

        /// <summary>
        /// 总股本
        /// </summary>
        double TotalShares { get; }
        /// <summary>
        /// 流通A股
        /// </summary>
        double SharesA { get; }
        /// <summary>
        /// 高管股
        /// </summary>
        double ExecutiveShares { get; }
        /// <summary>
        /// 限售A股
        /// </summary>
        double RestrictedSharesA { get; }
        /// <summary>
        /// 流通B股
        /// </summary>
        double SharesB { get; }
        /// <summary>
        /// 限售B股
        /// </summary>
        double RestrictedSharesB { get; }
        /// <summary>
        /// 流通H股
        /// </summary>
        double SharesH { get; }
        /// <summary>
        /// 国家股
        /// </summary>
        double StateShares { get; }
        /// <summary>
        /// 国有法人股
        /// </summary>
        double StateOwnedLegalPersonShares { get; }
        /// <summary>
        /// 境内法人股
        /// </summary>
        double DomesticLegalPersonShares { get; }
        /// <summary>
        /// 境内发起人股
        /// </summary>
        double DomesticSponsorsShares { get; }
        /// <summary>
        /// 募集法人股
        /// </summary>
        double RaiseLegalPersonShares { get; }
        /// <summary>
        /// 一般法人股
        /// </summary>
        double GeneralLegalPersonShares { get; }
        /// <summary>
        /// 战略投资者持股
        /// </summary>
        double StrategicInvestorsShares { get; }
        /// <summary>
        /// 基金持股
        /// </summary>
        double FundsShares { get; }
        /// <summary>
        /// 转配股
        /// </summary>
        double TransferredAllottedShares { get; }
        /// <summary>
        /// 内部职工股
        /// </summary>
        double InternalStaffShares { get; }
        /// <summary>
        /// 优先股
        /// </summary>
        double PreferredStock { get; }
    }
}

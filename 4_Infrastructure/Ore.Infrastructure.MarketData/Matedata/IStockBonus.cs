using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 股票分红配股信息
    /// </summary>
    public interface IStockBonus
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
        /// 公告日期
        /// </summary>
        DateTime DateOfDeclaration { get; }
        /// <summary>
        /// 分红配股类型
        /// </summary>
        BounsType Type { get; }
        /// <summary>
        /// 除权除息日
        /// </summary>
        DateTime ExdividendDate { get; }
        /// <summary>
        /// 股权登记日
        /// </summary>
        DateTime RegisterDate { get; }

        /// <summary>
        /// 税前红利（10派）（报价币种）
        /// </summary>
        double Bonus { get; }
        /// <summary>
        /// 税后红利（10派）（报价币种）
        /// </summary>
        double BonusAfterTax { get; }
        /// <summary>
        /// B、H股税前红利（人民币）
        /// </summary>
        double BAndHBonus { get; }
        /// <summary>
        /// B、H股税后红利（人民币）
        /// </summary>
        double BAndHBonusAfterTax { get; }
        /// <summary>
        /// 送股比例（10送）
        /// </summary>
        double Field1 { get; }
        /// <summary>
        /// 转增比例（10转增）
        /// </summary>
        double Field2 { get; }
        /// <summary>
        /// 盈余公积金转增比例（10转增）
        /// </summary>
        double Field3 { get; }
        /// <summary>
        /// 资本公积金转增比例（10转增）
        /// </summary>
        double Field4 { get; }
        /// <summary>
        /// 发放对象
        /// </summary>
        string Field5 { get; }
        /// <summary>
        /// 股本基准日
        /// </summary>
        DateTime Field6 { get; }
        /// <summary>
        /// 最后交易日
        /// </summary>
        DateTime Field7 { get; }

        /// <summary>
        /// 红利/配股起始日（送、转股到账日)
        /// </summary>
        DateTime Field8 { get; }
        /// <summary>
        /// 红利/配股终止日
        /// </summary>
        DateTime Field9 { get; }
        /// <summary>
        /// 股东大会决议公告日期
        /// </summary>
        DateTime Field10 { get; }
        /// <summary>
        /// 可转债享受权益转股截止日
        /// </summary>
        DateTime Field11 { get; }
        
        /// <summary>
        /// 配股上市日
        /// </summary>
        DateTime DispatchListingDate { get; }
        /// <summary>
        /// 配股比例（10配）
        /// </summary>
        double DispatchRate { get; }
        /// <summary>
        /// 配股价
        /// </summary>
        double DispatchPrice { get; }
        /// <summary>
        /// 转配比例
        /// </summary>
        double Field12 { get; }
        /// <summary>
        /// 转配价
        /// </summary>
        double Field13 { get; }
        /// <summary>
        /// 配股有效期
        /// </summary>
        DateTime Field14 { get; }
        /// <summary>
        /// 实际配股数 (万股)
        /// </summary>
        double Field15 { get; }
        /// <summary>
        /// 配股前总股本 (万股)
        /// </summary>
        double Field16 { get; }
        /// <summary>
        /// 实际配股比例
        /// </summary>
        double Field17 { get; }
        /// <summary>
        /// 每股拆细数
        /// </summary>
        double Field18 { get; }
        /// <summary>
        /// 外币折算汇率
        /// </summary>
        double Field19 { get; }

        /// <summary>
        /// 权息说明
        /// </summary>
        string Description { get; }
    }

    /// <summary>
    /// 分红配股类型枚举
    /// </summary>
    public enum BounsType
    {
        /// <summary>
        /// 分红
        /// </summary>
        ProfitSharing,
        /// <summary>
        /// 配股
        /// </summary>
        StockOption
    }

}

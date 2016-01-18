using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 股票分红配股信息
    /// </summary>
    public interface IStockBonus
    {
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
        double PreTaxDividend { get; }
        /// <summary>
        /// 税后红利（10派）（报价币种）
        /// </summary>
        double DividendAfterTax { get; }
        /// <summary>
        /// B、H股税前红利（人民币）
        /// </summary>
        double BAndHPreTaxDividend { get; }
        /// <summary>
        /// B、H股税后红利（人民币）
        /// </summary>
        double BAndHDividendAfterTax { get; }
        /// <summary>
        /// 送股比例（10送）
        /// </summary>
        double BonusRate { get; }
        /// <summary>
        /// 转增比例（10转增）
        /// </summary>
        double IncreaseRate { get; }
        /// <summary>
        /// 盈余公积金转增比例（10转增）
        /// </summary>
        double ReserveSurplusIncreaseRate { get; }
        /// <summary>
        /// 资本公积金转增比例（10转增）
        /// </summary>
        double CapitalSurplusIncreaseRate { get; }
        /// <summary>
        /// 发放对象
        /// </summary>
        string IssuingObject { get; }
        /// <summary>
        /// 股本基准日
        /// </summary>
        DateTime CapitalStockBaseDate { get; }
        /// <summary>
        /// 最后交易日
        /// </summary>
        DateTime LastTradingDay { get; }

        /// <summary>
        /// 红利/配股起始日（送、转股到账日)
        /// </summary>
        DateTime StartOrArriveDate { get; }
        /// <summary>
        /// 红利/配股终止日
        /// </summary>
        DateTime ExpirationDate { get; }
        /// <summary>
        /// 股东大会决议公告日期
        /// </summary>
        DateTime ResolutionOfShareholdersMeetingDate { get; }
        /// <summary>
        /// 可转债享受权益转股截止日
        /// </summary>
        DateTime ConvertibleBondDate { get; }
        
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
        double TransferredAllottedRate { get; }
        /// <summary>
        /// 转配价
        /// </summary>
        double TransferredAllottedPrice { get; }
        /// <summary>
        /// 配股有效期
        /// </summary>
        DateTime DispatchExpiryDate { get; }
        /// <summary>
        /// 实际配股数 (万股)
        /// </summary>
        double TotalDispatch { get; }
        /// <summary>
        /// 配股前总股本 (万股)
        /// </summary>
        double CapitalStockBeforeDispatch { get; }
        /// <summary>
        /// 实际配股比例
        /// </summary>
        double ActualDispatchRate { get; }
        /// <summary>
        /// 每股拆细数
        /// </summary>
        double ShareSplitCount { get; }
        /// <summary>
        /// 外币折算汇率
        /// </summary>
        double ExchangeRate { get; }

        /// <summary>
        /// 权息说明
        /// </summary>
        string Description { get; }
    }
}

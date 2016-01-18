using System;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    internal class SinaStockBonusData : IStockBonus
    {  
        public double ActualDispatchRate { get; internal set; }

        public double BAndHDividendAfterTax { get; internal set; }

        public double BAndHPreTaxDividend { get; internal set; }

        public double BonusRate { get; internal set; }

        public DateTime CapitalStockBaseDate { get; internal set; }

        public double CapitalStockBeforeDispatch { get; internal set; }

        public double CapitalSurplusIncreaseRate { get; internal set; }

        public DateTime ConvertibleBondDate { get; internal set; }

        public DateTime DateOfDeclaration { get; internal set; }

        public string Description { get; internal set; }

        public DateTime DispatchExpiryDate { get; internal set; }

        public DateTime DispatchListingDate { get; internal set; }

        public double DispatchPrice { get; internal set; }

        public double DispatchRate { get; internal set; }

        public double DividendAfterTax { get; internal set; }

        public double ExchangeRate { get; internal set; }

        public DateTime ExdividendDate { get; internal set; }

        public DateTime ExpirationDate { get; internal set; }

        public double IncreaseRate { get; internal set; }

        public string IssuingObject { get; internal set; }

        public DateTime LastTradingDay { get; internal set; }

        public double PreTaxDividend { get; internal set; }

        public DateTime RegisterDate { get; internal set; }

        public double ReserveSurplusIncreaseRate { get; internal set; }

        public DateTime ResolutionOfShareholdersMeetingDate { get; internal set; }

        public double ShareSplitCount { get; internal set; }

        public DateTime StartOrArriveDate { get; internal set; }

        public double TotalDispatch { get; internal set; }

        public double TransferredAllottedPrice { get; internal set; }

        public double TransferredAllottedRate { get; internal set; }

        public BounsType Type { get; internal set; }
    }
}

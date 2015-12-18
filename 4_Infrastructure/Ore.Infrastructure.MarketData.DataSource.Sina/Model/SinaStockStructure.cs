using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    internal class SinaStockStructure : IStockStructure
    {
        public string Code { get; internal set; }

        public DateTime DateOfChange { get; internal set; }

        public DateTime DateOfDeclaration { get; internal set; }

        public double DomesticLegalPersonShares { get; internal set; }

        public double DomesticSponsorsShares { get; internal set; }

        public double ExecutiveShares { get; internal set; }

        public double FundsShares { get; internal set; }

        public double GeneralLegalPersonShares { get; internal set; }

        public double InternalStaffShares { get; internal set; }

        public Market Market { get; internal set; }

        public double PreferredStock { get; internal set; }

        public double RaiseLegalPersonShares { get; internal set; }

        public string Reason { get; internal set; }

        public double RestrictedSharesA { get; internal set; }

        public double RestrictedSharesB { get; internal set; }

        public double SharesA { get; internal set; }

        public double SharesB { get; internal set; }

        public double SharesH { get; internal set; }

        public string ShortName { get; internal set; }

        public double StateOwnedLegalPersonShares { get; internal set; }

        public double StateShares { get; internal set; }

        public double StrategicInvestorsShares { get; internal set; }

        public double TotalShares { get; internal set; }

        public double TransferredAllottedShares { get; internal set; }
    }
}

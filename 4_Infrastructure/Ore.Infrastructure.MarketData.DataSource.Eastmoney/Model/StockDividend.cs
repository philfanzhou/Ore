using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney.Model
{
    internal class StockDividend : IStockDividend
    {
        public string Code
        {
            get; internal set;
        }

        public Market Market
        {
            get; internal set;
        }

        public string ShortName
        {
            get; internal set;
        }

        public DateTime Date
        {
            get; internal set;
        }

        public DateTime ExdividendDate
        {
            get; internal set;
        }

        public double Cash
        {
            get; internal set;
        }

        public double Split
        {
            get; internal set;
        }

        public double Bonus
        {
            get; internal set;
        }

        public double Dispatch
        {
            get; internal set;
        }

        public double Price
        {
            get; internal set;
        }

        public DateTime RegisterDate
        {
            get; internal set;
        }

        public DateTime ListingDate
        {
            get; internal set;
        }

        public string Description
        {
            get; internal set;
        }
    }
}

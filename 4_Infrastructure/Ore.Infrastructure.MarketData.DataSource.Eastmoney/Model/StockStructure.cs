﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    internal class StockStructure : IStockStructure
    {
        public string Code
        {
            get; internal set;
        }

        public DateTime Date
        {
            get; internal set;
        }

        public Market Market
        {
            get; internal set;
        }

        public string Reason
        {
            get; internal set;
        }

        public double SharesA
        {
            get; internal set;
        }

        public double SharesB
        {
            get; internal set;
        }

        public double SharesH
        {
            get; internal set;
        }

        public string ShortName
        {
            get; internal set;
        }

        public double TotalShares
        {
            get; internal set;
        }

        public double TotalSharesA
        {
            get; internal set;
        }
    }
}

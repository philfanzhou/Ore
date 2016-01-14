using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    internal class SinaStockKLineData : IStockKLine
    {
        public double Amount { get; internal set; }

        public double Close { get; internal set; }

        public double High { get; internal set; }

        public double Low { get; internal set; }

        public double Open { get; internal set; }

        public DateTime Time { get; internal set; }

        public double Volume { get; internal set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    public class Participation : IParticipation
    {
        public string Code { get; internal set; }

        public double CostPrice1Day { get; internal set; }

        public double CostPrice20Day { get; internal set; }

        public double MainForceInflows { get; internal set; }

        public double SuperLargeInflows { get; internal set; }

        public DateTime Time { get; internal set; }

        public double Value { get; internal set; }
    }
}

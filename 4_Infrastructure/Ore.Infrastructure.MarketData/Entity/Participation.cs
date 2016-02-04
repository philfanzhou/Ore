using System;
using System.Collections.Generic;
using System.Linq;

namespace Ore.Infrastructure.MarketData
{
    public class Participation : IParticipation
    {
        public double CostPrice1Day { get; set; }

        public double CostPrice20Day { get; set; }

        public double MainForceInflows { get; set; }

        public double SuperLargeInflows { get; set; }

        public DateTime Time { get; set; }

        public double Value { get; set; }
    }

    public static class ParticipationConverter
    {
        public static IEnumerable<Participation> ToDataObject(this IEnumerable<IParticipation> self)
        {
            return self.Select(p => p.ToDataObject());
        }

        public static Participation ToDataObject(this IParticipation self)
        {
            Participation outputData = new Participation
            {
                CostPrice1Day = self.CostPrice1Day,
                CostPrice20Day = self.CostPrice20Day,
                MainForceInflows = self.MainForceInflows,
                SuperLargeInflows = self.SuperLargeInflows,
                Time = self.Time,
                Value = self.Value,
            };

            return outputData;
        }
    }
}

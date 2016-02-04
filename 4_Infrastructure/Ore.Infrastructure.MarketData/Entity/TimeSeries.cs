using System;

namespace Ore.Infrastructure.MarketData
{
    public class TimeSeries : ITimeSeries
    {
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return Time.ToString("yyyy/MM/dd hh:mm:ss");
        }
    }
}

using System.Collections.Generic;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal class DayLineInfo : IKlineData
    {
        public string Symbol
        {
            get;
            set;
        }

        public List<IKlineItem> Items
        {
            get;
            set;
        }
    }
}
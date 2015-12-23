using System.Collections.Generic;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal class DividendInfo : IDividendData
    {
        public string Symbol
        {
            get;
            set;
        }

        public List<IDividendItem> Items
        {
            get;
            set;
        }
    }
}
using System.Collections.Generic;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    public interface IDividendData
    {
        string Symbol { get; }

        List<IDividendItem> Items { get; }
    }
}
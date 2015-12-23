using System.Collections.Generic;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    public interface IKlineData
    {
        string Symbol { get; }

        List<IKlineItem> Items { get; } 
    }
}
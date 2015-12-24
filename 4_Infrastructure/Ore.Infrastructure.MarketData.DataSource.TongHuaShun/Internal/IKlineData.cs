using System.Collections.Generic;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal interface IKlineData
    {
        string Symbol { get; }

        List<IKlineItem> Items { get; } 
    }
}
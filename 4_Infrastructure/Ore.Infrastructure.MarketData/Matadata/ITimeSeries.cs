using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 定义具有时间序列的接口
    /// </summary>
    public interface ITimeSeries
    {
        /// <summary>
        /// 日期与时间
        /// </summary>
        DateTime Time { get; }
    }
}

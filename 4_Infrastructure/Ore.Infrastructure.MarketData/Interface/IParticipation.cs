using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 定义机构参与度数据接口
    /// </summary>
    public interface IParticipation
    {
        /// <summary>
        /// 日期与时间
        /// </summary>
        DateTime Time { get; }

        /// <summary>
        /// 机构参与度（%） : 45
        /// </summary>
        double Value { get; }

        /// <summary>
        /// 主力净流入
        /// </summary>
        double MainForceInflows { get; }

        /// <summary>
        /// 超大单流入
        /// </summary>
        double SuperLargeInflows { get; }

        /// <summary>
        /// 最近1日主力成本
        /// </summary>
        double CostPrice1Day { get; }

        /// <summary>
        /// 最近20日主力成本
        /// </summary>
        double CostPrice20Day { get; }
    }
}

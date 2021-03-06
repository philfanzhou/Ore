﻿namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 上市状态枚举
    /// </summary>
    public enum ListStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 上市
        /// </summary>
        List = 1,

        /// <summary>
        /// 暂停
        /// </summary>
        Suspend = 2,

        /// <summary>
        /// 摘牌
        /// </summary>
        Delist = 3,

        /// <summary>
        /// 未上市
        /// </summary>
        Unlisted = 4
    }
}

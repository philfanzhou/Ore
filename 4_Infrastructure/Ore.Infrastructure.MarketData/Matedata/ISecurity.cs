namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 定义证券接口
    /// </summary>
    public interface ISecurity
    {
        /// <summary>
        /// 挂牌代码
        /// </summary>
        string Code { get; }

        /// <summary>
        /// 证券简称
        /// </summary>
        string ShortName { get; }

        /// <summary>
        /// 交易市场
        /// </summary>
        Market Market { get; }

        /// <summary>
        /// 证券类型
        /// </summary>
        SecurityType Type { get; }
    }
}

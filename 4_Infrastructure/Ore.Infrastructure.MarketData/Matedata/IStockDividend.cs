using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 股票分红分配信息
    /// </summary>
    public interface IStockDividend
    {
        /// <summary>
        /// 代码
        /// </summary>
        string Code { get; }

        /// <summary>
        /// 交易市场
        /// </summary>
        Market Market { get; }

        /// <summary>
        /// 简称
        /// </summary>
        string ShortName { get; }

        /// <summary>
        /// 日期
        /// </summary>
        DateTime Date { get; }

        /// <summary>
        /// 除权日
        /// </summary>
        DateTime ExdividendDate { get; }

        /// <summary>
        /// 分红
        /// </summary>
        double Cash { get; }

        /// <summary>
        /// 总拆股
        /// </summary>
        double Split { get; }

        /// <summary>
        /// 转增股
        /// </summary>
        double Bonus { get; }

        /// <summary>
        /// 配股
        /// </summary>
        double Dispatch { get; }

        /// <summary>
        /// 配股价
        /// </summary>
        double Price { get; }

        /// <summary>
        /// 登记日
        /// </summary>
        DateTime RegisterDate { get; }

        /// <summary>
        /// 上市日
        /// </summary>
        DateTime ListingDate { get; }

        /// <summary>
        /// 描述
        /// </summary>
        string Description { get; }
    }
}

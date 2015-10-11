using System;

namespace Ore.Infrastructure.MarketData.Implementation
{
    /// <summary>
    /// 股票基本信息
    /// </summary>
    public class Equ : IStockProfile
    {
        /// <summary>+
        /// 证券内部编码
        /// </summary>
        /// <example>000001.XSHE</example>
        public string secID
        {
            get;
            set;
        }

        /// <summary>+
        /// 交易代码
        /// </summary>
        /// <example>000001</example>
        public string ticker
        {
            get;
            set;
        }
        string IStockProfile.Code
        {
            get
            {
                return this.ticker;
            }
        }

        /// <summary>+
        /// 交易市场编码
        /// </summary>
        /// <example>XSHG</example>
        public string exchangeCD
        {
            get;
            set;
        }
        Exchange IStockProfile.Exchange
        {
            get
            {
                return (Exchange)Enum.Parse(typeof(Exchange), this.exchangeCD);
            }
        }

        /// <summary>
        /// 上市板块编码
        /// </summary>
        /// <example>1</example>
        public int ListSectorCD
        {
            get;
            set;
        }

        /// <summary>
        /// 上市板块
        /// </summary>
        /// <example>主板</example>
        public string ListSector
        {
            get;
            set;
        }

        /// <summary>+
        /// 交易货币编码
        /// </summary>
        /// <example>CNY</example>
        public string transCurrCD
        {
            get;
            set;
        }

        /// <summary>+
        /// 证券简称
        /// </summary>
        /// <example>平安银行</example>
        public string secShortName
        {
            get;
            set;
        }
        string IStockProfile.ShortName
        {
            get
            {
                return this.secShortName;
            }
        }

        /// <summary>+
        /// 证券全称
        /// </summary>
        /// <example>平安银行股份有限公司</example>
        public string secFullName
        {
            get;
            set;
        }
        string IStockProfile.FullName
        {
            get
            {
                return this.secFullName;
            }
        }

        /// <summary>+
        /// 上市状态
        /// </summary>
        /// <example>L-上市，S-暂停，DE-终止上市，UN-未上市</example>
        public string listStatusCD
        {
            get;
            set;
        }
        ListStatus IStockProfile.ListStatus
        {
            get
            {
                switch (this.listStatusCD)
                {
                    case "L":
                        return ListStatus.List;
                    case "S":
                        return ListStatus.suspend;
                    case "DE":
                        return ListStatus.Delist;
                    case "UN":
                        return ListStatus.Unlisted;
                    default:
                        return ListStatus.Unknown;
                }
            }
        }

        /// <summary>+
        /// 上市时间
        /// </summary>
        /// <example>1991-04-03</example>
        public string listDate
        {
            get;
            set;
        }
        DateTime IStockProfile.ListDate
        {
            get
            {
                return DateTime.Parse(this.listDate).Date;
            }
        }

        /// <summary>+
        /// 摘牌时间
        /// </summary>
        public string delistDate
        {
            get;
            set;
        }
        DateTime IStockProfile.DelistDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.delistDate))
                {
                    return DateTime.MinValue;
                }
                return DateTime.Parse(this.delistDate).Date;
            }
        }

        /// <summary>
        /// 股票分类编码
        /// </summary>
        /// <example>A或B对应A股或B股</example>
        public string equTypeCD
        {
            get;
            set;
        }

        /// <summary>
        /// 股票类别
        /// </summary>
        /// <example>沪深A股</example>
        public string equType
        {
            get;
            set;
        }

        /// <summary>+
        /// 交易市场所属地区编码
        /// </summary>
        /// <example>CHN</example>
        public string exCountryCD
        {
            get;
            set;
        }

        /// <summary>
        /// 机构内部ID
        /// </summary>
        /// <example>2</example>
        public string partyID
        {
            get;
            set;
        }

        /// <summary>+
        /// 总股本(最新)
        /// </summary>
        public double totalShares
        {
            get;
            set;
        }

        /// <summary> +
        /// 公司无限售流通股份合计(最新)
        /// </summary>
        public double nonrestFloatShares
        {
            get;
            set;
        }

        /// <summary>
        /// 无限售流通股本(最新)。如果为A股，该列为最新无限售流通A股股本数量；如果为B股，该列为最新流通B股股本数量
        /// </summary>
        public double nonrestfloatA
        {
            get;
            set;
        }

        /// <summary>+
        /// 办公地址
        /// </summary>
        public string officeAddr
        {
            get;
            set;
        }
        string IStockProfile.OfficeAddress
        {
            get
            {
                return this.officeAddr;
            }
        }

        /// <summary>+
        /// 主营业务范围
        /// </summary>
        public string primeOperating
        {
            get;
            set;
        }
        string IStockProfile.PrimeBusiness
        {
            get
            {
                return this.primeOperating;
            }
        }

        /// <summary>+
        /// 财务报告日期
        /// </summary>
        public string endDate { get; set; }
        DateTime IStockProfile.FinancialReportDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.endDate))
                {
                    return DateTime.MinValue;
                }
                return DateTime.Parse(this.endDate).Date;
            }
        }

        /// <summary>+
        /// 所有者权益合计
        /// </summary>
        public double TShEquity { get; set; }
        double IStockProfile.ShareholderEquity
        {
            get
            {
                return this.TShEquity;
            }
        }
    }
}

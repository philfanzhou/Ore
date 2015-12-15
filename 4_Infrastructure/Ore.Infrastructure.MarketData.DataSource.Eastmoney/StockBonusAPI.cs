using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney.Model;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    internal class DistributionOfYears
    {
        public DateTime Year
        {
            get; internal set;
        }

        public string EPS
        {
            get; internal set;
        }

        public string Yeld
        {
            get; internal set;
        }

        public string Scheme
        {
            get; internal set;
        }
    }

    public class StockBonusAPI
    {
        // 请使用新的数据源地址 从这个页面获取到的数据，根据对应类型，传入下面的Detail页面获取详细数据
        private const string WebApiAddress = @"http://vip.stock.finance.sina.com.cn/corp/go.php/vISSUE_ShareBonus/stockid/000002.phtml";
        // 分红详细信息地址 参数 end_date= 公告日期 type=1
        private const string DetailInfo1 = @"http://vip.stock.finance.sina.com.cn/corp/view/vISSUE_ShareBonusDetail.php?stockid=000002&type=1&end_date=2015-07-14";
        // 配股详细信息地址 参数 end_date= 公告日期 type=2
        private const string DetailInfo2 = @"http://vip.stock.finance.sina.com.cn/corp/view/vISSUE_ShareBonusDetail.php?stockid=000002&type=2&end_date=1999-12-22";


        public IEnumerable<IStockDividend> GetStockStructure(string stockCode)
        {
            //string url = string.Format(@"http://quote3.eastmoney.com/f10.aspx?StockCode={0}&stock_name=&f10=010", stockCode);

            //StreamReader pageStream = PageReader.GetPageStream(url);
            //if (pageStream == null)
            //    return null;

            //var htmlDocument = new HtmlDocument();
            //htmlDocument.Load(pageStream);
            //HtmlNode namecodeNode = htmlDocument.GetElementbyId("c_sname_code");
            //HtmlNode contentNode = htmlDocument.GetElementbyId("maincontent");

            //string nameCode = Regex.Replace(namecodeNode.InnerText, @"&nbsp;*", "");
            ///// 代码
            //string code = Regex.Match(nameCode, @"\d{6}").Value;
            ///// 简称
            //string shortName = Regex.Replace(nameCode, @"\[\d{6}\]", "");

            //string[] datas = contentNode.InnerText.Trim().Split(new string[] { "&nbsp;", "┌", "─", "┬", "┐", "｜", "┤", "├", "┼", "└", "┴", "┘" }, StringSplitOptions.RemoveEmptyEntries);

            //string strTmp = datas[0].Substring(datas[0].IndexOf("≈≈") + 2, datas[0].LastIndexOf("≈≈") - datas[0].IndexOf("≈≈") - 2);
            

            ///// 交易市场
            //Market market = Market.Unknown;
            /////// 日期
            ////DateTime date;
            /////// 除权日
            ////DateTime exdividendDate;
            /////// 分红
            ////double cash;
            /////// 总拆股
            ////double split;
            /////// 转增股
            ////double bonus;
            /////// 配股
            ////double dispatch;
            /////// 配股价
            ////double price;
            /////// 登记日
            ////DateTime registerDate;
            /////// 上市日
            ////DateTime listingDate;
            /////// 描述
            ////string description;
            //var lstDisOfYears = GetStockDividendList(datas);
            //if(lstDisOfYears != null)
            //{
            //    foreach(var item in lstDisOfYears)
            //    {
            //    }
            //}

            //return null;
        }

        //private List<DistributionOfYears> GetStockDividendList(string[] datas)
        //{
        //    List<DistributionOfYears> lstDisOfYears = new List<DistributionOfYears>();           

        //    DistributionOfYears disOfYears = null;
        //    for (int i = 1; i < datas.Length; i++)
        //    {
        //        DateTime year;                
        //        if (!DateTime.TryParse(datas[i], out year))
        //        {
        //            if (disOfYears != null)
        //                disOfYears.Scheme += datas[i];
        //            continue;
        //        }

        //        disOfYears = new DistributionOfYears();
        //        disOfYears.Year = year;
        //        i++;
        //        float eps = 0;
        //        if (float.TryParse(datas[i], out eps))
        //        {
        //            disOfYears.EPS = eps.ToString();
        //            i++;
        //        }

        //        if (datas[i].Contains("%"))
        //        {
        //            disOfYears.Yeld = datas[i];
        //            i++;
        //        }                
        //        disOfYears.Scheme = datas[i];

        //        lstDisOfYears.Add(disOfYears);
        //    }

        //    return lstDisOfYears;
        //}
    }
}

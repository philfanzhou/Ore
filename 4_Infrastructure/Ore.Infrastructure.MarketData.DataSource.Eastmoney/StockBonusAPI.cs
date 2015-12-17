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
    public class StockBonusAPI
    {
        // 请使用新的数据源地址 从这个页面获取到的数据，根据对应类型，传入下面的Detail页面获取详细数据
        private const string WebApiAddress = @"http://vip.stock.finance.sina.com.cn/corp/go.php/vISSUE_ShareBonus/stockid/000002.phtml";
        // 分红详细信息地址 参数 end_date= 公告日期 type=1
        private const string DetailInfo1 = @"http://vip.stock.finance.sina.com.cn/corp/view/vISSUE_ShareBonusDetail.php?stockid=000002&type=1&end_date=2015-07-14";
        // 配股详细信息地址 参数 end_date= 公告日期 type=2
        private const string DetailInfo2 = @"http://vip.stock.finance.sina.com.cn/corp/view/vISSUE_ShareBonusDetail.php?stockid=000002&type=2&end_date=1999-12-22";


        public IEnumerable<IStockBonus> GetStockBonus(string stockCode)
        {
            string url = string.Format(@"http://vip.stock.finance.sina.com.cn/corp/go.php/vISSUE_ShareBonus/stockid/{0}.phtml", stockCode);

            string html = PageReader.GetPageSource(url);
            if (string.IsNullOrEmpty(html))
                return null;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);


            return null;
        }        
    }
}

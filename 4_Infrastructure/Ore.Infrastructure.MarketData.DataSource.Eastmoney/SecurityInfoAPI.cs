using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ore.Infrastructure.Common;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    public class SecurityInfoApi
    {
        private const string WebApiAddress = @"http://quote.eastmoney.com/stock_list.html";

        public IEnumerable<ISecurity> GetAllSecurity()
        {
            string html = PageReader.GetPageSource(WebApiAddress);
            if (string.IsNullOrEmpty(html))
                return null;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var htmlNodes = htmlDocument.DocumentNode;

            string xpath = "/html[1]/body[1]/div[9]/div[2]/div[1]/ul";
            HtmlNodeCollection ulNodes = htmlDocument.DocumentNode.SelectNodes(xpath);
            if (ulNodes == null || ulNodes.Count < 1)
                return null;

            List<Security> datas = new List<Security>();
            foreach (HtmlNode item in ulNodes)
            {
                HtmlNodeCollection liNodes = item.SelectNodes("li");
                foreach (HtmlNode it in liNodes)
                {
                    string strLink = it.FirstChild.Attributes["href"].Value;
                    string strTest = it.FirstChild.InnerText;
                    string marketCode = Regex.Match(strLink, @"[a-z]{2}\d{6}").Value;
                    string market = Regex.Match(marketCode, @"[a-z]{2}").Value;
                    string code = Regex.Match(marketCode, @"\d{6}").Value;
                    string name = Regex.Replace(strTest, @"\(\d{6}\)", "");

                    datas.Add(new Security { Code = code, Market = DataConverter.GetMarketByString(market), ShortName = name, Type = SecurityType.Sotck });
                }
            }

            return datas;
        }
    }
}

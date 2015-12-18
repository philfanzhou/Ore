using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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

            List<SecurityInfo> datas = null;
            var nodesSecurityInfo = htmlNodes.CssSelect("div.quotebody").CssSelect("li");
            if (nodesSecurityInfo != null)
            {
                datas = new List<SecurityInfo>();
                foreach (var node in nodesSecurityInfo)
                {
                    if (node.HasChildNodes)
                    {
                        string strLink = node.FirstChild.Attributes["href"].Value;
                        string strTest = node.FirstChild.InnerText;
                        string marketCode = Regex.Match(strLink, @"[a-z]{2}\d{6}").Value;
                        string market = Regex.Match(marketCode, @"[a-z]{2}").Value;//strLink.Substring(strLink.IndexOf(".com/") + 5, 2);
                        string code = Regex.Match(marketCode, @"\d{6}").Value;//strTest.Substring(strTest.IndexOf("(") + 1, strTest.IndexOf(")") - strTest.IndexOf("(") - 1);
                        string name = Regex.Replace(strTest, @"\(\d{6}\)", ""); //strTest.Substring(0, strTest.IndexOf("("));
                        
                        datas.Add(new SecurityInfo { Code = code, Market = GetMarketByString(market), ShortName = name, Type = SecurityType.Sotck });
                    }
                }
            }
            return datas;
        }

        private Market GetMarketByString(string market)
        {
            if (market == "sh")
            {
                return Market.XSHG;
            }
            else if (market == "sz")
            {
                return Market.XSHE;
            }
            else
            {
                return Market.Unknown;
            }
        }
    }
}

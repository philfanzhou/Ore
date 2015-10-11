using System.IO;
using System.Net;
using System.Text;

namespace Ore.Infrastructure.MarketData.Implementation
{
    public class EastmoneyDataReader
    {
        private static string OrgPercentUrl = "http://data.eastmoney.com/stockcomment/{0}.html";

        //股票代码一览表
        //http://quote.eastmoney.com/stock_list.html
        //http://quote.eastmoney.com/hk/HStock_list.html
        //http://fund.eastmoney.com/allfund.html
        //http://vip.stock.finance.sina.com.cn/usstock/ustotal.php

        //公司概况
        //http://f10.eastmoney.com/f10_v2/CompanySurvey.aspx?code=sz000002
        //http://f10.eastmoney.com/f10_v2/CompanySurvey.aspx?code=sz300300
        //http://f10.eastmoney.com/f10_v2/CompanySurvey.aspx?code=sz002312
        //http://f10.eastmoney.com/f10_v2/CompanySurvey.aspx?code=sh600036
        //http://f10.eastmoney.com/f10_v2/CompanySurvey.aspx?code=sh600002

        //股本结构地址：
        //http://quote3.eastmoney.com/f10.aspx?StockCode=000002&stock_name=&f10=003

        //历史分配地址
        //http://quote3.eastmoney.com/f10.aspx?StockCode=000002&stock_name=&f10=010

        private static string GetDataFromUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 5000;
            request.Proxy = null;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader streamReader
                    = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312")))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public OrgPercentData Get(string code)
        {
            string url = string.Format(OrgPercentUrl, code);
            string message = GetDataFromUrl(url);
            
            return new OrgPercentData(code, message);
        }
    }
}

using System.IO;
using System.Net;
using System.Text;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    internal class PageReader
    {
        internal static string GetPageSource(string url)
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
    }
}

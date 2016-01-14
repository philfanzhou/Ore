using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.Common;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    public class StockKLineApi
    {
        private const string WebApiAddress = @"http://hq.sinajs.cn/list=";

        public IStockKLine GetLatest(string stockCode)
        {
            string url = WebApiAddress + DataConverter.GetStockCodeWithMarket(stockCode); ;
            string strData = GetStringData(url);
            return GetDataFromSource(strData);
        }

        public IEnumerable<IStockKLine> GetLatest(IEnumerable<string> stockCodes)
        {
            // 每天下午3点20之后，调用StockRealTimeApi.GetData(IEnumerable<string> stockCodes)，
            // 就可以获取到当天的日线K线。

            StringBuilder codesBuilder = new StringBuilder();
            foreach (string code in stockCodes)
            {
                if (codesBuilder.Length > 0)
                {
                    codesBuilder.Append(',');
                }
                codesBuilder.Append(DataConverter.GetStockCodeWithMarket(code));
            }

            string strData = GetStringData(WebApiAddress + codesBuilder.ToString());
            string[] strDatas = strData.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<SinaStockKLineData> datas = new List<SinaStockKLineData>();
            foreach (string item in strDatas)
            {
                datas.Add(GetDataFromSource(item));
            }

            return datas;
        }

        private SinaStockKLineData GetDataFromSource(string strData)
        {
            SinaStockKLineData data = new SinaStockKLineData();
            strData = strData.Remove(0, 13);

            int startIndex = strData.IndexOf("\"") + 1;
            int length = strData.LastIndexOf("\"") - startIndex;
            strData = strData.Substring(startIndex, length);

            string[] fields = strData.Split(',');


            // 日期与时间
            data.Time = Convert.ToDateTime(fields[30] + " " + fields[31]);
            // 今开
            data.Open = Convert.ToDouble(fields[1]);
            // 最高
            data.High = Convert.ToDouble(fields[4]);
            // 最低
            data.Low = Convert.ToDouble(fields[5]);
            // 收盘
            data.Close = Convert.ToDouble(fields[3]);
            // 成交量
            data.Volume = Convert.ToDouble(fields[8]);
            // 成交额
            data.Amount = Convert.ToDouble(fields[9]);

            return data;
        }

        private string GetStringData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader myreader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GBK")))
                {
                    return myreader.ReadToEnd();
                }
            }
        }
    }
}

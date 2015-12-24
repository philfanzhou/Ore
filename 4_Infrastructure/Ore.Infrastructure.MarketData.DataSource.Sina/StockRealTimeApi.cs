using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Ore.Infrastructure.Common;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    public class StockRealTimeApi
    {
        private const string WebApiAddress = @"http://hq.sinajs.cn/list=";

        public IStockRealTime GetData(string stockCode)
        {
            string url = WebApiAddress + DataConverter.GetStockCodeWithMarket(stockCode); ;
            string strData = GetStringData(url);
            return GetDataFromSource(strData);
        }

        public IEnumerable<IStockRealTime> GetData(IEnumerable<string> stockCodes)
        {
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

            List<SinaRealTimeData> datas = new List<SinaRealTimeData>();
            foreach (string item in strDatas)
            {
                datas.Add(GetDataFromSource(item));
            }

            return datas;
        }
        
        private SinaRealTimeData GetDataFromSource(string strData)
        {
            SinaRealTimeData data = new SinaRealTimeData();
            strData = strData.Remove(0, 11);

            string market = strData.Substring(0, 2);
            if(market == "sh")
            {
                data.Market = Market.XSHG;
            }
            else if(market == "sz")
            {
                data.Market = Market.XSHE;
            }
            else
            {
                data.Market = Market.Unknown;
            }

            strData = strData.Remove(0, 2);
            data.Code = strData.Substring(0, 6);

            int startIndex = strData.IndexOf("\"") + 1;
            int length = strData.LastIndexOf("\"") - startIndex;
            strData = strData.Substring(startIndex, length);

            string[] fields = strData.Split(',');

            data.ShortName = fields[0];
            data.TodayOpen = Convert.ToDouble(fields[1]);
            data.YesterdayClose = Convert.ToDouble(fields[2]);
            data.Current = Convert.ToDouble(fields[3]);
            data.High = Convert.ToDouble(fields[4]);
            data.Low = Convert.ToDouble(fields[5]);
            data.Volume = Convert.ToDouble(fields[8]);
            data.Amount = Convert.ToDouble(fields[9]);

            data.Buy1Volume = Convert.ToDouble(fields[10]);
            data.Buy1Price = Convert.ToDouble(fields[11]);

            data.Buy2Volume = Convert.ToDouble(fields[12]);
            data.Buy2Price = Convert.ToDouble(fields[13]);

            data.Buy3Volume = Convert.ToDouble(fields[14]);
            data.Buy3Price = Convert.ToDouble(fields[15]);

            data.Buy4Volume = Convert.ToDouble(fields[16]);
            data.Buy4Price = Convert.ToDouble(fields[17]);

            data.Buy5Volume = Convert.ToDouble(fields[18]);
            data.Buy5Price = Convert.ToDouble(fields[19]);

            data.Sell1Volume = Convert.ToDouble(fields[20]);
            data.Sell1Price = Convert.ToDouble(fields[21]);

            data.Sell2Volume = Convert.ToDouble(fields[22]);
            data.Sell2Price = Convert.ToDouble(fields[23]);

            data.Sell3Volume = Convert.ToDouble(fields[24]);
            data.Sell3Price = Convert.ToDouble(fields[25]);

            data.Sell4Volume = Convert.ToDouble(fields[26]);
            data.Sell4Price = Convert.ToDouble(fields[27]);

            data.Sell5Volume = Convert.ToDouble(fields[28]);
            data.Sell5Price = Convert.ToDouble(fields[29]);

            data.Time = Convert.ToDateTime(fields[30] + " " + fields[31]);

            return data;
        }

        private string GetStringData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader myreader
                    = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GBK")))
                {
                    return myreader.ReadToEnd();
                }
            }
        }
    }
}

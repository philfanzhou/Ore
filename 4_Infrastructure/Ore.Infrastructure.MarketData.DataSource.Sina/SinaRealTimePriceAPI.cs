﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    public class SinaRealTimePriceAPI
    {
        private const string WebApiAddress = @"http://hq.sinajs.cn/list=";

        public IStockRealTimePrice GetData(ISecurity security)
        {
            if (security.Type != SecurityType.Sotck)
            {
                throw new ArgumentOutOfRangeException("security");
            }

            string stockCode = GetStockCode(security);
            string url = WebApiAddress + stockCode;
            string strData = GetStringData(url);
            return GetDataFromSource(strData);
        }

        public IEnumerable<IStockRealTimePrice> GetData(IEnumerable<ISecurity> securities)
        {
            StringBuilder codesBuilder = new StringBuilder();
            foreach (ISecurity security in securities)
            {
                if (security.Type != SecurityType.Sotck)
                {
                    throw new ArgumentOutOfRangeException("securities");
                }

                if (codesBuilder.Length > 0)
                {
                    codesBuilder.Append(',');
                }
                codesBuilder.Append(GetStockCode(security));
            }

            string strData = GetStringData(WebApiAddress + codesBuilder.ToString());
            string[] strDatas = strData.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<SinaRealTimeData> datas = new List<SinaRealTimeData>();
            foreach (string item in strDatas)
            {
                datas.Add(GetDataFromSource(strData));
            }

            return datas;
        }

        private string GetStockCode(ISecurity security)
        {
            if (security.Market == Market.XSHG)
            {
                return "sh" + security.Code;
            }
            else if (security.Market == Market.XSHE)
            {
                return "sz" + security.Code;
            }
            {
                throw new ArgumentOutOfRangeException("security");
            }
        }

        private SinaRealTimeData GetDataFromSource(string strData)
        {
            SinaRealTimeData data = new SinaRealTimeData();
            strData = strData.Remove(0, 11);
            data.Code = strData.Substring(0, 8);

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

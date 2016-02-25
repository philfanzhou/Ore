using Ore.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

/****************************************************
一：获取股票的基本信息，包含股票交易代码及其简称、股票类型、上市状态、上市板块、上市日期等；上市状态为最新数据，不显示历史变动信息
名称	类型	必填	描述
equTypeCD	String	3选1	股票分类编码，输入A或B可查询获取到A股或B股
secID	String	3选1	证券内部编码，可通过交易代码和交易市场在getSecurityID获取到。
ticker	String	3选1	股票交易代码，如'000001'
listStatusCD	String	否	上市状态，可选状态有:L-上市，S-暂停，DE-终止上市，UN-未上市，默认为L。
field	string	是	可选参数，用","分隔,默认为空，返回全部字段，不选即为默认值。返回字段见下方
****************************************************/
namespace Ore.Infrastructure.MarketData.DataSource.Wmcloud
{
    public class StockKLineApi
    {
        //股票日线数据URL
        private static string MktEqudUrl = "https://api.wmcloud.com:443/data/v1/api/market/getMktEqud.json?field=&beginDate={0}&endDate={1}&secID=&ticker={2}&tradeDate=";

        private static string GetDataFromUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 5000;
            request.Proxy = null;
            request.Headers.Add("Authorization: Bearer 4e4851b6b5d3c33c84fa82f28e93fa403c422b10bb4cb60bead35734a82288eb");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        private static string GetJsonStrByMessage(string message)
        {
            message = message.Split(new string[] { "data\":" }, StringSplitOptions.RemoveEmptyEntries)[1];
            return message.Substring(0, message.Length - 1);
        }

        /// <summary>
        /// 获取通联股票历史日线数据(通联只提供最近10年数据)
        /// </summary>
        /// <param name="stockCode">股票代码: 600000</param>
        /// <param name="dateStart">开始日期: 20160101 默认值为空：获取所有数据</param>
        /// <param name="dateEnd">结束日期: 20160201 默认值为空：获取所有数据</param>
        /// <returns></returns>
        public List<StockKLine> GetKLineFromWmcloudApi(string stockCode, string dateStart = "", string dateEnd = "")
        {
            string mktEqudUrl = string.Format(MktEqudUrl, dateStart, dateEnd, stockCode);
            string message = GetDataFromUrl(mktEqudUrl);
            message = GetJsonStrByMessage(message);
            List<MktEqud> mktEqudList = JsonHelper.JsonToList<MktEqud>(message);

            List<StockKLine> stockKLineList = new List<StockKLine>();
            foreach (MktEqud mktEqud in mktEqudList)
            {
                string[] tradeDay = mktEqud.tradeDate.Split('-');
                stockKLineList.Add(new StockKLine()
                {
                    Amount = mktEqud.turnoverValue,
                    Volume = mktEqud.turnoverVol,
                    Close = Math.Round(mktEqud.closePrice, 2),
                    High = Math.Round(mktEqud.highestPrice, 2),
                    Open = Math.Round(mktEqud.openPrice, 2),
                    Low = Math.Round(mktEqud.lowestPrice, 2),
                    Time = new DateTime(int.Parse(tradeDay[0]), int.Parse(tradeDay[1]), int.Parse(tradeDay[2]), 0, 0, 0).Date
                });
            }
            
            // 只返回开盘了的股票数据，停牌的数据不需要。
            return stockKLineList.Where(p => p.Open - 0 > 0.00000001).ToList();
        }
    }
}

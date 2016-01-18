using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Ore.Infrastructure.Common;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    public class ParticipationApi
    {
        public IParticipation GetLatest(string stockCode)
        {
            string url = string.Format(@"http://data.eastmoney.com/stockcomment/{0}.html", stockCode);

            string html = PageReader.GetPageSource(url);
            if (string.IsNullOrEmpty(html))
                return null;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var htmlNodes = htmlDocument.DocumentNode;

            Participation partObj = new Participation();

            //数据日期：2015-12-25 
            string xpathTime = "/html[1]/body[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[5]/table[1]/tr[1]/td[3]/span[1]";
            var strTime =  Regex.Match(htmlNodes.SelectSingleNode(xpathTime).InnerText, @"\d{4}-\d{2}-\d{2}").Value;
            /// 日期与时间
            DateTime Time = DateTime.MaxValue;
            if (DateTime.TryParse(strTime, out Time))
                partObj.Time = Time;

            //机构参与度为41.08%，属于完全控盘 
            string xpathValue = "/html[1]/body[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[5]/table[1]/tr[1]/td[2]/span[1]";
            var strValue = Regex.Match(htmlNodes.SelectSingleNode(xpathValue).InnerText, @"\d+.\d+").Value;
            /// 机构参与度（%） : 45
            double Value = 0;
            if (double.TryParse(strValue, out Value))
                partObj.Value = Value;

            //主力净流入-398.90万，超大单流入7166.17万 
            //-398.90
            string xpathMainForceInflows = "/html[1]/body[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[5]/table[1]/tr[2]/td[2]/span[1]/span[1]";
            var strMainForceInflows = htmlNodes.SelectSingleNode(xpathMainForceInflows).InnerText;
            /// 主力净流入
            double MainForceInflows = 0;
            if (double.TryParse(strMainForceInflows, out MainForceInflows))
                partObj.MainForceInflows = MainForceInflows;
            //7166.17
            string xpathSuperLargeInflows = "/html[1]/body[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[5]/table[1]/tr[2]/td[2]/span[1]/span[2]";
            var strSuperLargeInflows = htmlNodes.SelectSingleNode(xpathSuperLargeInflows).InnerText;
            /// 超大单流入
            double SuperLargeInflows = 0;
            if (double.TryParse(strSuperLargeInflows, out SuperLargeInflows))
                partObj.SuperLargeInflows = SuperLargeInflows;

            //最近1日主力成本18.29元，最近20日主力成本17.56元 
            string xpathCostPrice = "/html[1]/body[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[5]/table[1]/tr[3]/td[2]/span[1]";
            var strCostPrice = htmlNodes.SelectSingleNode(xpathCostPrice).InnerText;
            var matchs = Regex.Matches(strCostPrice, @"\d+.\d+");
            /// 最近1日主力成本
            double CostPrice1Day = 0;
            if (matchs != null && double.TryParse(matchs.Count > 0 ? matchs[0].Value : "", out CostPrice1Day))
                partObj.CostPrice1Day = CostPrice1Day;

            /// 最近20日主力成本
            double CostPrice20Day = 0;
            if (matchs != null && double.TryParse(matchs.Count > 1 ? matchs[1].Value : "", out CostPrice20Day))
                partObj.CostPrice20Day = CostPrice20Day;

            return partObj;
        }
    }
}

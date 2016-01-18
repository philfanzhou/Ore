using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Ore.Infrastructure.Common;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    public class StockStructureApi
    {
        private const string WebApiAddress = @"http://vip.stock.finance.sina.com.cn/corp/go.php/vCI_StockStructure/stockid/000002.phtml";

        public IEnumerable<IStockStructure> GetStockStructure(string stockCode)
        {
            string url = string.Format(@"http://vip.stock.finance.sina.com.cn/corp/go.php/vCI_StockStructure/stockid/{0}.phtml", stockCode);

            string html = PageReader.GetPageSource(url);
            if (string.IsNullOrEmpty(html))
                return null;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var titleNode = htmlDocument.DocumentNode.SelectSingleNode("/html[1]/head[1]/title[1]");
            // 简称
            string name = titleNode.InnerText.Substring(0, titleNode.InnerText.IndexOf("("));
            ///// 交易市场
            //Market Market

            string xpath = "/html[1]/body[1]/div[1]/div[9]/div[2]/div[1]/div[3]/table";
            HtmlNodeCollection tableNodes = htmlDocument.DocumentNode.SelectNodes(xpath);
            if (tableNodes == null || tableNodes.Count < 1)
                return null;

            List<SinaStockStructure> lstStockStructure = new List<SinaStockStructure>();            
            foreach (HtmlNode it in tableNodes)
            {
                var colspanNode = it.SelectSingleNode("thead[1]/tr[1]/th[1]");
                int colspan = int.Parse((string)colspanNode.Attributes["colspan"].Value);
                var colspanNodeCount = it.SelectSingleNode("tbody[1]/tr").ChildNodes.Count;
                if (colspanNodeCount < colspan)
                    colspan = colspanNodeCount;
                for (int i = 0; i < colspan - 1; i++)
                {
                    SinaStockStructure stockStructure = new SinaStockStructure();
                    /// 变动日期
                    DateTime DateOfChange = DateTime.MaxValue;
                    if (DateTime.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[1]/td[{0}]", 2 + i)).InnerText, out DateOfChange))
                        stockStructure.DateOfChange = DateOfChange;
                    /// 公告日期
                    DateTime DateOfDeclaration = DateTime.MaxValue;
                    if (DateTime.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[2]/td[{0}]", 2 + i)).InnerText, out DateOfDeclaration))
                        stockStructure.DateOfDeclaration = DateOfDeclaration;
                    /// 变更原因
                    string Reason = it.SelectSingleNode(string.Format("tbody[1]/tr[4]/td[{0}]", 2 + i)).InnerText;
                    /// 总股本
                    double TotalShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[5]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out TotalShares))
                        stockStructure.TotalShares = TotalShares;
                    /// 流通A股
                    double SharesA = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[7]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out SharesA))
                        stockStructure.SharesA = SharesA;
                    /// 高管股
                    double ExecutiveShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[8]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out ExecutiveShares))
                        stockStructure.ExecutiveShares = ExecutiveShares;
                    /// 限售A股
                    double RestrictedSharesA = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[9]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out RestrictedSharesA))
                        stockStructure.RestrictedSharesA = RestrictedSharesA;
                    /// 流通B股
                    double SharesB = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[10]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out SharesB))
                        stockStructure.SharesB = SharesB;
                    /// 限售B股
                    double RestrictedSharesB = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[11]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out RestrictedSharesB))
                        stockStructure.RestrictedSharesB = RestrictedSharesB;
                    /// 流通H股
                    double SharesH = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[12]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out SharesH))
                        stockStructure.SharesH = SharesH;
                    /// 国家股
                    double StateShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[13]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out StateShares))
                        stockStructure.StateShares = StateShares;
                    /// 国有法人股
                    double StateOwnedLegalPersonShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[14]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out StateOwnedLegalPersonShares))
                        stockStructure.StateOwnedLegalPersonShares = StateOwnedLegalPersonShares;
                    /// 境内法人股
                    double DomesticLegalPersonShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[15]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out DomesticLegalPersonShares))
                        stockStructure.DomesticLegalPersonShares = DomesticLegalPersonShares;
                    /// 境内发起人股
                    double DomesticSponsorsShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[16]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out DomesticSponsorsShares))
                        stockStructure.DomesticSponsorsShares = DomesticSponsorsShares;
                    /// 募集法人股
                    double RaiseLegalPersonShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[17]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out RaiseLegalPersonShares))
                        stockStructure.RaiseLegalPersonShares = RaiseLegalPersonShares;
                    /// 一般法人股
                    double GeneralLegalPersonShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[18]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out GeneralLegalPersonShares))
                        stockStructure.GeneralLegalPersonShares = GeneralLegalPersonShares;
                    /// 战略投资者持股
                    double StrategicInvestorsShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[19]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out StrategicInvestorsShares))
                        stockStructure.StrategicInvestorsShares = StrategicInvestorsShares;
                    /// 基金持股
                    double FundsShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[20]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out FundsShares))
                        stockStructure.FundsShares = FundsShares;
                    /// 转配股
                    double TransferredAllottedShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[21]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out TransferredAllottedShares))
                        stockStructure.TransferredAllottedShares = TransferredAllottedShares;
                    /// 内部职工股
                    double InternalStaffShares = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[22]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out InternalStaffShares))
                        stockStructure.InternalStaffShares = InternalStaffShares;
                    /// 优先股
                    double PreferredStock = 0;
                    if (double.TryParse(it.SelectSingleNode(string.Format("tbody[1]/tr[23]/td[{0}]", 2 + i)).InnerText.Replace("万股", ""), out PreferredStock))
                        stockStructure.PreferredStock = PreferredStock;

                    lstStockStructure.Add(stockStructure);
                }
            }

            return lstStockStructure;
        }
    }
}

//using HtmlAgilityPack;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text.RegularExpressions;

//namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
//{
//    public class StockStructureAPI
//    {
//        private const string WebApiAddress = @"http://quote3.eastmoney.com/f10.aspx?StockCode={0}&stock_name=&f10=003";

//        public IEnumerable<IStockStructure> GetStockStructure(string stockCode)
//        {
//            string url = string.Format(WebApiAddress, stockCode);

//            string html = PageReader.GetPageSource(url);
//            if (string.IsNullOrEmpty(html))
//                return null;

//            var htmlDocument = new HtmlDocument();
//            htmlDocument.LoadHtml(html);

//            HtmlNode maintitleNode = htmlDocument.GetElementbyId("maintitle");
//            string maintitle = maintitleNode.InnerText.Replace("&nbsp;", "");

//            /// 代码
//            string code = maintitle.Substring(maintitle.IndexOf("[") + 1, maintitle.IndexOf("]") - maintitle.IndexOf("[") - 1);
//            /// 简称
//            string shortName = maintitle.Substring(0, maintitle.IndexOf("["));
//            ///// 交易市场
//            //Market Market;//暂无

//            HtmlNode mainNode = htmlDocument.GetElementbyId("maincontent");
//            string[] datas = mainNode.InnerText.Trim().Replace("&nbsp;", "").Split(new string[] { "┌", "─", "┬", "┐", "｜", "┤", "├", "┼", "└", "┴", "┘"}, StringSplitOptions.RemoveEmptyEntries);
//            if (datas == null || datas.Length < 6)
//                throw new Exception("StockStructureAPI_HtmlParser_GetData_NULL");

//            List<StockStructure> lstStockStructure = new List<StockStructure>();

//            //获取最新的股本结构数据
//            string[] latest = datas[1].Split(new string[] { "│" }, StringSplitOptions.RemoveEmptyEntries);
//            var lstMatchStock = Regex.Matches(datas[2], @"[A-Z]*[\u4E00-\u9FFF]*[A-Z]*[\u4E00-\u9FFF]+");
//            var lstMatchMoney = Regex.Matches(datas[2], @"│\d+.\d{2}|│");

//            for (int i = 1; i < latest.Length; i++)
//            {
//                int dateCount = latest.Length - 1;
//                StockStructure ssLatest = new StockStructure() { Code = code, ShortName = shortName }; 
//                /// 变动日期
//                DateTime date = DateTime.MaxValue;               
//                if (DateTime.TryParse(latest[i], out date))
//                    ssLatest.Date = date;

//                for (int j=0; j < lstMatchStock.Count; j++)
//                {
//                    int k = j * dateCount + i - 1;
//                    if (lstMatchStock[j].Value.Contains("总股本"))/// 总股本
//                    {
//                        string totalShares = lstMatchMoney[k].Value.Replace("│", "");
//                        if (!string.IsNullOrEmpty(totalShares))
//                            ssLatest.TotalShares = double.Parse(totalShares);
//                    }
//                    else if (lstMatchStock[j].Value.Contains("A股合计"))/// A股合计
//                    {
//                        string totalSharesA = lstMatchMoney[k].Value.Replace("│", "");
//                        if (!string.IsNullOrEmpty(totalSharesA))
//                            ssLatest.TotalSharesA = double.Parse(totalSharesA);
//                    }
//                    else if (lstMatchStock[j].Value.Contains("实际流通A股")) /// 实际流通A股
//                    {
//                        string sharesA = lstMatchMoney[k].Value.Replace("│", "");
//                        if (!string.IsNullOrEmpty(sharesA))
//                            ssLatest.SharesA = double.Parse(sharesA);
//                    }
//                    else if (lstMatchStock[j].Value.Contains("B股"))/// B股
//                    {
//                        string sharesB = lstMatchMoney[k].Value.Replace("│", "");
//                        if (!string.IsNullOrEmpty(sharesB))
//                            ssLatest.SharesB = double.Parse(sharesB);
//                    }
//                    else if (lstMatchStock[j].Value.Contains("H股"))/// H股
//                    {
//                        string sharesH = lstMatchMoney[k].Value.Replace("│", "");
//                        if (!string.IsNullOrEmpty(sharesH))
//                            ssLatest.SharesH = double.Parse(sharesH);
//                    }
//                    else if (lstMatchStock[j].Value.Contains("变更原因"))/// 变更原因
//                    {
//                        string reason = lstMatchMoney[k].Value.Replace("│", "");
//                        ssLatest.Reason = reason;
//                    }
//                    else
//                    {
//                        //todo:添加其他数据
//                    }
//                }
//                lstStockStructure.Add(ssLatest);
//            }

//            //【历次股本变更状况】(单位:万股)
//            //string[] history = datas[4].Split(new string[] { "│" }, StringSplitOptions.RemoveEmptyEntries);
//            var lstMatch = Regex.Matches(datas[5], @"\d{4}-\d{2}-\d{2}");
//            string[] historyDatas = Regex.Split(datas[5], @"\d{4}-\d{2}-\d{2}");
//            for (int i = 0; i < lstMatch.Count; i++)
//            {
//                string[] hisData = historyDatas[i + 1].Split(new string[] { "│" }, StringSplitOptions.RemoveEmptyEntries);
//                StockStructure ssHistory = new StockStructure() { Code = code, ShortName = shortName };
//                ssHistory.Date = DateTime.Parse(lstMatch[i].Value);
//                ssHistory.TotalShares = (string.IsNullOrEmpty(hisData[0]) ? 0 : double.Parse(hisData[0]));
//                ssHistory.TotalSharesA = (string.IsNullOrEmpty(hisData[1]) ? 0 : double.Parse(hisData[1]));
//                ssHistory.SharesA = (string.IsNullOrEmpty(hisData[2]) ? 0 : double.Parse(hisData[2]));
//                ssHistory.Reason = hisData[3];

//                lstStockStructure.Add(ssHistory);
//            }

//            return lstStockStructure;
//        }

//    }
//}


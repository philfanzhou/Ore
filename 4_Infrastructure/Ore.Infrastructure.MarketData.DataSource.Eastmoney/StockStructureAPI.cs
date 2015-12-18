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

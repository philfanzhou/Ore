using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Ore.Infrastructure.MarketData.DataSource.Sina.Model;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    public class SinaStockBonusAPI
    {
        // 请使用新的数据源地址 从这个页面获取到的数据，根据对应类型，传入下面的Detail页面获取详细数据
        private const string WebApiAddress = @"http://vip.stock.finance.sina.com.cn/corp/go.php/vISSUE_ShareBonus/stockid/000002.phtml";
        // 分红详细信息地址 参数 end_date= 公告日期 type=1
        private const string DetailInfo1 = @"http://vip.stock.finance.sina.com.cn/corp/view/vISSUE_ShareBonusDetail.php?stockid=000002&type=1&end_date=2015-07-14";
        // 配股详细信息地址 参数 end_date= 公告日期 type=2
        private const string DetailInfo2 = @"http://vip.stock.finance.sina.com.cn/corp/view/vISSUE_ShareBonusDetail.php?stockid=000002&type=2&end_date=1999-12-22";


        public IEnumerable<IStockBonus> GetStockBonus(string stockCode)
        {            
            string url = string.Format(@"http://vip.stock.finance.sina.com.cn/corp/go.php/vISSUE_ShareBonus/stockid/{0}.phtml", stockCode);

            string pageHtml = PageReader.GetPageSource(url);
            if (string.IsNullOrEmpty(pageHtml))
                return null;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageHtml);

            HtmlNode titleNode = htmlDocument.DocumentNode.SelectSingleNode("//title");
            string name = titleNode.InnerText.Substring(0, titleNode.InnerText.IndexOf("("));

            HtmlNode nodeSharebonus_1 = htmlDocument.GetElementbyId("sharebonus_1");
            HtmlNode nodeSharebonus_2 = htmlDocument.GetElementbyId("sharebonus_2");
            
            List<IStockBonus> lstStockBonus = new List<IStockBonus>();

            var lstNodes1 = nodeSharebonus_1.SelectNodes("tbody/tr");
            foreach (var item in lstNodes1)
            {
                var nodes = item.SelectNodes("td");
                string urlDetails = string.Format(@"http://vip.stock.finance.sina.com.cn/{0}", item.SelectSingleNode("td/a").Attributes["href"].Value);
                var stockBonus = new SinaStockBonusData()
                {
                    Code = stockCode,
                    ShortName = name,
                    DateOfDeclaration = DateTime.Parse(nodes[0].InnerText),// 公告日期
                    Type = BounsType.ProfitSharing,// 分红类型
                    ExdividendDate = DateTime.Parse(nodes[5].InnerText),// 除权除息日
                    RegisterDate = DateTime.Parse(nodes[6].InnerText), // 股权登记日
                };

                StockBonusDetailsParser(urlDetails, ref stockBonus);
                lstStockBonus.Add(stockBonus);
            }
           
            var lstNodes2 = nodeSharebonus_2.SelectNodes("tbody/tr");
            foreach (var item in lstNodes2)
            {
                var nodes = item.SelectNodes("td");
                string urlDetails = string.Format(@"http://vip.stock.finance.sina.com.cn/{0}", item.SelectSingleNode("td/a").Attributes["href"].Value);
                var stockBonus = new SinaStockBonusData()
                {
                    Code = stockCode,
                    ShortName = name,
                    DateOfDeclaration = DateTime.Parse(nodes[0].InnerText),// 公告日期
                    Type = BounsType.StockOption,// 配股类型
                    ExdividendDate = DateTime.Parse(nodes[4].InnerText),// 除权除息日
                    RegisterDate = DateTime.Parse(nodes[5].InnerText), // 股权登记日
                };

                StockBonusDetailsParser(urlDetails, ref stockBonus);
                lstStockBonus.Add(stockBonus);
            }            

            return lstStockBonus;
        }

        private void StockBonusDetailsParser(string url, ref SinaStockBonusData data)
        {
            string pageHtml = PageReader.GetPageSource(url);
            if (string.IsNullOrEmpty(pageHtml))
                return;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageHtml);

            HtmlNode sharebonusdetail = htmlDocument.GetElementbyId("sharebonusdetail");
            var lstTdNodes = sharebonusdetail.SelectNodes("tr/td");

            double PreTaxDividend = 0;// 税前红利（10派）（报价币种）
            if (double.TryParse(lstTdNodes[1].InnerText, out PreTaxDividend))
                data.PreTaxDividend = PreTaxDividend;
            double DividendAfterTax = 0;// 税后红利（10派）（报价币种）
            if (double.TryParse(lstTdNodes[3].InnerText, out DividendAfterTax))
                data.DividendAfterTax = DividendAfterTax;
            double BAndHPreTaxDividend = 0;// B、H股税前红利（人民币）
            if (double.TryParse(lstTdNodes[5].InnerText, out BAndHPreTaxDividend))
                data.BAndHPreTaxDividend = BAndHPreTaxDividend;
            double BAndHDividendAfterTax = 0;// B、H股税后红利（人民币）
            if (double.TryParse(lstTdNodes[7].InnerText, out BAndHDividendAfterTax))
                data.BAndHDividendAfterTax = BAndHDividendAfterTax;
            double BonusRate = 0;// 送股比例（10送）
            if (double.TryParse(lstTdNodes[9].InnerText, out BonusRate))
                data.BonusRate = BonusRate;

            double IncreaseRate = 0;// 转增比例（10转增）
            if (double.TryParse(lstTdNodes[11].InnerText, out IncreaseRate))
                data.IncreaseRate = IncreaseRate;
            double ReserveSurplusIncreaseRate = 0;// 盈余公积金转增比例（10转增）
            if (double.TryParse(lstTdNodes[13].InnerText, out ReserveSurplusIncreaseRate))
                data.ReserveSurplusIncreaseRate = ReserveSurplusIncreaseRate;
            double CapitalSurplusIncreaseRate = 0;// 资本公积金转增比例（10转增）
            if (double.TryParse(lstTdNodes[15].InnerText, out CapitalSurplusIncreaseRate))
                data.CapitalSurplusIncreaseRate = CapitalSurplusIncreaseRate;
            string IssuingObject = lstTdNodes[17].InnerText;// 发放对象
            DateTime CapitalStockBaseDate = DateTime.MaxValue;// 股本基准日
            if (DateTime.TryParse(lstTdNodes[19].InnerText, out CapitalStockBaseDate))
                data.CapitalStockBaseDate = CapitalStockBaseDate;

            DateTime LastTradingDay = DateTime.MaxValue;// 最后交易日
            if (DateTime.TryParse(lstTdNodes[21].InnerText, out LastTradingDay))
                data.LastTradingDay = LastTradingDay;
            DateTime StartOrArriveDate = DateTime.MaxValue;// 红利/配股起始日（送、转股到账日)
            if (DateTime.TryParse(lstTdNodes[27].InnerText, out StartOrArriveDate))
                data.StartOrArriveDate = StartOrArriveDate;
            DateTime ExpirationDate = DateTime.MaxValue;// 红利/配股终止日
            if (DateTime.TryParse(lstTdNodes[29].InnerText, out ExpirationDate))
                data.ExpirationDate = ExpirationDate;

            DateTime DispatchListingDate = DateTime.MaxValue;// 配股上市日
            if (DateTime.TryParse(lstTdNodes[31].InnerText, out DispatchListingDate))
                data.DispatchListingDate = DispatchListingDate;
            DateTime ResolutionOfShareholdersMeetingDate = DateTime.MaxValue;// 股东大会决议公告日期
            if (DateTime.TryParse(lstTdNodes[33].InnerText, out ResolutionOfShareholdersMeetingDate))
                data.ResolutionOfShareholdersMeetingDate = ResolutionOfShareholdersMeetingDate;
            DateTime ConvertibleBondDate = DateTime.MaxValue;// 可转债享受权益转股截止日
            if (DateTime.TryParse(lstTdNodes[35].InnerText, out ConvertibleBondDate))
                data.ConvertibleBondDate = ConvertibleBondDate;
            double DispatchRate = 0;// 配股比例（10配）
            if (double.TryParse(lstTdNodes[37].InnerText, out DispatchRate))
                data.DispatchRate = DispatchRate;
            double DispatchPrice = 0;// 配股价
            if (double.TryParse(lstTdNodes[39].InnerText, out DispatchPrice))
                data.DispatchPrice = DispatchPrice;

            double TransferredAllottedRate = 0;// 转配比例
            if (double.TryParse(lstTdNodes[41].InnerText, out TransferredAllottedRate))
                data.TransferredAllottedRate = TransferredAllottedRate;
            double TransferredAllottedPrice = 0;// 转配价
            if (double.TryParse(lstTdNodes[43].InnerText, out TransferredAllottedPrice))
                data.TransferredAllottedPrice = TransferredAllottedPrice;
            DateTime DispatchExpiryDate = DateTime.MaxValue;// 配股有效期
            if (DateTime.TryParse(lstTdNodes[45].InnerText, out DispatchExpiryDate))
                data.DispatchExpiryDate = DispatchExpiryDate;
            double TotalDispatch = 0;// 实际配股数 (万股)
            if (double.TryParse(lstTdNodes[47].InnerText, out TotalDispatch))
                data.TotalDispatch = TotalDispatch;
            double CapitalStockBeforeDispatch = 0;// 配股前总股本 (万股)
            if (double.TryParse(lstTdNodes[49].InnerText, out CapitalStockBeforeDispatch))
                data.CapitalStockBeforeDispatch = CapitalStockBeforeDispatch;

            double ActualDispatchRate = 0;// 实际配股比例
            if (double.TryParse(lstTdNodes[51].InnerText, out ActualDispatchRate))
                data.ActualDispatchRate = ActualDispatchRate;
            double ShareSplitCount = 0;// 每股拆细数
            if (double.TryParse(lstTdNodes[53].InnerText, out ShareSplitCount))
                data.ShareSplitCount = ShareSplitCount;
            double ExchangeRate = 0;// 外币折算汇率
            if (double.TryParse(lstTdNodes[55].InnerText, out ExchangeRate))
                data.ExchangeRate = ExchangeRate;
            string Description = lstTdNodes[57].InnerText;// 权息说明
        }
    }
}

using HtmlAgilityPack;
using System;
using System.Text;
using Ore.Infrastructure.Common;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    public class StockProfileApi
    {
        //http://f10.eastmoney.com/f10_v2/CompanySurvey.aspx?code=sz000002

        /// <summary>
        /// 获取股票基本信息数据
        /// </summary>
        /// <param name="stockCode">参数例子：sz000002</param>
        /// <returns>有返回IStockProfile对象，没有返回null</returns>
        public IStockProfile GetStockProfile(string stockCode)
        {
            string url = string.Format(@"http://f10.eastmoney.com/f10_v2/CompanySurvey.aspx?code={0}", DataConverter.GetStockCodeWithMarket(stockCode));

            string html = PageReader.GetPageSource(url, Encoding.UTF8);
            if (string.IsNullOrEmpty(html))
                return null;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var htmlNodes = htmlDocument.DocumentNode;            

            StockProfile stockProfile = new StockProfile();
            /// 公司名称
            stockProfile.FullName = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[1]/td[1]").InnerText;
            /// 公司英文名称
            stockProfile.EnglishName = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[2]/td[1]").InnerText;
            /// 曾用名
            stockProfile.NameUsedBefore = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[3]/td[1]").InnerText;
            /// A股交易代码
            stockProfile.CodeA = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[4]/td[1]").InnerText;
            /// A股证券简称
            stockProfile.ShortNameA = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[4]/td[2]").InnerText;
            /// B股交易代码
            stockProfile.CodeB = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[5]/td[1]").InnerText;
            /// B股证券简称
            stockProfile.ShortNameB = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[5]/td[2]").InnerText;
            /// H股交易代码
            stockProfile.CodeH = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[6]/td[1]").InnerText;
            //H股简称
            stockProfile.ShortNameH = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[6]/td[2]").InnerText;

            /// 证券交易所//证券类别
            stockProfile.Exchange = DataConverter.GetMarketByString(htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[7]/td[1]").InnerText);
            /// 所属行业
            stockProfile.Industry = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[7]/td[2]").InnerText;
            /// 总经理
            stockProfile.GeneralManager = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[8]/td[1]").InnerText;
            /// 法人代表
            stockProfile.LegalRepresentative = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[8]/td[2]").InnerText;
            /// 董秘
            stockProfile.BoardSecretary = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[9]/td[1]").InnerText;
            /// 董事长
            stockProfile.Chairman = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[9]/td[2]").InnerText;
            /// 证券事务代表
            stockProfile.SecuritiesAffairsRepresentatives = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[10]/td[1]").InnerText;
            /// 独立董事
            stockProfile.IndependentDirectors = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[10]/td[2]").InnerText;
            /// 联系电话
            stockProfile.ContactNumber = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[11]/td[1]").InnerText;
            /// 电子信箱
            stockProfile.Email = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[11]/td[2]").InnerText;
            /// 传真
            stockProfile.Fax = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[12]/td[1]").InnerText;
            /// 公司网址
            stockProfile.Website = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[12]/td[2]").InnerText;
            /// 办公地址
            stockProfile.OfficeAddress = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[13]/td[1]").InnerText;
            /// 注册地址
            stockProfile.RegisteredAddress = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[13]/td[2]").InnerText;
            /// 区域
            stockProfile.Area = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[14]/td[1]").InnerText;
            /// 邮政编码
            stockProfile.ZipCode = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[14]/td[2]").InnerText;
            /// 注册资本(元)
            //decimal RegisteredCapital = decimal.Zero;
            //if (decimal.TryParse(htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[15]/td[1]").InnerText, out RegisteredCapital))
            //    stockProfile.RegisteredCapital = RegisteredCapital; 
            stockProfile.RegisteredCapital = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[15]/td[1]").InnerText;
            /// 工商登记
            stockProfile.BusinessRegistration = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[15]/td[2]").InnerText;
            /// 雇员人数
            int NumberOfEmployees = 0;
            if (int.TryParse(htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[16]/td[1]").InnerText, out NumberOfEmployees))
                stockProfile.NumberOfEmployees = NumberOfEmployees;
            /// 管理人员人数
            int NumberOfManagement = 0;
            if (int.TryParse(htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[16]/td[2]").InnerText, out NumberOfManagement))
                stockProfile.NumberOfManagement = NumberOfManagement;
            /// 律师事务所
            stockProfile.LawOffice = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[17]/td[1]").InnerText;
            /// 会计师事务所
            stockProfile.AccountingFirm = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[17]/td[2]").InnerText;
            /// 公司简介
            stockProfile.CompanyProfile = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[18]/td[1]").InnerText;
            /// 主营业务范围
            stockProfile.PrimeBusiness = htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[2]/table[1]/tr[19]/td[1]").InnerText;
            /// 成立日期
            DateTime EstablishmentDate = DateTime.MaxValue;
            if (DateTime.TryParse(htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[13]/div[2]/table[1]/tr[1]/td[1]").InnerText, out EstablishmentDate))
                stockProfile.EstablishmentDate = EstablishmentDate;
            /// 上市日期
            DateTime ListDate = DateTime.MaxValue;
            if (DateTime.TryParse(htmlNodes.SelectSingleNode("/html[1]/body[1]/div[1]/div[13]/div[2]/table[1]/tr[1]/td[2]").InnerText, out ListDate))
                stockProfile.ListDate = ListDate;

            return stockProfile;
        } 
    }
}

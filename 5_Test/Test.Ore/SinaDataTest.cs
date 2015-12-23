using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System.Collections.Generic;
using System.Linq;

namespace Test.Ore
{
    [TestClass]
    public class SinaDataTest
    {
        [TestMethod]
        public void SinaRealTimeDataConstructorTest()
        {
            StockRealTimeApi reader = new StockRealTimeApi();
            IStockRealTime data = reader.GetData("600036");
            Assert.IsNotNull(data);
            Assert.AreEqual(Market.XSHG, data.Market);
            Assert.AreEqual("600036", data.Code);
            Assert.AreEqual("招商银行", data.ShortName);

            data = null;
            data = reader.GetData("399001");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void GetMultipleDataTest()
        {
            string[] codes = new string[] 
            {
                "600036",
                "150209",
                "600518",
                "300118",
                "601009",
                "601933",
                "600660",
                "600196",
            };
            StockRealTimeApi reader = new StockRealTimeApi();
            List<IStockRealTime> datas = reader.GetData(codes).ToList();

            Assert.IsNotNull(datas);
            for(int i = 0; i < codes.Length; i++)
            {
                Assert.AreEqual(codes[i], datas[i].Code);
            }
        }

        [TestMethod]
        public void TestStructureInfo()
        {
            List<IStockStructure> result = new StockStructureApi().GetStockStructure("600036").ToList();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestBonusInfo()
        {
            List<IStockBonus> result = new StockBonusApi().GetStockBonus("600036").ToList();
            Assert.IsNotNull(result);
        }
    }

    internal class Stock : ISecurity
    {
        public string Code
        {
            get; set;
        }

        public Market Market
        {
            get; set;
        }

        public string ShortName
        {
            get; set;
        }

        public SecurityType Type
        {
            get
            {
                return SecurityType.Sotck;
            }
        }
    }
}

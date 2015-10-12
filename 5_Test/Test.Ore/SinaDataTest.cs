using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System.Collections.Generic;

namespace Test.Ore
{
    [TestClass]
    public class SinaDataTest
    {
        [TestMethod]
        public void SinaRealTimeDataConstructorTest()
        {
            SinaRealTimePriceAPI reader = new SinaRealTimePriceAPI();
            IStockRealTimePrice data = reader.GetData(new Stock { Code = "600036", Market = Market.XSHG});
            Assert.IsNotNull(data);
            Assert.AreEqual("sh600036", data.Code);
            Assert.AreEqual("招商银行", data.ShortName);

            data = null;
            data = reader.GetData(new Stock { Code = "399001", Market = Market.XSHE });
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void GetMultipleDataTest()
        {
            Stock[] codes = new Stock[] 
            {
                new Stock { Code = "600036", Market = Market.XSHG},
                new Stock { Code = "150209", Market = Market.XSHE },
                new Stock { Code = "600518", Market = Market.XSHG},
                new Stock { Code = "300118", Market = Market.XSHE },
                new Stock { Code = "600298", Market = Market.XSHG},
                new Stock { Code = "601009", Market = Market.XSHG},
                new Stock { Code = "601933", Market = Market.XSHG},
                new Stock { Code = "600660", Market = Market.XSHG},
                new Stock { Code = "600196", Market = Market.XSHG}
            };
            SinaRealTimePriceAPI reader = new SinaRealTimePriceAPI();
            IEnumerable<IStockRealTimePrice> datas = reader.GetData(codes);

            Assert.IsNotNull(datas);
            foreach(IStockRealTimePrice data in datas)
            {
                Assert.IsNotNull(data);
            }
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

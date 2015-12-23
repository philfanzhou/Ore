using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using Ore.Infrastructure.MarketData.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Ore
{
    [TestClass]
    public class EastmoneyDataTest
    {
        [TestMethod]
        public void TestReadOrgPercentData()
        {
            var data = new EastmoneyDataReader().Get("600036");
            
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Code == "600036");
            Assert.IsTrue(data.Value != 0);
            Assert.IsTrue(data.Zhuli != 0);
            Assert.IsTrue(data.Chaoda != 0);
            Assert.IsTrue(data.Day.Year == DateTime.Now.Year);
        }

        [TestMethod]
        public void TestReadSecurityInfo()
        {
            var securities = new SecurityInfoApi().GetAllSecurity();

            Assert.IsNotNull(securities);
        }

        [TestMethod]
        public void TestProfileInfo()
        {
            IStockProfile result = new StockProfileApi().GetStockProfile("600036");
            Assert.IsNotNull(result);
        }
    }
}

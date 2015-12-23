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
        public void TestReadSecurityInfo()
        {
            var securities = new SecurityInfoApi().GetAllSecurity().ToList();
            Assert.IsNotNull(securities);
            Assert.IsTrue(securities.Count > 0);
        }

        [TestMethod]
        public void TestProfileInfo()
        {
            IStockProfile result = new StockProfileApi().GetStockProfile("sh600036");
            Assert.IsNotNull(result);
            Assert.AreEqual("600036", result.CodeA);
        }

        [TestMethod]
        public void TestParticipationInfo()
        {
            IParticipation result = new ParticipationApi().GetLatest("600036");
            Assert.IsNotNull(result);
            Assert.AreEqual("600036", result.Code);
            Assert.IsTrue(result.Value != 0);
            Assert.IsTrue(result.MainForceInflows != 0);
            Assert.IsTrue(result.SuperLargeInflows != 0);
        }
    }
}

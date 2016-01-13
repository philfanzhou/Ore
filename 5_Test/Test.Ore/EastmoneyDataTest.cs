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
            IStockProfile result = new StockProfileApi().GetStockProfile("600036");
            Assert.IsNotNull(result);
            Assert.AreEqual("600036", result.CodeA); 

            IStockProfile result1 = new StockProfileApi().GetStockProfile("600518");
            Assert.IsNotNull(result1);
            Assert.AreEqual("600518", result1.CodeA);
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

            IParticipation result1 = new ParticipationApi().GetLatest("600518");
            Assert.IsNotNull(result1);
            Assert.AreEqual("600518", result1.Code);
            Assert.IsTrue(result1.Value != 0);
            Assert.IsTrue(result1.MainForceInflows != 0);
            Assert.IsTrue(result1.SuperLargeInflows != 0);
        }
    }
}

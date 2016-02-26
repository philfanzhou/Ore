using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Wmcloud;
using System.Collections.Generic;

namespace Test.Ore
{
    [TestClass]
    public class WmcloudDataTest
    {
        [TestMethod]
        public void WmcloudKLineMultipleDataTest()
        {
            StockKLineApi reader = new StockKLineApi();
            List<StockKLine> datas = reader.GetKLineFromWmcloudApi("600000");
            Assert.IsNotNull(datas);
        }

        [TestMethod]
        public void WmcloudKLineMultipleDataTest1()
        {
            StockKLineApi reader = new StockKLineApi();
            List<StockKLine> datas = reader.GetKLineFromWmcloudApi("166105");
            Assert.IsNull(datas);
        }
    }
}

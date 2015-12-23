using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData.DataSource.TongHuaShun;
using System;

namespace Test.Ore
{
    [TestClass]
    public class TongHuaShunDataTest
    {
        private string dataFolder = Environment.CurrentDirectory + @"\TestData";

        [TestMethod]
        public void TestConstructor()
        {
            var reader = ReaderFactory.Create(dataFolder);
            Assert.AreEqual(dataFolder, reader.DataFolder);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructor1()
        {
            ReaderFactory.Create(string.Empty);
        }
    }
}

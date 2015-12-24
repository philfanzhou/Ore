﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData.DataSource.TongHuaShun;
using System;
using System.Linq;

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

        [TestMethod]
        public void TestReadKLineDay()
        {
            var reader = ReaderFactory.Create(dataFolder);

            // 测试上海数据
            var day600036 = reader.GetDayKLine("600036");
            Assert.AreEqual("600036", day600036.Symbol);
            var day600036kLineItems = day600036.Items.ToList();

            var data_600036_20150601 = day600036kLineItems[0];
            Assert.AreEqual(5176270700, data_600036_20150601.Amount);
            Assert.AreEqual(18.83, data_600036_20150601.Close);
            Assert.AreEqual(new DateTime(2015, 6, 1), data_600036_20150601.Date);
            Assert.AreEqual(18.99, data_600036_20150601.High);
            Assert.AreEqual(17.62, data_600036_20150601.Low);
            Assert.AreEqual(17.92, data_600036_20150601.Open);
            Assert.AreEqual(280927290, data_600036_20150601.Volume);

            var data_600036_20150608 = day600036kLineItems[5];
            Assert.AreEqual(10671410100, data_600036_20150608.Amount);
            Assert.AreEqual(21.13, data_600036_20150608.Close);
            Assert.AreEqual(new DateTime(2015, 6, 8), data_600036_20150608.Date);
            Assert.AreEqual(21.2, data_600036_20150608.High);
            Assert.AreEqual(19.61, data_600036_20150608.Low);
            Assert.AreEqual(20.04, data_600036_20150608.Open);
            Assert.AreEqual(515964160, data_600036_20150608.Volume);

            var data_600036_20151223 = day600036kLineItems[139];
            Assert.AreEqual(2005574200, data_600036_20151223.Amount);
            Assert.AreEqual(18.19, data_600036_20151223.Close);
            Assert.AreEqual(new DateTime(2015, 12, 23), data_600036_20151223.Date);
            Assert.AreEqual(18.71, data_600036_20151223.High);
            Assert.AreEqual(18.17, data_600036_20151223.Low);
            Assert.AreEqual(18.28, data_600036_20151223.Open);
            Assert.AreEqual(108842854, data_600036_20151223.Volume);

            // 测试指数数据
            var day1A0001 = reader.GetDayKLine("1A0001");
            Assert.AreEqual("1A0001", day1A0001.Symbol);
            var day1A0001kLineItems = day1A0001.Items.ToList();

            var data_1A0001_20150601 = day1A0001kLineItems[0];
            Assert.AreEqual(934455500000, data_1A0001_20150601.Amount);
            Assert.AreEqual(4828.738, data_1A0001_20150601.Close);
            Assert.AreEqual(new DateTime(2015, 6, 1), data_1A0001_20150601.Date);
            Assert.AreEqual(4829.502, data_1A0001_20150601.High);
            Assert.AreEqual(4615.231, data_1A0001_20150601.Low);
            Assert.AreEqual(4633.098, data_1A0001_20150601.Open);
            Assert.AreEqual(59338903000, data_1A0001_20150601.Volume);

            var data_1A0001_20150608 = day1A0001kLineItems[5];
            Assert.AreEqual(1309924500000, data_1A0001_20150608.Amount);
            Assert.AreEqual(5131.88, data_1A0001_20150608.Close);
            Assert.AreEqual(new DateTime(2015, 6, 8), data_1A0001_20150608.Date);
            Assert.AreEqual(5146.949, data_1A0001_20150608.High);
            Assert.AreEqual(4997.481, data_1A0001_20150608.Low);
            Assert.AreEqual(5045.694, data_1A0001_20150608.Open);
            Assert.AreEqual(85503508000, data_1A0001_20150608.Volume);

            var data_1A0001_20151223 = day1A0001kLineItems[139];
            Assert.AreEqual(419902920000, data_1A0001_20151223.Amount);
            Assert.AreEqual(3636.089, data_1A0001_20151223.Close);
            Assert.AreEqual(new DateTime(2015, 12, 23), data_1A0001_20151223.Date);
            Assert.AreEqual(3684.567, data_1A0001_20151223.High);
            Assert.AreEqual(3633.025, data_1A0001_20151223.Low);
            Assert.AreEqual(3653.281, data_1A0001_20151223.Open);
            Assert.AreEqual(29820180000, data_1A0001_20151223.Volume);

            // 测试深圳数据
            var day000400 = reader.GetDayKLine("000400");
            Assert.AreEqual("000400", day000400.Symbol);
            var day000400kLineItems = day000400.Items.ToList();

            var data_000400_20150601 = day000400kLineItems[0];
            Assert.AreEqual(1100802350, data_000400_20150601.Amount);
            Assert.AreEqual(32.05, data_000400_20150601.Close);
            Assert.AreEqual(new DateTime(2015, 6, 1), data_000400_20150601.Date);
            Assert.AreEqual(32.21, data_000400_20150601.High);
            Assert.AreEqual(30.5, data_000400_20150601.Low);
            Assert.AreEqual(30.9, data_000400_20150601.Open);
            Assert.AreEqual(34821362, data_000400_20150601.Volume);
        }
    }
}

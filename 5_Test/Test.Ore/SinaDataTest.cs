using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Test.Ore
{
    [TestClass]
    public class SinaDataTest
    {
        [TestMethod]
        public void TestGetDataByInvalidCode()
        {
            Assert.IsNull(new StockRealTimeApi().GetData("12345"));
            Assert.AreEqual(new StockRealTimeApi().GetData(new string[] { "12345" }).ToList().Count, 0);
            Assert.IsNull(new StockKLineApi().GetLatest("12345"));
            Assert.AreEqual(new StockKLineApi().GetLatest(new string[] { "12345" }).ToList().Count, 0);
        }

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
            List<IStockRealTime> datas = reader.GetData(codes).Select(p => p.Value).ToList();

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

            List<IStockStructure> result1 = new StockStructureApi().GetStockStructure("600518").ToList();
            Assert.IsNotNull(result1);
        }

        [TestMethod]
        public void TestBonusInfo()
        {
            var api = new StockBonusApi();

            //Assert.AreEqual(api.GetStockBonus("12345").Count(), 0);

            List<IStockBonus> result = api.GetStockBonus("600036").ToList();
            Assert.IsNotNull(result);

            List<IStockBonus> result1 = api.GetStockBonus("600518").ToList();
            Assert.IsNotNull(result1);
        }

        private void CompareStockKLineDataField(IStockKLine expected, IStockKLine actual)
        {
            Assert.AreEqual(expected.Amount, actual.Amount);
            Assert.AreEqual(expected.Close, actual.Close);
            Assert.AreEqual(expected.High, actual.High);
            Assert.AreEqual(expected.Low, actual.Low);
            Assert.AreEqual(expected.Open, actual.Open);
            Assert.IsTrue(expected.Time >= actual.Time);
            Assert.AreEqual(expected.Volume, actual.Volume);
        }

        private class ExampleStockKLineData : IStockKLine
        {
            public double Amount { get; internal set; }
            public double Close { get; internal set; }
            public double High { get; internal set; }
            public double Low { get; internal set; }
            public double Open { get; internal set; }
            public DateTime Time { get; internal set; }
            public double Volume { get; internal set; }
        }
        //"600036"
        private IStockKLine ExampleData_600036_20160115()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 15, 15, 0, 0),
                // 今开
                Open = 15.87,
                // 最高
                High = 15.92,
                // 最低
                Low = 15.45,
                // 收盘
                Close = 15.48,
                // 成交量
                Volume = 34421564,
                // 成交额
                Amount = 539614094
            };
        }
        //"150209"
        private IStockKLine ExampleData_150209_20160115()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 15, 15, 0, 0),
                // 今开
                Open = 0.972,
                // 最高
                High = 0.982,
                // 最低
                Low = 0.967,
                // 收盘
                Close = 0.980,
                // 成交量
                Volume = 51584478,
                // 成交额
                Amount = 50275348.698
            };
        }
        //"600518"
        private IStockKLine ExampleData_600518_20160115()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 15, 15, 0, 0),
                // 今开
                Open = 13.40,
                // 最高
                High = 13.45,
                // 最低
                Low = 12.70,
                // 收盘
                Close = 13.20,
                // 成交量
                Volume = 33897595,
                // 成交额
                Amount = 442782040,
            };
        }
        //"300118"
        private IStockKLine ExampleData_300118_20160115()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 15, 15, 0, 0),
                // 今开
                Open = 11.99,
                // 最高
                High = 12.20,
                // 最低
                Low = 11.53,
                // 收盘
                Close = 11.79,
                // 成交量
                Volume = 13797675,
                // 成交额
                Amount = 164059904.2,
            };
        }
        //"601009"
        private IStockKLine ExampleData_601009_20160115()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 15, 15, 0, 0),
                // 今开
                Open = 15.60,
                // 最高
                High = 16.13,
                // 最低
                Low = 15.45,
                // 收盘
                Close = 15.69,
                // 成交量
                Volume = 38500392,
                // 成交额
                Amount = 606207482,
            };
        }
        //"601933"
        private IStockKLine ExampleData_601933_20160115()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 15, 15, 0, 0),
                // 今开
                Open = 8.38,
                // 最高
                High = 8.39,
                // 最低
                Low = 8.03,
                // 收盘
                Close = 8.10,
                // 成交量
                Volume = 20769236,
                // 成交额
                Amount = 170332047,
            };
        }
        //"600660"
        private IStockKLine ExampleData_600660_20160115()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 15, 15, 0, 0),
                // 今开
                Open = 14.30,
                // 最高
                High = 14.33,
                // 最低
                Low = 13.83,
                // 收盘
                Close = 13.94,
                // 成交量
                Volume = 8111174,
                // 成交额
                Amount = 113889119,
            };
        }
        //"600196"
        private IStockKLine ExampleData_600196_20160115()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 15, 15, 0, 0),
                // 今开
                Open = 20.01,
                // 最高
                High = 20.17,
                // 最低
                Low = 19.60,
                // 收盘
                Close = 19.77,
                // 成交量
                Volume = 11300768,
                // 成交额
                Amount = 224906356,
            };
        }

        [TestMethod]
        public void SinaStockKLineDataTest()
        {
            StockKLineApi reader = new StockKLineApi();
            IStockKLine data = reader.GetLatest("600036");
            Assert.IsNotNull(data);

            //CompareStockKLineDataField(data, ExampleData_600036_20160115());
        }

        [TestMethod]
        public void SinaStockKLineMultipleDataTest()
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
            StockKLineApi reader = new StockKLineApi();
            List<IStockKLine> datas = reader.GetLatest(codes).Select(p => p.Value).ToList();

            Assert.IsNotNull(datas);
            Assert.AreEqual(datas.Count, codes.Count());
            ////"600036"
            //CompareStockKLineDataField(datas[0], ExampleData_600036_20160115());
            ////"150209"
            //CompareStockKLineDataField(datas[1], ExampleData_150209_20160115());
            ////"600518"
            //CompareStockKLineDataField(datas[2], ExampleData_600518_20160115());
            ////"300118"
            //CompareStockKLineDataField(datas[3], ExampleData_300118_20160115());
            ////"601009"
            //CompareStockKLineDataField(datas[4], ExampleData_601009_20160115());
            ////"601933"
            //CompareStockKLineDataField(datas[5], ExampleData_601933_20160115());
            ////"600660"
            //CompareStockKLineDataField(datas[6], ExampleData_600660_20160115());
            ////"600196"
            //CompareStockKLineDataField(datas[7], ExampleData_600196_20160115());
        }       
    }
}

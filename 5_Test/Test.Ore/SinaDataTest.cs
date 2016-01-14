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

            List<IStockStructure> result1 = new StockStructureApi().GetStockStructure("600518").ToList();
            Assert.IsNotNull(result1);
        }

        [TestMethod]
        public void TestBonusInfo()
        {
            List<IStockBonus> result = new StockBonusApi().GetStockBonus("600036").ToList();
            Assert.IsNotNull(result);

            List<IStockBonus> result1 = new StockBonusApi().GetStockBonus("600518").ToList();
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
        private IStockKLine ExampleData_600036_20160114()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 14, 15, 0, 0),
                // 今开
                Open = 15.55,
                // 最高
                High = 15.96,
                // 最低
                Low = 15.52,
                // 收盘
                Close = 15.89,
                // 成交量
                Volume = 42963031,
                // 成交额
                Amount = 678479480.000
            };
        }
        //"150209"
        private IStockKLine ExampleData_150209_20160114()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 14, 15, 0, 0),
                // 今开
                Open = 0.977,
                // 最高
                High = 0.986,
                // 最低
                Low = 0.968,
                // 收盘
                Close = 0.975,
                // 成交量
                Volume = 113910596,
                // 成交额
                Amount = 111414120.207
            };
        }
        //"600518"
        private IStockKLine ExampleData_600518_20160114()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 14, 15, 0, 0),
                // 今开
                Open = 12.80,
                // 最高
                High = 13.50,
                // 最低
                Low = 12.71,
                // 收盘
                Close = 13.47,
                // 成交量
                Volume = 32828215,
                // 成交额
                Amount = 433023061.000,
            };
        }
        //"300118"
        private IStockKLine ExampleData_300118_20160114()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 14, 15, 0, 0),
                // 今开
                Open = 10.80,
                // 最高
                High = 12.23,
                // 最低
                Low = 10.78,
                // 收盘
                Close = 12.12,
                // 成交量
                Volume = 16492702,
                // 成交额
                Amount = 190668512.070,
            };
        }
        //"601009"
        private IStockKLine ExampleData_601009_20160114()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 14, 15, 0, 0),
                // 今开
                Open = 14.95,
                // 最高
                High = 15.58,
                // 最低
                Low = 14.80,
                // 收盘
                Close = 15.46,
                // 成交量
                Volume = 22183535,
                // 成交额
                Amount = 335495843.000,
            };
        }
        //"601933"
        private IStockKLine ExampleData_601933_20160114()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 14, 15, 0, 0),
                // 今开
                Open = 8.01,
                // 最高
                High = 8.46,
                // 最低
                Low = 7.95,
                // 收盘
                Close = 8.40,
                // 成交量
                Volume = 27046192,
                // 成交额
                Amount = 221910379.000,
            };
        }
        //"600660"
        private IStockKLine ExampleData_600660_20160114()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 14, 15, 0, 0),
                // 今开
                Open = 13.70,
                // 最高
                High = 14.37,
                // 最低
                Low = 13.65,
                // 收盘
                Close = 14.23,
                // 成交量
                Volume = 9746848,
                // 成交额
                Amount = 137311494.000,
            };
        }
        //"600196"
        private IStockKLine ExampleData_600196_20160114()
        {
            return new ExampleStockKLineData()
            {
                // 日期与时间
                Time = new DateTime(2016, 1, 14, 15, 0, 0),
                // 今开
                Open = 19.30,
                // 最高
                High = 20.24,
                // 最低
                Low = 19.04,
                // 收盘
                Close = 20.14,
                // 成交量
                Volume = 12942340,
                // 成交额
                Amount = 255299903.000,
            };
        }

        [TestMethod]
        public void SinaStockKLineDataTest()
        {
            StockKLineApi reader = new StockKLineApi();
            IStockKLine data = reader.GetLatest("600036");
            Assert.IsNotNull(data);

            CompareStockKLineDataField(data, ExampleData_600036_20160114());
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
            List<IStockKLine> datas = reader.GetLatest(codes).ToList();

            Assert.IsNotNull(datas);
            Assert.AreEqual(datas.Count, codes.Count());
            //"600036"
            CompareStockKLineDataField(datas[0], ExampleData_600036_20160114());
            //"150209"
            CompareStockKLineDataField(datas[1], ExampleData_150209_20160114());
            //"600518"
            CompareStockKLineDataField(datas[2], ExampleData_600518_20160114());
            //"300118"
            CompareStockKLineDataField(datas[3], ExampleData_300118_20160114());
            //"601009"
            CompareStockKLineDataField(datas[4], ExampleData_601009_20160114());
            //"601933"
            CompareStockKLineDataField(datas[5], ExampleData_601933_20160114());
            //"600660"
            CompareStockKLineDataField(datas[6], ExampleData_600660_20160114());
            //"600196"
            CompareStockKLineDataField(datas[7], ExampleData_600196_20160114());
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

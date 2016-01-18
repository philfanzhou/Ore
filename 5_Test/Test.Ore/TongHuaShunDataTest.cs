using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.TongHuaShun;
using System;
using System.Linq;

namespace Test.Ore
{
    [TestClass]
    public class TongHuaShunDataTest
    {
        [TestMethod]
        public void TestStockKLineDay()
        {
            var reader = ReaderFactory.Create();

            #region 测试上海数据
            var day600036 = reader.GetKLine("600036", KLineType.Day).ToList();

            var data_600036_20150601 = day600036[0];
            Assert.AreEqual(5176270700, data_600036_20150601.Amount);
            Assert.AreEqual(18.83, data_600036_20150601.Close);
            Assert.AreEqual(new DateTime(2015, 6, 1), data_600036_20150601.Time);
            Assert.AreEqual(18.99, data_600036_20150601.High);
            Assert.AreEqual(17.62, data_600036_20150601.Low);
            Assert.AreEqual(17.92, data_600036_20150601.Open);
            Assert.AreEqual(280927290, data_600036_20150601.Volume);

            var data_600036_20150608 = day600036[5];
            Assert.AreEqual(10671410100, data_600036_20150608.Amount);
            Assert.AreEqual(21.13, data_600036_20150608.Close);
            Assert.AreEqual(new DateTime(2015, 6, 8), data_600036_20150608.Time);
            Assert.AreEqual(21.2, data_600036_20150608.High);
            Assert.AreEqual(19.61, data_600036_20150608.Low);
            Assert.AreEqual(20.04, data_600036_20150608.Open);
            Assert.AreEqual(515964160, data_600036_20150608.Volume);

            var data_600036_20151223 = day600036[139];
            Assert.AreEqual(2005574200, data_600036_20151223.Amount);
            Assert.AreEqual(18.19, data_600036_20151223.Close);
            Assert.AreEqual(new DateTime(2015, 12, 23), data_600036_20151223.Time);
            Assert.AreEqual(18.71, data_600036_20151223.High);
            Assert.AreEqual(18.17, data_600036_20151223.Low);
            Assert.AreEqual(18.28, data_600036_20151223.Open);
            Assert.AreEqual(108842854, data_600036_20151223.Volume);
            #endregion

            #region 测试深圳数据
            var day000400 = reader.GetKLine("000400", KLineType.Day).ToList();

            var data_000400_20150601 = day000400[0];
            Assert.AreEqual(1100802350, data_000400_20150601.Amount);
            Assert.AreEqual(32.05, data_000400_20150601.Close);
            Assert.AreEqual(new DateTime(2015, 6, 1), data_000400_20150601.Time);
            Assert.AreEqual(32.21, data_000400_20150601.High);
            Assert.AreEqual(30.5, data_000400_20150601.Low);
            Assert.AreEqual(30.9, data_000400_20150601.Open);
            Assert.AreEqual(34821362, data_000400_20150601.Volume);
            #endregion
        }

        [TestMethod]
        public void TestStockKLineMin1()
        {
            var reader = ReaderFactory.Create();

            var min1_600036 = reader.GetKLine("600036", KLineType.Min1).ToList();

            var min1_600036_20151203135400 = min1_600036[0];
            Assert.AreEqual(1945900, min1_600036_20151203135400.Amount);
            Assert.AreEqual(17.79, min1_600036_20151203135400.Close);
            Assert.AreEqual(new DateTime(2015, 12, 3, 13, 54, 0), min1_600036_20151203135400.Time);
            Assert.AreEqual(17.79, min1_600036_20151203135400.High);
            Assert.AreEqual(17.78, min1_600036_20151203135400.Low);
            Assert.AreEqual(17.79, min1_600036_20151203135400.Open);
            Assert.AreEqual(109401, min1_600036_20151203135400.Volume);

            var min1_600036_20151223150000 = min1_600036[1276];
            Assert.AreEqual(274500, min1_600036_20151223150000.Amount);
            Assert.AreEqual(18.19, min1_600036_20151223150000.Close);
            Assert.AreEqual(new DateTime(2015, 12, 23, 15, 0, 0), min1_600036_20151223150000.Time);
            Assert.AreEqual(18.19, min1_600036_20151223150000.High);
            Assert.AreEqual(18.18, min1_600036_20151223150000.Low);
            Assert.AreEqual(18.18, min1_600036_20151223150000.Open);
            Assert.AreEqual(15100, min1_600036_20151223150000.Volume);
        }

        [TestMethod]
        public void TestStockKLineMin5()
        {
            var reader = ReaderFactory.Create();

            var min5_600036 = reader.GetKLine("600036", KLineType.Min5).ToList();

            var min5_600036_201512210935 = min5_600036[0];
            Assert.AreEqual(41353406, min5_600036_201512210935.Amount);
            Assert.AreEqual(17.44, min5_600036_201512210935.Close);
            Assert.AreEqual(new DateTime(2015, 12, 21, 9, 35, 0), min5_600036_201512210935.Time);
            Assert.AreEqual(17.48, min5_600036_201512210935.High);
            Assert.AreEqual(17.35, min5_600036_201512210935.Low);
            Assert.AreEqual(17.43, min5_600036_201512210935.Open);
            Assert.AreEqual(2375145, min5_600036_201512210935.Volume);

            var min5_600036_201512231500 = min5_600036[143];
            Assert.AreEqual(60122500, min5_600036_201512231500.Amount);
            Assert.AreEqual(18.19, min5_600036_201512231500.Close);
            Assert.AreEqual(new DateTime(2015, 12, 23, 15, 0, 0), min5_600036_201512231500.Time);
            Assert.AreEqual(18.26, min5_600036_201512231500.High);
            Assert.AreEqual(18.17, min5_600036_201512231500.Low);
            Assert.AreEqual(18.26, min5_600036_201512231500.Open);
            Assert.AreEqual(3299037, min5_600036_201512231500.Volume);

            var min5_000400 = reader.GetKLine("000400", KLineType.Min5).ToList();

            var min5_000400_201512210935 = min5_000400[0];
            Assert.AreEqual(10433224, min5_000400_201512210935.Amount);
            Assert.AreEqual(19.34, min5_000400_201512210935.Close);
            Assert.AreEqual(new DateTime(2015, 12, 21, 9, 35, 0), min5_000400_201512210935.Time);
            Assert.AreEqual(19.38, min5_000400_201512210935.High);
            Assert.AreEqual(19.26, min5_000400_201512210935.Low);
            Assert.AreEqual(19.35, min5_000400_201512210935.Open);
            Assert.AreEqual(539815, min5_000400_201512210935.Volume);

            var min5_000400_201512231500 = min5_000400[143];
            Assert.AreEqual(4871460, min5_000400_201512231500.Amount);
            Assert.AreEqual(19.2, min5_000400_201512231500.Close);
            Assert.AreEqual(new DateTime(2015, 12, 23, 15, 0, 0), min5_000400_201512231500.Time);
            Assert.AreEqual(19.24, min5_000400_201512231500.High);
            Assert.AreEqual(19.2, min5_000400_201512231500.Low);
            Assert.AreEqual(19.24, min5_000400_201512231500.Open);
            Assert.AreEqual(253668, min5_000400_201512231500.Volume);
        }

        [TestMethod]
        public void TestIndexKLineDay()
        {
            var reader = ReaderFactory.Create();

            #region 测试指数数据
            var day1A0001 = reader.GetKLine("1A0001", KLineType.Day).ToList();

            var data_1A0001_20150601 = day1A0001[0];
            Assert.AreEqual(934455500000, data_1A0001_20150601.Amount);
            Assert.AreEqual(4828.738, data_1A0001_20150601.Close);
            Assert.AreEqual(new DateTime(2015, 6, 1), data_1A0001_20150601.Time);
            Assert.AreEqual(4829.502, data_1A0001_20150601.High);
            Assert.AreEqual(4615.231, data_1A0001_20150601.Low);
            Assert.AreEqual(4633.098, data_1A0001_20150601.Open);
            Assert.AreEqual(59338903000, data_1A0001_20150601.Volume);

            var data_1A0001_20150608 = day1A0001[5];
            Assert.AreEqual(1309924500000, data_1A0001_20150608.Amount);
            Assert.AreEqual(5131.88, data_1A0001_20150608.Close);
            Assert.AreEqual(new DateTime(2015, 6, 8), data_1A0001_20150608.Time);
            Assert.AreEqual(5146.949, data_1A0001_20150608.High);
            Assert.AreEqual(4997.481, data_1A0001_20150608.Low);
            Assert.AreEqual(5045.694, data_1A0001_20150608.Open);
            Assert.AreEqual(85503508000, data_1A0001_20150608.Volume);

            var data_1A0001_20151223 = day1A0001[139];
            Assert.AreEqual(419902920000, data_1A0001_20151223.Amount);
            Assert.AreEqual(3636.089, data_1A0001_20151223.Close);
            Assert.AreEqual(new DateTime(2015, 12, 23), data_1A0001_20151223.Time);
            Assert.AreEqual(3684.567, data_1A0001_20151223.High);
            Assert.AreEqual(3633.025, data_1A0001_20151223.Low);
            Assert.AreEqual(3653.281, data_1A0001_20151223.Open);
            Assert.AreEqual(29820180000, data_1A0001_20151223.Volume);
            #endregion
        }

        [TestMethod]
        public void TestIndexKLineMin1()
        {
            var reader = ReaderFactory.Create();
            
            var min1_1A0001 = reader.GetKLine("1A0001", KLineType.Min1).ToList();

            var min1_1A0001_20151221093000 = min1_1A0001[0];
            Assert.AreEqual(4954199200, min1_1A0001_20151221093000.Amount);
            Assert.AreEqual(3566.119, min1_1A0001_20151221093000.Close);
            Assert.AreEqual(3568.58, min1_1A0001_20151221093000.High);
            Assert.AreEqual(3566.107, min1_1A0001_20151221093000.Low);
            Assert.AreEqual(3568.58, min1_1A0001_20151221093000.Open);
            Assert.AreEqual(new DateTime(2015, 12, 21, 9, 30, 0), min1_1A0001_20151221093000.Time);
            Assert.AreEqual(539450900, min1_1A0001_20151221093000.Volume);

            var min1_1A0001_20151221093100 = min1_1A0001[1];
            Assert.AreEqual(2898840400, min1_1A0001_20151221093100.Amount);
            Assert.AreEqual(3567.87, min1_1A0001_20151221093100.Close);
            Assert.AreEqual(3567.87, min1_1A0001_20151221093100.High);
            Assert.AreEqual(3565.814, min1_1A0001_20151221093100.Low);
            Assert.AreEqual(3565.991, min1_1A0001_20151221093100.Open);
            Assert.AreEqual(new DateTime(2015, 12, 21, 9, 31, 0), min1_1A0001_20151221093100.Time);
            Assert.AreEqual(206975900, min1_1A0001_20151221093100.Volume);

            var min1_1A0001_20151221102200 = min1_1A0001[52];
            Assert.AreEqual(1707595000, min1_1A0001_20151221102200.Amount);
            Assert.AreEqual(3608.778, min1_1A0001_20151221102200.Close);
            Assert.AreEqual(3610.187, min1_1A0001_20151221102200.High);
            Assert.AreEqual(3608.778, min1_1A0001_20151221102200.Low);
            Assert.AreEqual(3610.187, min1_1A0001_20151221102200.Open);
            Assert.AreEqual(new DateTime(2015, 12, 21, 10, 22, 0), min1_1A0001_20151221102200.Time);
            Assert.AreEqual(125885100, min1_1A0001_20151221102200.Volume);
        }

        [TestMethod]
        public void TestIndexKLineMin5()
        {
            var reader = ReaderFactory.Create();

            var min5_1A0001 = reader.GetKLine("1A0001", KLineType.Min5).ToList();

            var min5_1A0001_201512210935 = min5_1A0001[0];
            Assert.AreEqual(19231504000, min5_1A0001_201512210935.Amount);
            Assert.AreEqual(3579.401, min5_1A0001_201512210935.Close);
            Assert.AreEqual(3579.416, min5_1A0001_201512210935.High);
            Assert.AreEqual(3565.814, min5_1A0001_201512210935.Low);
            Assert.AreEqual(3568.58, min5_1A0001_201512210935.Open);
            Assert.AreEqual(new DateTime(2015, 12, 21, 9, 35, 0), min5_1A0001_201512210935.Time);
            Assert.AreEqual(1544944400, min5_1A0001_201512210935.Volume);

            var min5_1A0001_201512210940 = min5_1A0001[1];
            Assert.AreEqual(13560410000, min5_1A0001_201512210940.Amount);
            Assert.AreEqual(3580.556, min5_1A0001_201512210940.Close);
            Assert.AreEqual(3580.634, min5_1A0001_201512210940.High);
            Assert.AreEqual(3575.369, min5_1A0001_201512210940.Low);
            Assert.AreEqual(3578.871, min5_1A0001_201512210940.Open);
            Assert.AreEqual(new DateTime(2015, 12, 21, 9, 40, 0), min5_1A0001_201512210940.Time);
            Assert.AreEqual(950878300, min5_1A0001_201512210940.Volume);
            
            var min5_1A0001_201512231420 = min5_1A0001[135];
            Assert.AreEqual(8293350000, min5_1A0001_201512231420.Amount);
            Assert.AreEqual(3675.222, min5_1A0001_201512231420.Close);
            Assert.AreEqual(3675.852, min5_1A0001_201512231420.High);
            Assert.AreEqual(3672.235, min5_1A0001_201512231420.Low);
            Assert.AreEqual(3673.827, min5_1A0001_201512231420.Open);
            Assert.AreEqual(new DateTime(2015, 12, 23, 14, 20, 0), min5_1A0001_201512231420.Time);
            Assert.AreEqual(580945000, min5_1A0001_201512231420.Volume);
        }

        [TestMethod]
        public void TestDividendData()
        {
            var reader = ReaderFactory.Create();
            var dividend600036 = reader.GetDividendData("600036");
            Assert.IsNotNull(dividend600036);

            var items = dividend600036.Items.ToList();
            var item = items[0];
            Assert.AreEqual(0.0, item.Bonus);
            Assert.AreEqual(0.0, item.Cash);
            Assert.AreEqual(new DateTime(2010, 3, 15), item.Date);
            Assert.AreEqual("2010-03-15(每十股 配股1.30股 配股价8.85元)", item.Description);
            Assert.AreEqual(0.13, item.Dispatch);
            Assert.AreEqual(new DateTime(2010, 3, 15), item.ExdividendDate);
            Assert.AreEqual(new DateTime(2010, 3, 19), item.ListingDate);
            Assert.AreEqual(8.85, item.Price);
            Assert.AreEqual(new DateTime(1, 1, 1), item.RegisterDate);
            Assert.AreEqual(0.0, item.Split);

            item = items[5];
            Assert.AreEqual(0.0, item.Bonus);
            Assert.AreEqual(0.0, item.Cash);
            Assert.AreEqual(new DateTime(2013, 9, 5), item.Date);
            Assert.AreEqual("2013-09-05(每十股 配股1.74股 配股价9.29元)", item.Description);
            Assert.AreEqual(0.174, item.Dispatch);
            Assert.AreEqual(new DateTime(2013, 9, 5), item.ExdividendDate);
            Assert.AreEqual(new DateTime(2013, 9, 11), item.ListingDate);
            Assert.AreEqual(9.29, item.Price);
            Assert.AreEqual(new DateTime(1,1,1), item.RegisterDate);
            Assert.AreEqual(0.0, item.Split);

            item = items[6];
            Assert.AreEqual(0.0, item.Bonus);
            Assert.AreEqual(0.62, item.Cash);
            Assert.AreEqual(new DateTime(2014, 7, 11), item.Date);
            Assert.AreEqual("2014-07-11(每十股 红利6.20元 )", item.Description);
            Assert.AreEqual(0.0, item.Dispatch);
            Assert.AreEqual(new DateTime(2014, 7, 11), item.ExdividendDate);
            Assert.AreEqual(new DateTime(1, 1, 1), item.ListingDate);
            Assert.AreEqual(0.0, item.Price);
            Assert.AreEqual(new DateTime(2014, 7, 10), item.RegisterDate);
            Assert.AreEqual(0.0, item.Split);
        }
    }
}

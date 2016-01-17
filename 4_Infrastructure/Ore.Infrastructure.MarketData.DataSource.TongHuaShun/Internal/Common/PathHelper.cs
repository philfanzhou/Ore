using System;
using System.IO;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal static class PathHelper
    {
        private const string _shangHai = @"history\shase\";
        private const string _shenZhen = @"history\sznse\";

        private const string _day = @"day\";
        private const string _dayExt = ".day";

        private const string _min1 = @"min\";
        private const string _min1Ext = ".min";

        private const string _min5 = @"min5\";
        private const string _min5Ext = ".mn5";

        private const string _dividend = @"finance\权息资料.财经";

        private static readonly string _dataFolder = Environment.CurrentDirectory + @"\TongHuaShunData";

        public static string GetKLineFilePath(string stockCode, Market market, KLineType tyep)
        {
            string strMarket = market == Market.XSHG ? _shangHai : _shenZhen;
            string strTypeFolder = string.Empty;
            string strTypeExt = string.Empty;
            switch(tyep)
            {
                case KLineType.Day:
                    strTypeFolder = _day;
                    strTypeExt = _dayExt;
                    break;
                case KLineType.Min1:
                    strTypeFolder = _min1;
                    strTypeExt = _min1Ext;
                    break;
                case KLineType.Min5:
                    strTypeFolder = _min5;
                    strTypeExt = _min5Ext;
                    break;
            }

            return Path.Combine(_dataFolder, strMarket, strTypeFolder, stockCode + strTypeExt);
        }

        public static string ShangHaiDay
        {
            get { return Path.Combine(_dataFolder, _shangHai, _day); }
        }

        public static string ShangHaiMin1
        {
            get { return Path.Combine(_dataFolder, _shangHai, _min1); }
        }

        public static string ShangHaiMin5
        {
            get { return Path.Combine(_dataFolder, _shangHai, _min5); }
        }

        public static string ShenZhenDay
        {
            get { return Path.Combine(_dataFolder, _shenZhen, _day); }
        }

        public static string ShenZhenMin1
        {
            get { return Path.Combine(_dataFolder, _shenZhen, _min1); }
        }

        public static string ShenZhenMin5
        {
            get { return Path.Combine(_dataFolder, _shenZhen, _min5); }
        }

        public static string Dividend
        {
            get { return Path.Combine(_dataFolder, _dividend); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal class PathHelper
    {
        private const string _shangHai = @"history\shase\";
        private const string _shenZhen = @"history\sznse\";
        private const string _day = @"day\";
        private const string _min1 = @"min\";
        private const string _min5 = @"min5\";
        private const string _dividend = @"finance\权息资料.财经";

        private readonly string _dataFolder;

        public PathHelper(string dataFolder)
        {
            if (string.IsNullOrWhiteSpace(dataFolder))
            {
                throw new ArgumentNullException("dataFolder");
            }

            if (!Directory.Exists(dataFolder))
            {
                throw new DirectoryNotFoundException("dataFolder");
            }

            _dataFolder = dataFolder;
        }

        public string DataFolder
        {
            get { return _dataFolder; }
        }

        public string ShangHaiDay
        {
            get { return Path.Combine(_dataFolder, _shangHai, _day); }
        }

        public string ShangHaiMin1
        {
            get { return Path.Combine(_dataFolder, _shangHai, _min1); }
        }

        public string ShangHaiMin5
        {
            get { return Path.Combine(_dataFolder, _shangHai, _min5); }
        }

        public string ShenZhenDay
        {
            get { return Path.Combine(_dataFolder, _shenZhen, _day); }
        }

        public string ShenZhenMin1
        {
            get { return Path.Combine(_dataFolder, _shenZhen, _min1); }
        }

        public string ShenZhenMin5
        {
            get { return Path.Combine(_dataFolder, _shenZhen, _min5); }
        }

        public string Dividend
        {
            get { return Path.Combine(_dataFolder, _dividend); }
        }
    }
}

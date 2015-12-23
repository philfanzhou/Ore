using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal class DataReaderV2 : ITongHuaShunReader
    {
        private readonly string _dataFolder;
        private readonly string _financeDataFolder;
        private readonly string _historyDataFolder;

        public DataReaderV2(string dataFolder)
        {
            if (string.IsNullOrWhiteSpace(dataFolder))
            {
                throw new ArgumentNullException("dataFolder");
            }

            if (!Directory.Exists(dataFolder))
            {
                throw new DirectoryNotFoundException("dataFolder");
            }

            // 查找财经数据文件夹
            DirectoryInfo dirInfo = new DirectoryInfo(dataFolder);
            DirectoryInfo[] dirs = dirInfo.GetDirectories("finance");
            if(dirs.Length != 1)
            {
                throw new ArgumentOutOfRangeException("dataFolder");
            }
            _financeDataFolder = dirs[0].FullName;

            // 查找财经数据文件夹
            dirs = dirInfo.GetDirectories("history");
            if (dirs.Length != 1)
            {
                throw new ArgumentOutOfRangeException("dataFolder");
            }
            _historyDataFolder = dirs[0].FullName;

            _dataFolder = dataFolder;
        }

        public string DataFolder
        {
            get { return _dataFolder; }
        }
    }
}

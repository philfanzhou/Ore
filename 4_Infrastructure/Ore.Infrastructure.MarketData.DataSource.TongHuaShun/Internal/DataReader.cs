using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal class DataReader
    {
        #region Field

        private static readonly object _dayLineLock = new object();
        private static readonly object _dividendLock = new object();

        private Dictionary<string, KLineFile> _dayLineFileDictionary;
        private Dictionary<string, IDividendData> _dividendDataDictionary;

        #endregion

        #region Constructor

        public DataReader()
        {
            _dayLineFileDictionary = new Dictionary<string, KLineFile>();
            _dividendDataDictionary = new Dictionary<string, IDividendData>();
        }

        #endregion

        #region Property

        public IEnumerable<string> DayLineSymbols
        {
            get { return _dayLineFileDictionary.Keys; }
        }

        public IEnumerable<string> DividendSymbols
        {
            get { return _dividendDataDictionary.Keys; }
        }

        #endregion

        #region Public Method

        public void AnalyseDayLineFiles(string[] folders)
        {
            _dayLineFileDictionary = LoadDayLineFiles(folders);
        }

        public void AnalyseDividendFile(string filePath)
        {
            _dividendDataDictionary = LoadDividendData(filePath);
        }

        public IDividendData GetDividendData(string symbol, DateTime startTime)
        {
            lock (_dayLineLock)
            {
                if (_dividendDataDictionary.ContainsKey(symbol) == false)
                {
                    return null;
                }

                var data = _dividendDataDictionary[symbol];
                return new DividendInfo
                    {
                        Symbol = data.Symbol,
                        Items = data.Items.Where(i => i.Date > startTime).ToList()
                    };
            }
        }

        #endregion

        #region Private Method

        private static Dictionary<string, IDividendData> LoadDividendData(string filePath)
        {
            var result = new Dictionary<string, IDividendData>();
            var datas = new DividendFile(filePath).GetIteims();
            foreach (var dataItem in datas)
            {
                var symbol = dataItem.Symbol;
                if (result.ContainsKey(symbol) == false)
                {
                    result.Add(symbol, dataItem);
                }
            }

            return result;
        }

        private static Dictionary<string, KLineFile> LoadDayLineFiles(IEnumerable<string> folders)
        {
            var result = new Dictionary<string, KLineFile>();

            foreach (var folder in folders)
            {
                var directory = new DirectoryInfo(folder);
                foreach (var fileInfo in directory.GetFiles("*.day"))
                {
                    var dayLineFile = new KLineFile(fileInfo.FullName);
                    result.Add(dayLineFile.GetStockSymbol(), dayLineFile);
                }
            }

            return result;
        }

        #endregion
    }
}
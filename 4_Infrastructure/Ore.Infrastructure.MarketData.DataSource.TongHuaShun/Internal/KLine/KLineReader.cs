//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
//{
//    internal class KLineReader
//    {
//        public IEnumerable<IStockKLine> GetKLineData(string stockCode, KLineType type)
//        {
//            string filePath = PathHelper.GetKLineFilePath(stockCode, Market.XSHG, type);
//            if (!File.Exists(filePath))
//            {
//                filePath = PathHelper.GetKLineFilePath(stockCode, Market.XSHE, type);
//            }

//            if(!File.Exists(filePath))
//            {
//                return null;
//            }

//            var file = new KLineFile(filePath);
//            return file.GetItems(DateTime.MinValue);
//        }
//    }
//}

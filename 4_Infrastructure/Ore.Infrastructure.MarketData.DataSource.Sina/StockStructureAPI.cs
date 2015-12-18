using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Ore.Infrastructure.MarketData.DataSource.Sina
{
    public class StockStructureAPI
    {
        private const string WebApiAddress = @"http://vip.stock.finance.sina.com.cn/corp/go.php/vCI_StockStructure/stockid/000002.phtml";
        
        public IEnumerable<IStockStructure> GetStockStructure(string stockCode)
        {
            throw new NotImplementedException();
        }

    }
}

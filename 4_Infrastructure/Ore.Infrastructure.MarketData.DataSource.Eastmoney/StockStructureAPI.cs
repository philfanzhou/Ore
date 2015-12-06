using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    class StockStructureAPI
    {
        private const string WebApiAddress = @"http://quote3.eastmoney.com/f10.aspx?StockCode=000002&stock_name=&f10=003";

        public IEnumerable<IStockStructure> GetStockStructure(string stockCode)
        {
            string pageSource = PageReader.GetPageSource(WebApiAddress);

            throw new NotImplementedException();
        }
    }
}

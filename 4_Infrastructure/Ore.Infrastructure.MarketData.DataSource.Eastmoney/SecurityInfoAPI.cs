using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    public class SecurityInfoAPI
    {
        private const string WebApiAddress = @"http://quote.eastmoney.com/stock_list.html";

        public IEnumerable<ISecurity> GetAllSecurity()
        {
            string pageSource = PageReader.GetPageSource(WebApiAddress);

            throw new NotImplementedException();
        }
    }
}

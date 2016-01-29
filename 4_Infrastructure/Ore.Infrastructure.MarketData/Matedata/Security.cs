using System.Collections.Generic;
using System.Linq;

namespace Ore.Infrastructure.MarketData
{
    public class Security : ISecurity
    {
        public string Code { get; set; }

        public Market Market { get; set; }

        public string ShortName { get; set; }

        public SecurityType Type { get; set; }
    }

    public static class SecurityConverter
    {
        public static IEnumerable<Security> ToDataObject(this IEnumerable<ISecurity> self)
        {
            return self.Select(p => p.ToDataObject());
        }

        public static Security ToDataObject(this ISecurity self)
        {
            Security outputData = new Security
            {
                Code = self.Code,
                ShortName = self.ShortName,
                Market = self.Market,
                Type = self.Type
            };

            return outputData;
        }
    }
}

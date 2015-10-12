namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney
{
    internal class SecurityInfo : ISecurity
    {
        public string Code
        {
            get; internal set;
        }

        public Market Market
        {
            get; internal set;
        }

        public string ShortName
        {
            get; internal set;
        }

        public SecurityType Type
        {
            get; internal set;
        }
    }
}

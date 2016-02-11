namespace Ore.Infrastructure.MarketData
{
    public static class FullStockCode
    {
        public static string GetByCode(string stockCode)
        {
            if (stockCode.StartsWith("5") ||
                stockCode.StartsWith("6") ||
                stockCode.StartsWith("9"))
            {
                return "sh" + stockCode;
            }
            else if (stockCode.StartsWith("009") ||
                stockCode.StartsWith("126") ||
                stockCode.StartsWith("110") ||
                stockCode.StartsWith("201") ||
                stockCode.StartsWith("202") ||
                stockCode.StartsWith("203") ||
                stockCode.StartsWith("204"))
            {
                return "sh" + stockCode;
            }
            else
            {
                return "sz" + stockCode;
            }
        }
    }
}

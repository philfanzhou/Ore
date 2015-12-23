namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    public static class ReaderFactory
    {
        public static ITongHuaShunReader Create(string dataFolder)
        {
            return new DataReaderV2(dataFolder);
        }
    }
}

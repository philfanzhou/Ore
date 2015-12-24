namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    public static class ReaderFactory
    {
        public static ITongHuaShunReader Create()
        {
            return new DataReaderV2();
        }
    }
}

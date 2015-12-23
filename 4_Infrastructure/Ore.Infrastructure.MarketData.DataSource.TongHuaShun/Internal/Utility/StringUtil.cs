using System.Text;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal class StringUtil
    {
        internal static string ReadString(byte[] data)
        {
            int index = 0;
            while (index < data.Length)
            {
                if (data[index] == 0)
                {
                    break;
                }

                index++;
            }

            return Encoding.GetEncoding("GB2312").GetString(data, 0, index);
        }
    }
}

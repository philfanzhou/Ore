using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    public interface ITongHuaShunReader
    {
        /// <summary>
        /// 获取或设置数据所在文件夹
        /// </summary>
        string DataFolder { get; }

        /// <summary>
        /// 获取日线数据
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        IKlineData GetDayKLine(string stockCode);
    }
}

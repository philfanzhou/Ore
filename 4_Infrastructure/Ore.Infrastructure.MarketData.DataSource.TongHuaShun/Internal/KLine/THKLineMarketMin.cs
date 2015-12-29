using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    [StructLayout(LayoutKind.Sequential)]
    internal class THKLineMarketMin : THKLine
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        private byte[] otherData;

        public override DateTime Time
        {
            get
            {
                return DateTimeUtil.ConverterToMinDateTime(base.date);
            }
        }
    }
}

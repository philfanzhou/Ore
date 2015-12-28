using System;
using System.Runtime.InteropServices;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    /// <summary>
    /// 同花顺日线数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal abstract class THKLine : IStockKLine
    {
        #region Field

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        protected byte[] date;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] open;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] high;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] low;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] close;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] amount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] volume;

        #endregion

        protected static double GetValue(byte[] byteArray)
        {
            uint data = BitConverter.ToUInt32(byteArray, 0);

            /*
             * 后28位为数据
             * 1011 0000 0000 0001 0111 0111 0011 0010
             * 用0XFFFFFFF相与取数据
             * 0000 1111 1111 1111 1111 1111 1111 1111
             */
            double value = data & 0xFFFFFFF;

            // 数据右移28位，取得最高4位
            // 描述结果的小数点的数据
            byte pointData = (byte)(data >> 0x1C);

            // pointData中的后三位，表示小数点需要移动的位数
            byte movePointCount = (byte)(pointData & 7);
            if (movePointCount != 0)
            {
                // pointData中的第4位，表示小数点的移动方向
                // 非0左移小数点
                bool leftMovePoint = (pointData & 8) != 0;
                if (leftMovePoint)
                {
                    value = value / Math.Pow(10.0, movePointCount);
                }
                else
                {
                    value = value * Math.Pow(10.0, movePointCount);
                }
            }

            return value;
        }

        #region IStockKLine Members

        public double Open
        {
            get { return GetValue(this.open); }
        }
        
        public double High
        {
            get { return GetValue(this.high); }
        }
        
        public double Low
        {
            get { return GetValue(this.low); }
        }
        
        public double Close
        {
            get { return GetValue(this.close); }
        }
        
        public double Amount
        {
            get { return GetValue(this.amount); }
        }
        
        public double Volume
        {
            get { return GetValue(this.volume); }
        }

        public abstract DateTime Time
        {
            get;
        }

        #endregion
    }
}

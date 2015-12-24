using System;
using System.Runtime.InteropServices;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct THFileHeader
    {
        #region Field

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        private readonly byte[] sign;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private readonly byte[] recordCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private readonly byte[] dataPosition;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private readonly byte[] recordLength;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private readonly byte[] fieldCount;

        #endregion

        #region Property

        internal uint RecordCount
        {
            get
            {
                uint value = BitConverter.ToUInt32(recordCount, 0) & 0xFFFFFF;
                return value;
            }
        }

        internal ushort DataPosition
        {
            get { return BitConverter.ToUInt16(dataPosition, 0); }
        }

        internal ushort RecordLength
        {
            get { return BitConverter.ToUInt16(recordLength, 0); }
        }

        internal ushort FieldCount
        {
            get { return BitConverter.ToUInt16(fieldCount, 0); }
        }

        #endregion
    }
}

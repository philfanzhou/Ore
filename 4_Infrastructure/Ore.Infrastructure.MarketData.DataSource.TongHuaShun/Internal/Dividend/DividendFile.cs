using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal class DividendFile : FileBase
    {
        public DividendFile(string filePath)
            : base(filePath){ }

        public IEnumerable<IDividendData> GetIteims()
        {
            return base.GetItems<IDividendData>();
        }

        protected override IEnumerable<T> DoGetItems<T>(BinaryReader reader, THFileHeader header)
        {
            List<DividendInfo> result = new List<DividendInfo>();

            byte[] W1 = reader.ReadBytes(header.FieldCount * 2);

            THIndexBlock block = THIndexBlock.Read(reader);
            THDividendRecord[] recordList = StructUtil<THDividendRecord>.ReadStructArray(reader, header.RecordCount);
            List<THIndexRecord> indexs = block.RecordList.ToList();
            foreach (THIndexRecord index in indexs)
            {
                List<IDividendItem> items = new List<IDividendItem>();

                DividendInfo info = new DividendInfo();
                info.Symbol = index.Symbol;
                info.Items = items;

                for (uint i = index.Position; i < index.Position + index.RecordNumber; i++)
                {
                    items.Add(recordList[i]);
                }

                result.Add(info);
            }

            return result.Cast<T>();
        }
    }
}
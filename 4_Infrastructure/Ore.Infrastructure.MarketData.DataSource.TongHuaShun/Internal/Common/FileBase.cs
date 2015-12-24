using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Ore.Infrastructure.MarketData.DataSource.TongHuaShun
{
    internal abstract class FileBase
    {
        protected readonly string FilePath;

         protected FileBase(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("filePath");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("filePath");
            }

            this.FilePath = filePath;
        }

        protected IEnumerable<T> GetItems<T>()
        {
            using (FileStream stream = File.OpenRead(FilePath))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    THFileHeader header = StructUtil<THFileHeader>.BytesToStruct(reader.ReadBytes(Marshal.SizeOf(typeof(THFileHeader))));
                    THColumnHeader[] columnList = StructUtil<THColumnHeader>.ReadStructArray(reader, header.FieldCount);

                    return DoGetItems<T>(reader, header);
                }
            }
        }

        protected abstract IEnumerable<T> DoGetItems<T>(BinaryReader reader, THFileHeader header);
    }
}
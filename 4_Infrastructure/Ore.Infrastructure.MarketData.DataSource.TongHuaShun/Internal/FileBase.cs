using System;
using System.IO;

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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.AdditionalClasses
{
    public class FileHelper
    {
        public static byte[] GetBytesOfFile(string filepath)
        {
            byte[] bytes = new byte[100_000];
            if (filepath != "")
            {
                bytes = System.IO.File.ReadAllBytes(filepath);
            }
            return bytes;
        }
        public static void SaveFile(string filepath, byte[] bytes)
        {
            System.IO.File.WriteAllBytes(filepath, bytes);
        }
    }
}

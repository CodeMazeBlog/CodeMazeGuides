using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentWaysToOverwiteAFile.Examples
{
    public class WriteAllBytes
    {
        public static void OverwiteFile(string filePath, byte[] contentToWrite)
        {
            File.WriteAllBytes(filePath, contentToWrite);
        }
    }
}

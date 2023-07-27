using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentWaysToOverwiteAFile.Examples
{
    public class WriteAllText
    {
        public static void OverwiteFile(string filePath, string contentToWrite)
        {
            File.WriteAllText(filePath, contentToWrite);
        }
    }
}

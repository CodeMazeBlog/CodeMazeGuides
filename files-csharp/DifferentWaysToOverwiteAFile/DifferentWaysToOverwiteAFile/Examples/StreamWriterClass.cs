using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentWaysToOverwiteAFile.Examples
{
    public class StreamWriterClass
    {
        public static void AppendFile(string filePath, string contentToWrite)
        {
            using var streamWriter = new StreamWriter(filePath, true);
            streamWriter.Write(contentToWrite);
        }

        public static void OverwiteFile(string filePath, string contentToWrite)
        {
            using var streamWriter = new StreamWriter(filePath, false);
            streamWriter.Write(contentToWrite);
        }
    }
}

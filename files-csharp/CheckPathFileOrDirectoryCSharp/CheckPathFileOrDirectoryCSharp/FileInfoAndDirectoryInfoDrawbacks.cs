using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPathFileOrDirectoryCSharp
{
    public class FileInfoAndDirectoryInfoDrawbacks
    {
        public static void Run()
        {
            Console.WriteLine("FileInfo and DirectoryInfo drawbacks");

            var testFile = Path.Combine(Path.GetTempPath(), "test_file3.abc");
            if (File.Exists(testFile)) File.Delete(testFile);

            var fileInfo = new FileInfo(testFile);

            bool existsFileInfo = fileInfo.Exists;
            bool existsFile = File.Exists(testFile);

            Console.WriteLine($"existsFileInfo = {existsFileInfo}");
            Console.WriteLine($"existsFile = {existsFile}");

            File.CreateText(testFile);

            existsFileInfo = fileInfo.Exists;
            existsFile = File.Exists(testFile);

            Console.WriteLine($"existsFileInfo = {existsFileInfo}");
            Console.WriteLine($"existsFile = {existsFile}\n");
        }

    }
}

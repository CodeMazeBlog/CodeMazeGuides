using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyAllContentInDirectory.Extensions
{
    public static class DirectoryInfoExtensions
    {
        public static void DeepCopy(this DirectoryInfo directory, string destinationDir)
        {
            var allDirectories = Directory.GetDirectories(directory.FullName, "*", SearchOption.AllDirectories);

            foreach (string dir in allDirectories)
            {
                string dirToCreate = dir.Replace(directory.FullName, destinationDir);
                Directory.CreateDirectory(dirToCreate);
            }

            var allFiles = Directory.GetFiles(directory.FullName, "*.*", SearchOption.AllDirectories);

            foreach (string newPath in allFiles)
            {
                File.Copy(newPath, newPath.Replace(directory.FullName, destinationDir), true);
            }
        }
    }
}

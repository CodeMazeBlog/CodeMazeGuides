using System.IO.Compression;
using System.Text.RegularExpressions;

namespace ZipFilesInNet
{
    public class ModifyZipFiles
    {
        public void DeleteFilesFromZipFile(string zipFileName, string filePattern)
        {
            // opening zip file for modification
            using var zipFile = ZipFile.Open(zipFileName, ZipArchiveMode.Update);

            // filtering all files with the name 'image.png'
            var images = zipFile.Entries
                .Where(e => IsPatternMach(e.Name, filePattern))
                .ToList();

            // removing all images 
            // NOTE: here, we can't use a foreach loop, because
            //       we are modifying the collection in the loop
            for (var i = images.Count - 1; i >= 0; --i)
                images[i].Delete();
        }

        private static bool IsPatternMach(string fileName, string filePattern)
        {
            Regex regPattern = new Regex(
                filePattern.Replace(".", "[.]")
                    .Replace("*", ".*")
                    .Replace("?", "."));

            return regPattern.IsMatch(fileName);
        }
    }
}

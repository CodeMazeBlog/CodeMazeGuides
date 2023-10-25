namespace RenameFilesWithCSharp
{
    public class FindingFilesInFolder
    {
        public static List<string> FindFilesInFolder()
        {
            var directoryPath = @"C:\PathToDirectory";

            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            return files.ToList();
        }
    }
}

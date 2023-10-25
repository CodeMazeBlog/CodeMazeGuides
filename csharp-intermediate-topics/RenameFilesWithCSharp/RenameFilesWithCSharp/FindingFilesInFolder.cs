namespace RenameFilesWithCSharp
{
    public class FindingFilesInFolder
    {
        public static List<string> FindFilesInFolder(string directoryPath)
        {

            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            return files.ToList();
        }
    }
}

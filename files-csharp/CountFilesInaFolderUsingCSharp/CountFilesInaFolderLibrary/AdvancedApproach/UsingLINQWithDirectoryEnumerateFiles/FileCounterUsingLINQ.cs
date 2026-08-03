namespace CountFilesInaFolderLibrary.AdvancedApproach.UsingLINQWithDirectoryEnumerateFiles;
public class FileCounterUsingLINQ
{
    public static int CountFilesUsingLINQEnumerateFiles(string directoryPath)
    {
        return Directory
            .EnumerateFiles(directoryPath)
            .Count();
    }
}

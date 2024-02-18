namespace CountFilesInaFolderLibrary.BasicApproach;
public class FileCounterUsingGetFiles
{
    public static int CountFilesUsingGetFiles(string directoryPath)
    {
        return Directory.GetFiles(directoryPath).Length;
    }
}

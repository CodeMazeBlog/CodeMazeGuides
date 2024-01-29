using System.Runtime.InteropServices;

namespace CountFilesInaFolderLibrary.AdvancedApproach.UsingWinAPI;
public class FileCounterUsingWinAPI
{
    [DllImport("kernel32.dll")]
    static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);
    [DllImport("kernel32.dll")]
    static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);
    [DllImport("kernel32.dll")]
    static extern bool FindClose(IntPtr hFindFile);

    public static int CountFilesUsingWinAPI(string directoryPath, bool searchSubDirectories = false)
    {
        if (!Directory.Exists(directoryPath))
            throw new DirectoryNotFoundException(directoryPath);

        var searchPattern = Path.Combine(directoryPath, "*");
        var findData = new WIN32_FIND_DATA();

        var handleFindFile = FindFirstFile(searchPattern, out findData);

        var fileCount = 0;

        if (handleFindFile != IntPtr.Zero)
        {
            do
            {
                if (findData.dwFileAttributes != FileAttributes.Directory
                    && findData.cFileName != ".")
                {
                    fileCount++;
                }
                if (searchSubDirectories
                    && findData.cFileName != "..")
                {
                    var subDir = Path.Combine(directoryPath, findData.cFileName);
                    fileCount += CountFilesUsingWinAPI(subDir);
                }
            } while (FindNextFile(handleFindFile, out findData));

            FindClose(handleFindFile);
        }

        return fileCount;
    }
}

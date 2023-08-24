public static class FileUtil
{
    private static string? _dircetoryToMonitor;

    public static string DirectoryToMonitor
    {
        get
        {
            if(string.IsNullOrEmpty(_dircetoryToMonitor))
            {
                _dircetoryToMonitor = Path.Combine(Directory.GetCurrentDirectory(),"bin","DirectoryToMonitor");
                Directory.CreateDirectory(_dircetoryToMonitor);
            }
            
            return _dircetoryToMonitor;
        }
    }
}
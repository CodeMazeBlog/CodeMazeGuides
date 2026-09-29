public static class FileUtil
{
    private static string? _directoryToMonitor;

    public static string DirectoryToMonitor
    {
        get
        {
            if(string.IsNullOrEmpty(_directoryToMonitor))
            {
                _directoryToMonitor = Path.Combine(Directory.GetCurrentDirectory(),"bin","DirectoryToMonitor");
                Directory.CreateDirectory(_directoryToMonitor);
            }
            
            return _directoryToMonitor;
        }
    }
}
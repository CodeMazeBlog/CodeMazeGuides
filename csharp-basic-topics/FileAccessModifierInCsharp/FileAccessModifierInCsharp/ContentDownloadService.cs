namespace FileAccessModifierInCsharp;

file static class Logger
{
    public static string GetMessage(DateTime datetime, int fileId)
    {
        return $"{datetime} - Download - File ID: {fileId}";
    }
}

public static class ContentDownloadService
{
    public static string GetMessage(DateTime datetime, int fileId)
    {
        return Logger.GetMessage(datetime, fileId);
    }
}
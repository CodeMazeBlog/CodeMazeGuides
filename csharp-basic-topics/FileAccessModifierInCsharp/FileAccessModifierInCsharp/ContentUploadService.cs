namespace FileAccessModifierInCsharp;

file static class Logger
{
    public static string GetMessage(DateTime datetime, int fileId)
    {
        return $"{datetime} - Upload - File ID: {fileId}";
    }
}

public static class ContentUploadService
{
    public static string GetMessage(DateTime datetime, int fileId)
    {
        return Logger.GetMessage(datetime, fileId);
    }
}
namespace WriteFileToTempFolder;

public static class TempFileCreator
{
    public static void CreateTempFile(string filePath)
    {
        using var sw = new StreamWriter(filePath);

        sw.Write("Hello from CodeMaze!");
    }
}
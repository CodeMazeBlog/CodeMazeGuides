namespace FileAlreadyInUseException;

public static class FileOperations
{

    public static void ReadFile(string fileName)
    {
        File.Create(fileName);

        if (IsFileInUse(new FileInfo(fileName)))
        {
            Console.WriteLine("File is in use by another process.");
        }
        else
        {
            try
            {
                var fileContents = File.ReadAllText(fileName);
                Console.WriteLine("File contents: " + fileContents);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }
        }

        Console.ReadLine();
    }

    public static bool IsFileInUseGeneric(FileInfo file)
    {
        try
        {
            using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
        }
        catch (IOException)
        {
            return true;
        }

        return false;
    }

    public static bool IsFileInUse(FileInfo file)
    {
        try
        {
            using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
        {
            return true;
        }

        return false;
    }
}

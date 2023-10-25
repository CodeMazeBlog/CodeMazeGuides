namespace FileAlreadyInUseException;

public static class Program
{
    static readonly string fileName = "sample2.txt";

    static void Main()
    {
        File.Create(fileName);

        if (IsFileInUseGeneric(new FileInfo(fileName)))
        {
            Console.WriteLine("File is in use by another process.");
        }
        else
        {
            try
            {
                string fileContents = File.ReadAllText(fileName);
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
            using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            stream.Close();
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
            using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            stream.Close();
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
        {
            return true;
        }

        return false;
    }
}
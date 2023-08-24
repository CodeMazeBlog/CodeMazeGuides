using IDisposableObjects;
class Program
{
    public static void Main()
    {
        FileManager fileManager = new();
        Console.WriteLine(fileManager.UnmanagedObjectFileManager());
        Console.WriteLine(fileManager.UsingFileManager());
        Console.WriteLine(fileManager.TryFinallyFileManager());
    }
}
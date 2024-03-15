class Program
{
    static void Main()
    {
#if NET7_0
        Console.WriteLine(".NET 7 - Hello from the latest .NET framework!");
#elif NETCOREAPP3_1
        Console.WriteLine(".NET Core 3.1 - Hello from a previous LTS version of .NET Core!");
#else
        Console.WriteLine("Hello from an unsupported framework or runtime!");
#endif

        Console.WriteLine("Hello, World!");
    }
}
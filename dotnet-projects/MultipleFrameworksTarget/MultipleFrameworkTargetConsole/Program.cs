using System;

class Program
{
    static void Main()
    {
#if NET6_0
        Console.WriteLine(".NET 6 - Hello from the latest .NET framework!");
#elif NETSTANDARD2_0
        Console.WriteLine(".NET Standard 2.0 - Hello from a common set of APIs across .NET implementations!");
#elif NETCOREAPP3_1
        Console.WriteLine(".NET Core 3.1 - Hello from a previous LTS version of .NET Core!");
#elif NET48
        Console.WriteLine(".NET Framework 4.8 - Hello from the traditional .NET Framework!");
#else
        Console.WriteLine("Hello from an unsupported framework or runtime!");
#endif

        Console.WriteLine("Hello, World!");
    }
}

partial class Program
{
    public delegate void ForEachCallback(int value);

    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5 };

        ForEachCallback printValue = PrintValueOnConsole;

        ForEach(array, printValue);
    }

    static void ForEach(int[] array, ForEachCallback callback)
    {
        foreach (var item in array)
        {
            callback(item);
        }
    }

    static void PrintValueOnConsole(int value)
    {
        Console.WriteLine(value);
    }
}


/// <summary>
/// Uncomment to run this example about multicast delegate
/// </summary>
//partial class Program
//{
//    public delegate void ForEachCallback(int value);

//    static void Main(string[] args)
//    {
//        int[] array = { 1, 2, 3, 4, 5 };

//        ForEachCallback printValue = PrintValueOnConsole;
//        printValue += AddAndPrintValueOnConsole;

//        ForEach(array, printValue);
//    }

//    static void ForEach(int[] array, ForEachCallback callback)
//    {
//        foreach (var item in array)
//        {
//            callback(item);
//        }
//    }

//    static void PrintValueOnConsole(int value)
//    {
//        Console.WriteLine(value);
//    }

//    static void AddAndPrintValueOnConsole(int value)
//    {
//        value += 100;
//        Console.WriteLine(value);
//    }
//}


/// <summary>
/// Uncomment to run this example about Action delegate
/// <summary>
//partial class Program
//{
//    static void Main(string[] args)
//    {
//        int[] array = { 1, 2, 3, 4, 5 };

//        Action<int> actionPrintValueOnConsole = PrintValueOnConsole;

//        ForEach(array, actionPrintValueOnConsole);
//    }

//    static void ForEach(int[] array, Action<int> callback)
//    {
//        foreach (var item in array)
//        {
//            callback(item);
//        }
//    }

//    static void PrintValueOnConsole(int value)
//    {
//        Console.WriteLine(value);
//    }
//}



/// <summary>
/// Uncomment to run this example about Funct delegate
/// <summary>
//partial class Program
//{
//    static void Main(string[] args)
//    {
//        int[] array = { 1, 2, 3, 4, 5 };

//        Action<int> actionPrintValueOnConsole = PrintValueOnConsole;
//        Func<string, string, string> funcConcat = (text1, text2) => string.Format("{0} {1}", text1, text2);

//        ForEach(array, actionPrintValueOnConsole);
//        Console.WriteLine(funcConcat("Hello", "World"));
//    }

//    static void ForEach(int[] array, Action<int> callback)
//    {
//        foreach (var item in array)
//        {
//            callback(item);
//        }
//    }

//    static void PrintValueOnConsole(int value)
//    {
//        Console.WriteLine(value);
//    }
//}


/// <summary>
/// Uncomment to run this example about the use of Action delegate with List
/// <summary>
//using System.Collections.Generic;

//partial class Program
//{
//    static void Main(string[] args)
//    {
//        int[] array = { 1, 2, 3, 4, 5 };

//        Action<int> actionPrintValueOnConsole = PrintValueOnConsole;

//        List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
//        list.ForEach(actionPrintValueOnConsole);
//    }

//    static void PrintValueOnConsole(int value)
//    {
//        Console.WriteLine(value);
//    }
//}
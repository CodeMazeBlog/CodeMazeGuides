namespace PrintOutArrayElements;

public class Program
{
    private static readonly ElementPrinter _elementPrinter = new();
    private static readonly int[] _array = new int[] { 1, 4, 6, 7, 9, 3, 5 };
    public static int OutPutResult = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("========== Using For Loop");
        _elementPrinter.ForLoop(_array);
        
        Console.WriteLine();

        Console.WriteLine("========== Using Foreach Loop");
        _elementPrinter.ForeachLoop(_array);
        
        Console.WriteLine();
        
        Console.WriteLine("========== Using AsSpan()");
        _elementPrinter.AsSpan(_array);
        
        Console.WriteLine();
        
        Console.WriteLine("========== Using ToList().ForEach");
        _elementPrinter.ToListForEach(_array);

        Console.WriteLine();
        
        Console.WriteLine("========== Using string.Join");
        _elementPrinter.StringJoin(_array);
        
        Console.WriteLine();
        
        Console.WriteLine("========== Using Array.ForEach");
        _elementPrinter.ArrayForEach(_array);

        Console.WriteLine();

        OutPutResult = 1;
    }
}
using PointersInCSharp.Method;

unsafe
{
    Console.WriteLine("Pointer assignment to integer example.");

    var num = 7;
    int* p = &num;
    Console.WriteLine($"Original variable value: {num}");
    Console.WriteLine($"Pointer points to value: {*p}");
    Console.WriteLine($"Pointer address: {(long)p}");

    Console.WriteLine("\nValue swapping example.");
    var char1 = 'A';
    var char2 = 'B';

    char* p1 = &char1;
    char* p2 = &char2;

    Console.WriteLine($"Value of char1: {char1}");
    Console.WriteLine($"Value of char2: {char2}");

    Methods.SwapChars(p1,p2);

    Console.WriteLine($"After swapping:");
    Console.WriteLine($"Value of char1: {char1}");
    Console.WriteLine($"Value of char2: {char2}");

    Console.WriteLine("\nPointer to array elements example.");

    var intArray = new[] {1, 2, 3, 4, 5};

    fixed (int* arrayPointer = intArray)
    {
        Console.WriteLine("Before doubling odd values:");
        Console.WriteLine(string.Join(", ", intArray));

        Methods.DoubleOddValues(arrayPointer, intArray.Length);

        Console.WriteLine("\nAfter doubling odd values:");
        Console.WriteLine(string.Join(", ", intArray));
    }
}
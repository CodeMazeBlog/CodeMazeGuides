namespace ActionAndFuncDelegates;

public class Program
{
    // declare a delegate
    delegate ulong Calculate(uint a, uint b);

    // assign method to variable declared as type Calculate
    static Calculate calcRectAreaDelegate = Rectangle.CalculateArea;

    // instead of declaring the Calculate delegate type and assigning a method, we can simply use Func
    static Func<uint, uint, ulong> calcRectAreaFunc = Rectangle.CalculateArea;

    // example of Action variable
    static Action<uint, uint> calcRectPerimeterAction = Rectangle.CalculatePerimeter;
    
    public static void Main(string[]? args)
    {
        uint length = 10;
        uint breadth = 20;
        
        var areaOfRectangle = calcRectAreaDelegate(length, breadth);
        Console.WriteLine($"Area of rectangle (calculated by delegate referenced to the method) - {areaOfRectangle}");

        areaOfRectangle = calcRectAreaFunc(length, breadth);
        Console.WriteLine($"Area of rectangle (calculated by func variable referenced to the method) - {areaOfRectangle}");

        Console.Write("Perimeter of rectangle (calculated by action variable referenced to the method) - ");
        calcRectPerimeterAction(length, breadth);
    }
}

public class Rectangle
{
    public static ulong CalculateArea(uint length, uint breadth) => length * breadth;
    public static void CalculatePerimeter(uint length, uint breadth) => Console.Write(2 * (length + breadth));
}
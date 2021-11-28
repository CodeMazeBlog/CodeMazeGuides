namespace LearnFuncAndAction;

public class Program
{
    // declare a delegate
    delegate double Calculate(float a, float b);

    // assign method to variable declared as type Calculate
    static Calculate calcRectAreaDelegate = Rectangle.CalculateArea;

    // instead of declaring the Calculate delegate and assigning a method, we can simply use Func
    static Func<float, float, double> calcRectAreaFunc = Rectangle.CalculateArea;

    // example of Action variable
    static Action<float, float> calcRectPerimeterAction = Rectangle.CalculatePerimeter;
    
    static void Main(string[] args)
    {
        int length = 10;
        int breadth = 20;
        
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
    public static double CalculateArea(float length, float breadth) => length * breadth;
    public static void CalculatePerimeter(float length, float breadth) => Console.Write(2 * (length + breadth));
}
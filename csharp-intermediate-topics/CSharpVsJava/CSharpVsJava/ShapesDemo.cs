namespace CSharpVsJava;

public abstract record Shape;
public record Circle(double Radius) : Shape;
public record Square(double Side) : Shape;

public static class ShapesDemo
{
    public static void Run()
    {
        Shape[] shapes = [new Circle(1), new Square(2)];
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape}: {Area(shape):F2}");
        }

        var bigger = new Circle(1) with { Radius = 3 };
        Console.WriteLine(bigger);
    }

    private static double Area(Shape shape) => shape switch
    {
        Circle(var radius) => Math.PI * radius * radius,
        Square(var side) => side * side,
        _ => throw new ArgumentOutOfRangeException(nameof(shape))
    };
}

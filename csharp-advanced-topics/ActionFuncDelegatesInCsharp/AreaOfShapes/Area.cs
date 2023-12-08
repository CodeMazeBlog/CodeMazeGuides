public class Area
{
    public static Action<string, double> DisplayResult = (shape, area) =>
    {
        Console.WriteLine($"The area of the {shape} is: {area}");
    };
    public static Func<double, double, double> RectangleArea = (length, width) =>
    {
        return length * width;
    };
    public static Func<double, double> CircleArea = radius =>
    {
        return Math.PI * Math.Pow(radius, 2);
    };
    public static Func<double, double, double, double> TriangleArea = (a, b, c) =>
    {
        double s = (a + b + c) / 2;

        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    };
}


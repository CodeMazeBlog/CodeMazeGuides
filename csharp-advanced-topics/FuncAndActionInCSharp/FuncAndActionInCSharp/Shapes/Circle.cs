namespace FuncAndActionInCSharp.Shapes
{
    public class Circle
    {
        public static double GetCircleArea(int radius) => Math.PI * Math.Pow(Convert.ToDouble(radius), 2);
        public static void PrintCircleArea(int radius) => Console.WriteLine($"The area of a circle with radius {radius} is: {Math.PI * Math.Pow(Convert.ToDouble(radius), 2)}");

    }
}

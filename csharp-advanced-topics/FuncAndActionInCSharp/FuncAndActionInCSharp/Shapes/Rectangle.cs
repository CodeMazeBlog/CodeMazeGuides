namespace FuncAndActionInCSharp.Shapes
{
    public class Rectangle
    {
        public static double GetRectangleArea(int length, int width) => width * length;
        public static double GetRectanglePerimeter(int length, int width) => 2 * (length + width);
        public static void PrintRectangleArea(int length, int width) => Console.WriteLine($"The area of a rectangle with length {length} and width {width} is: {width * length}");
        public static void PrintRectanglePerimeter(int length, int width) => Console.WriteLine($"The perimeter of a rectangle with length {length} and width {width} is: {2 * (length + width)}");
    }
}

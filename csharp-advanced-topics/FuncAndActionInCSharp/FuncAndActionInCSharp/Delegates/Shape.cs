namespace FuncAndActionInCSharp.Delegates
{

    public static class Shape
    {
        public static double GetSquareArea(int side) => side * side;
        public static double GetSquarePerimeter(int side) => 4 * side;
        public static double GetRectangleArea(int length, int width) => width * length;
        public static double GetRectanglePerimeter(int length, int width) => 2 * (length + width);
        public static double GetCircleArea(int radius) => Math.PI * Math.Pow(Convert.ToDouble(radius), 2);

        public static void PrintSquareArea(int side) => Console.WriteLine($"The area of a square of side {side} is: {side * side}");
        public static void PrintSquarePerimeter(int side) => Console.WriteLine($"The perimeter of a square of side {side} is: {4 * side}");
        public static void PrintRectangleArea(int length, int width) => Console.WriteLine($"The area of a rectangle with length {length} and width {width} is: {width * length}");
        public static void PrintRectanglePerimeter(int length, int width) => Console.WriteLine($"The perimeter of a rectangle with length {length} and width {width} is: {2 * (length + width)}");
        public static void PrintCircleArea(int radius) => Console.WriteLine($"The area of a circle with radius {radius} is: {Math.PI * Math.Pow(Convert.ToDouble(radius), 2)}");
    }
}

namespace FuncAndActionInCSharp.Shapes
{
    public static class Square
    {
        public static double GetSquareArea(int side) => side * side;
        public static double GetSquarePerimeter(int side) => 4 * side;
        public static void PrintSquareArea(int side) => Console.WriteLine($"The area of a square of side {side} is: {side * side}");
        public static void PrintSquarePerimeter(int side) => Console.WriteLine($"The perimeter of a square of side {side} is: {4 * side}");
    }
}

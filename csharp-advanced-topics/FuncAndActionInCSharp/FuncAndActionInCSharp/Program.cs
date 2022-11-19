using FuncAndActionInCSharp.Delegates;

namespace FuncAndActionInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Funcs
            int side = 10;

            Console.WriteLine("[Func Samples]\r\n");

            #region Square 

            Console.WriteLine("<Square calculation>");

            //Func to calculate area and perimeter of a square
            Func<int, double> func1;
            func1 = Shape.GetSquareArea;
            Console.WriteLine($"The area of a square of side {side} is: {func1(side)}");

            func1 = Shape.GetSquarePerimeter;
            Console.WriteLine($"The perimeter of square of side {side} is: {func1(side)}");

            #endregion

            #region Circle

            Console.WriteLine("\r\n<Circle calculation>");

            //Func to calculate the area of a circle
            int radius = 15;
            func1 = Shape.GetCircleArea;
            Console.WriteLine($"The area of a circle with radius {radius} is: {func1(radius)}");

            #endregion

            #region Rectangle

            Console.WriteLine("\r\n<Rectangle calculation>");

            //Func to calculate area and perimeter of a rectangle
            int length = 15;
            int width = 25;
            Func<int, int, double> func2;
            func2 = Shape.GetRectangleArea;
            Console.WriteLine($"The area of a rectangle with length {length} and width {width} is: {func2(length, width)}");

            func2 = Shape.GetRectanglePerimeter;
            Console.WriteLine($"The perimeter of a rectangle with length {length} and width {width} is: {func2(length, width)}");

            #endregion

            #region Anonymous Methods

            Console.WriteLine("\r\n<Anonymous Method sample>");

            func1 = delegate (int x)
            {
                return x * x;
            };
            Console.WriteLine($"The area of a square of side {side} is: {func1(side)}");

            #endregion

            #region Lambda Expressions

            Console.WriteLine("\r\n<Lambda expression sample>");

            func1 = (int x) => 4 * x;
            Console.WriteLine($"The perimeter of a square of side {side} is: {func1(side)}");

            #endregion

            #endregion

            #region Actions

            Console.WriteLine("\r\n\r\n[Action Samples]\r\n");

            #region Square 

            Console.WriteLine("\r\n<Square Calculation>");

            //Action to calculate area and perimeter of a square
            Action<int> action1;
            action1 = Shape.PrintSquareArea;
            action1(side);

            action1 = Shape.PrintSquarePerimeter;
            action1(side);

            #endregion

            #region Circle

            Console.WriteLine("\r\n<Circle Calculation>");

            action1 = Shape.PrintCircleArea;
            action1(radius);

            #endregion

            #region Rectangle

            Console.WriteLine("\r\n<Rectangle Calculation>");

            Action<int, int> action2;
            action2 = Shape.PrintRectangleArea;
            action2(length, width);

            action2 = Shape.PrintRectanglePerimeter;
            action2(length, width);


            #endregion

            #region Anonymous Methods

            Console.WriteLine("\r\n<Anonymous Method sample>");

            action1 = delegate (int x)
            {
                Console.WriteLine($"The area of square of side {x} is: {x * x}");
            };
            action1(side);

            #endregion

            #region Lambda Expressions

            Console.WriteLine("\r\n<Lambda expression sample>");

            action1 = (int x) => Console.WriteLine($"The perimeter of a square of side {x} is: {4 * x}");
            action1(side);

            #endregion

            #endregion

            Console.ReadKey();
        }
    }
}
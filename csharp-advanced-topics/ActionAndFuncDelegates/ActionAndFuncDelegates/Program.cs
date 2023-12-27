using ActionAndFuncDelegates.Entities;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var squareShape = new SquareShape();

            Action<Square> action = squareShape.Area;

            action.Invoke(new Square
            {
                Side = 4
            });

            var rectangleShape = new RectangleShape();
            Func<Rectangle, int> func = rectangleShape.Area;

            var result = func.Invoke(new Rectangle
            {
                Length = 10,
                Breadth = 20
            });

            Console.WriteLine("Area of rectangle = " + result);

            Console.ReadLine();
        }
    }
}

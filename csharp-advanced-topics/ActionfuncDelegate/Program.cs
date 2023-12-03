using ActionfuncDelegate.AreaOfShapes;

namespace ActionfuncDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rectangleResult = Area.RectangleArea(5, 10);
            double circleResult = Area.CircleArea(7);
            double triangleResult = Area.TriangleArea(3, 4, 5);

            Area.DisplayResult("rectangle", rectangleResult);
            Area.DisplayResult("circle", circleResult);
            Area.DisplayResult("triangle", triangleResult);
        }
    }
}
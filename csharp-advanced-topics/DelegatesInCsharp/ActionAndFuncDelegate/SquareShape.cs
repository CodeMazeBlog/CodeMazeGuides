using ActionAndFuncDelegate.Entities;

namespace ActionAndFuncDelegate
{
    public class SquareShape
    {
        public void Area(Square shape)
        {
            Console.WriteLine("Area of square = " + shape.Side * shape.Side);
        }
    }
}

using ActionAndFuncDelegates.Entities;

namespace ActionAndFuncDelegates
{
    public class SquareShape
    {
        public virtual void Area(Square shape)
        {
            Console.WriteLine("Area of square = " + shape.Side * shape.Side);
        }
    }
}

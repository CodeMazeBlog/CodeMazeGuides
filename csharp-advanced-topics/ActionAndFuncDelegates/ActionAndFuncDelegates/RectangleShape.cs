using ActionAndFuncDelegates.Entities;

namespace ActionAndFuncDelegates
{
    public class RectangleShape
    {
        public virtual int Area(Rectangle shape)
        {
            return shape.Length * shape.Breadth;
        }
    }
}

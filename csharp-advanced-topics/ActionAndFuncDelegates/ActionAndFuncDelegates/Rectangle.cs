namespace ActionAndFuncDelegates
{
    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public ShapeType ShapeType => ShapeType.Rectangle;
    }
}

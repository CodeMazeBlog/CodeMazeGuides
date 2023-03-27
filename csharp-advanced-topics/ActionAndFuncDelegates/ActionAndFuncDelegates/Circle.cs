namespace ActionAndFuncDelegates
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public ShapeType ShapeType => ShapeType.Circle;
    }
}

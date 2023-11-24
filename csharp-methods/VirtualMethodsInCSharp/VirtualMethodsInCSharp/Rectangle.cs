namespace VirtualMethodsInCSharp
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override string GetShapeType()
        {
            return "This is a rectangle";
        }

        public new string Draw()
        {
            return "Drawing a rectangle";
        }
    }
}
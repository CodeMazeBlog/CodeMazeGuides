namespace VirtualMethodsInCSharp
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public new string Draw()
        {
            return "Drawing a circle";
        }
    }
}
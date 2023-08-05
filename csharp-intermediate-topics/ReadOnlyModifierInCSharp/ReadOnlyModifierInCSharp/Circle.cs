namespace ReadOnlyModifierInCSharp
{
    public class Circle
    {
        public readonly double Radius;

        public double Area
        {
            get { return Math.PI * Radius * Radius; }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }
    }
}

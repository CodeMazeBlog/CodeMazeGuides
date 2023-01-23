namespace MethodOverridingInCSharp
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override string Draw()
        {
            return $"Drawing a {Color} colored circle with a radius of {Radius} units.";
        }
    }
}

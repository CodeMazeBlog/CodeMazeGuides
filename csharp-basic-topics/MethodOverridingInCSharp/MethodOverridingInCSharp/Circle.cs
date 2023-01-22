namespace MethodOverridingInCSharp
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a {Color} colored circle with a radius of {Radius} units.");
        }
    }
}

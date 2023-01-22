namespace MethodOverridingInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shape = new Shape { Color = "Blue" };
            shape.Draw();

            var circle = new Circle { Color = "Red", Radius = 10.5 };
            circle.Draw();

            var square = new Square { Color = "Green", Side = 5 };
            square.Draw();

            var cube = new Cube { Color = "Yellow", Edge = 7 };
            cube.Draw();
        }
    }
}
namespace MethodOverridingInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shape = new Shape { Color = "Blue" };
            Console.WriteLine(shape.Draw());

            var circle = new Circle { Color = "Red", Radius = 10.5 };
            Console.WriteLine(circle.Draw());

            var square = new Square { Color = "Green", Side = 5 };
            Console.WriteLine(square.Draw());

            var cube = new Cube { Color = "Yellow", Edge = 7 };
            Console.WriteLine(cube.Draw());
        }
    }
}
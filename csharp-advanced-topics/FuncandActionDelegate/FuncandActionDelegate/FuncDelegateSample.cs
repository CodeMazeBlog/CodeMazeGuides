namespace FuncDelegateSample
{
    //Real Life Illustration
    public class Area
    {
        public static double Circle(double length)
        {
            return Math.Pow(length, 2) * Math.PI;
        }

        public static double Square(double length)
        {
            return Math.Pow(length, 2);
        }
    }

    public class Shapes
    {
        public bool ComputeArea()
        {
            Func<double, double> funcTarget = Area.Circle;
            var radius = 4; 
            var areaOfCirlce = funcTarget.Invoke(radius);
            Console.WriteLine($"Area of cirle with radius {0}= {1}", radius, areaOfCirlce);

            funcTarget = Area.Square; 
            var squareLength = 42;
            var areaOfSquare = funcTarget.Invoke(squareLength);
            Console.WriteLine($"Area of square with length {0}= {1}", squareLength, areaOfSquare);

            return true;
        }
    }
}


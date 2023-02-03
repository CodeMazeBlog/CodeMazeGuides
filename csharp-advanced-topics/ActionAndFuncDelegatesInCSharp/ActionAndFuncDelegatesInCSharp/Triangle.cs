namespace ActionAndFuncDelegatesInCSharp
{
    public class Triangle
    {
        public Func<int, int, double> AreaDelegate { get; set; } = new Func<int, int, double>(Area);

        public static double Area(int b, int h)
        {
            return (b * h) / 2.0;
        }
    }
}

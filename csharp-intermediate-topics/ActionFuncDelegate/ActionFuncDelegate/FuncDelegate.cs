namespace ActionFuncDelegate 
{
    public class FuncDelegate 
    {
        private static double valueOfPi = 3.14;
        
        public static double AreaOfCircle(int radius) 
        {
            return valueOfPi * radius * radius;
        }
        
        public static void Demonstrate() 
        {
            Func<int, double> areaDel = new Func<int, double>(FuncDelegate.AreaOfCircle);
            var radius = 4;

            Console.WriteLine("Area of the circle is = " + areaDel(radius));
        }
    }
}

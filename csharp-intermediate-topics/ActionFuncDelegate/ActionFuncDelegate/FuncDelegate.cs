namespace ActionFuncDelegate {

    public class FuncDelegate {

        public static int Radius { get; set; }

        private static double valueOfPi = 3.14;
        
        public static double AreaOfCircle(int radius) {
            return valueOfPi * radius * radius;
        }
        
        public static void Demonstrate() {
            Func<int, double> areaDel = new Func<int, double>(FuncDelegate.AreaOfCircle);
            Radius = 4;

            Console.WriteLine(areaDel(Radius));
        }
    }
}

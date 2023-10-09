namespace CodeMazeGuides.Delegates
{
    public class Program
    {
        public static Action<string, string> ActionStringManipulator = (start, suffix) =>
        {
            Console.WriteLine($"The string reads: {start} {suffix}");
            Console.WriteLine($"The string order inverted reads: {suffix} {start}");
        };

        public static Func<int, int, double> MyShare = Cake.CalculateShare;
        public static Func<double, int, double> GuestShare = Cake.CalculateRemainingShare;

        // class used for Func delegate example
        public class Cake
        {
            public static double CalculateShare(int slices, int share)
            {
                double myCake = slices * (share * 0.01);
                return Math.Round(myCake, 2);
            }

            public static double CalculateRemainingShare (double slices, int guests)
            {
                double remCake = slices / guests;
                return Math.Round(remCake, 2);
            }
        }

        public static void Main()
        {
            // Demonstrate Action delegate - Manipulate string provided
            ActionStringManipulator("I like to eat", "Cake");
                                 
            // Demonstrate Func Delegates - calculate cake allocation
            Console.WriteLine("My share of cake is 40% of 12 slices.");
            Console.WriteLine($"I get { MyShare(12, 40) } slices...");
            Console.WriteLine($"Everyone else gets {GuestShare(12 - MyShare(12, 40), 4)} slices each...");           
        }        
    }    
}

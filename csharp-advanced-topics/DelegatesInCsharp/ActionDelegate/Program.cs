namespace ActionDelegate
{
    class DoMath
    {
        public static void NumberTimesE(int i)
        {
            Console.WriteLine($"{ i * Math.E}");
        }

        public static void NumberTimesPi(int i)
        {
            Console.WriteLine($"{i * Math.PI}");
        }
    }
    
    class Program
    {
        private delegate void Print(int i);
        static void CustomEventPrint(Action<int> print)
        {
            print(40);
        }
        
        public static void Main(string[] args)
        {
            Action<int> printLocalAnonymusAction  = delegate(int i)
            {
                Console.WriteLine($"{i} is the anonymus Number!");
            }; 
            
            CustomEventPrint(printLocalAnonymusAction);

            Print printTimesEuler = DoMath.NumberTimesE;
            Print printTimesPi = DoMath.NumberTimesPi;
            var anotherPrint = printTimesEuler + printTimesPi;
            
            Print print = DoMath.NumberTimesE;
            print -= DoMath.NumberTimesPi;
            
            print(1);
            print.Invoke(3);

            anotherPrint(1);
            anotherPrint.Invoke(3);
        }
        
    }
}
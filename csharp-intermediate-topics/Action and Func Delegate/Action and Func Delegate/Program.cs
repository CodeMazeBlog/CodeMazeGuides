namespace Action_and_Func_Delegate
{
    class Program
    {
        public static int Increment(int originalValue, int incrementValue)
        { 
            return originalValue + incrementValue; 
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>(){1,2,3,4,5,6,7,8,9,10,11};

            Func<int,bool> isEven=num=>num%2==0;
            IEnumerable<int> evenList = list.Where(isEven);

            Action<int> print = num => Console.WriteLine(num);
            evenList.ToList().ForEach(print);

           
            Func<int, int, int> incrementDelegate = Increment; 
            Console.WriteLine(incrementDelegate(10, 20)); 

        }
    }
}
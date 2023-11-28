using System.Collections.Generic;

namespace Action_and_Func_Delegate
{
   public class Program
    {
        public static int Increment(int originalValue, int incrementValue)
        { 
            return originalValue + incrementValue; 
        }
        public static IEnumerable<int> GetEvenNumbers(List<int> numbers, Func<int, bool> isEven) 
        {
            IEnumerable<int> evenList = numbers.Where(isEven);
            return evenList;
        }

        public static void PrintNumbers(List<int> numbers, Action<int> print) 
        {
            numbers.ForEach(print);
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>(){1,2,3,4,5,6,7,8,9,10,11};

            Func<int,bool> isEven=num=>num%2==0;
            IEnumerable<int> evenList = GetEvenNumbers(list, isEven);
                //list.Where(isEven);

            Action<int> print = num => Console.WriteLine(num);
            PrintNumbers(evenList.ToList(),print);
            //evenList.ToList().ForEach(print);

           
            Func<int, int, int> incrementDelegate = Increment; 
            Console.WriteLine(incrementDelegate(10, 20)); 

        }
    }
}
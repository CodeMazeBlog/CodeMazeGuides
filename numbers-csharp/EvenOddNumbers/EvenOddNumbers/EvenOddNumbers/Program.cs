namespace EvenOddNumbers
{
    public class EvenOdd
    {
        public delegate bool IsEvenNumber(int number);
        public static bool IsEven(int number) => (number % 2) == 0;
        public static void IsEvenNum(int number) => Console.WriteLine(number % 2 == 0);
        public static void Main()
        {
            //delegate method with the same type that would be instantiated.
            //instantiate the delegate
            IsEvenNumber even = IsEven;
            //call it
            bool checkEven = even(4);
            Console.WriteLine(checkEven);

            //Func<int, bool> checkEven = IsEven;
            //Console.WriteLine(checkEven(5));

            //Action<int> even = IsEvenNum;
            //even(4);

        }

    }


}

namespace Delegates
{
    public class RegularDelegate
    {
        public delegate bool IsEvenNumber(int number);
        public static bool IsEven(int number) => number % 2 == 0;

        public bool EvenNumber(int number)
        {
            IsEvenNumber even = IsEven;
            //call it
            bool checkEven = even(number);
            return checkEven;
        }
    }
}

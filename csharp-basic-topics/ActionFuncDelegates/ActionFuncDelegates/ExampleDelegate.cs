
namespace ActionFuncDelegates
{
    public class ExampleDelegate
    {
        public delegate int FirstDelegate(int n); 
        FirstDelegate myDelegate = Product;
        
        public int TestDelegate(int t)
        {
            myDelegate += AddTwo;
            myDelegate += CountOne;
            myDelegate += (x) => x * 3;
            var result = myDelegate(t);
            return result;
        }

        public static int CountOne(int number)
        {
            number += 1;
            return number;
        }
        public static int AddTwo(int number)
        {
            number = number + 2;
            return number;
        }
        public static int Product(int number)
        {
            number = number * 3;
            return number;
        }
    }
}

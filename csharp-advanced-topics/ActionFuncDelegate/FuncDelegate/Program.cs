namespace FuncDelegate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Func Delegate with the anonymous method having zero parameter and return int.
            Func<int> getRandomNumber = () =>
            {
                return new Random().Next();
            };
            int number = getRandomNumber();
            Console.WriteLine($"The Random number is {number}");

            //Func Delegate with the anonymous method taking one parameter and return int.
            Func<int, int> square = x =>
            {
                return x * x;
            };
            int result = square(5);
            Console.WriteLine($"The square of the number {result}");

            //Func Delegate with the anonymous method taking two parameter and return bool.
            Func<int, int, bool> areEqual = (x, y) =>
            {
                return x == y;
            };
            bool equal = areEqual(5, 5);  // equal = true
            if(equal)
            {
                Console.WriteLine("The numbers are equal");
            }
            else
            {
                Console.WriteLine("The numbers are not equal");
            }
        }
    }
}
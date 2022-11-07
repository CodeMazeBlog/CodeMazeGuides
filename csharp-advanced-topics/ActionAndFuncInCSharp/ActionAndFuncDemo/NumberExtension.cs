
namespace ActionAndFuncDemo
{
    public static class NumberExtension
    {
        static Func<int, bool> CheckPrime = (int number) =>
        {
            if (number == 2)
                return true;
            else if (number <= 1 || number % 2 == 0)
                return false;
            else
            {
                var boundary = (int)Math.Floor(Math.Sqrt(number));
                for (int i = 3; i <= boundary; i += 2)
                    if (number % i == 0)
                        return false;
                return true;
            }
        };
        public static bool IsPrime(this int number)
        {
            return CheckPrime(number);
        }
    }
}

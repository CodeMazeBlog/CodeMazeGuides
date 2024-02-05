
namespace FuncNActionDelegates
{
    public class ActionDelegate
    {
        public bool IsPrimeNumber(int num)
        {
            var factors = 0;

            for (var i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    factors++;
                }
            }

            return factors == 2;
        }

        public void PrintResult(int num)
        {
            if (IsPrimeNumber(num))
            {
                Console.WriteLine($"{num} is a Prime Number");
            }
            else
            {
                Console.WriteLine($"{num} is Not a Prime Number");
            }

            Console.ReadLine();
        }

    }

}

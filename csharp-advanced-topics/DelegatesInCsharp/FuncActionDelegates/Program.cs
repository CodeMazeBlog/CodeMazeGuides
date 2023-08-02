
namespace FuncActionDelegates
{
    class Program
    {
        static int powerActionResult = 0;

        static void Main(string[] args)
        {

            int powerActionAnonymousResult = 0;
            int powerActionLambdaResult = 0;

            Func<int, int, int> Power = PoweredTo;

            Func<int, int, int> PowerAnonymous = delegate (int baseNumber, int exponent) {
                return (int)Math.Pow(baseNumber, exponent);
            };

            Func<int, int, int> PowerLambda = (int baseNumber, int exponent) =>
                (int)Math.Pow(baseNumber, exponent);

            Action<int, int> PowerAction = PoweredToAction;

            Action<int, int> PoweredActionAnonymous = delegate (int baseNumber, int exponent) {
                powerActionAnonymousResult = (int)Math.Pow(baseNumber, exponent);
            };

            Action<int, int> PoweredActionLambda = (int baseNumber, int exponent) =>
                powerActionLambdaResult = (int)Math.Pow(baseNumber, exponent);


            int power = Power(10, 5);
            int powerAnonymous = PowerAnonymous(10, 5);
            int powerLambda = PowerLambda(10, 5);
            Console.WriteLine(power);
            Console.WriteLine(powerAnonymous);
            Console.WriteLine(powerLambda);

            PowerAction(10, 5);
            PoweredActionAnonymous(10, 5);
            PoweredActionLambda(10, 5);

            Console.WriteLine(powerActionResult);
            Console.WriteLine(powerActionAnonymousResult);
            Console.WriteLine(powerActionLambdaResult);

        }

        static int PoweredTo(int baseNumber, int exponent)
        {
            return (int)Math.Pow(baseNumber, exponent);
        }

        static void PoweredToAction(int baseNumber, int exponent)
        {
            powerActionResult = (int)Math.Pow(baseNumber, exponent);
        }
    }
}









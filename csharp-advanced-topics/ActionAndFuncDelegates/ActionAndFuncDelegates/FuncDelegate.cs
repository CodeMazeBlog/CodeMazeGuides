namespace ActionAndFuncDelegates
{
    public class FuncDelegate
    {
        public static int Modulus(int x, int y)
        {
            return x % y;
        }

        Func<int, int, int> funcWithAnon = delegate (int numOne, int numTwo)
        {
            return numOne % numTwo;
        };

        public int FuncWithAnon(int one, int two)
        {
            return funcWithAnon(one, two);
        }

        Func<int, int, int> funcWithLambda = (numOne, numTwo) =>
        numOne % numTwo;

        public int FuncWithLambda(int one, int two)
        {
            return funcWithLambda(one, two);
        }
    }
}


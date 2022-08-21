namespace Func_Action_Delegate_Library.Func
{
    public class FuncWithAnnonymousMethod
    {
        public Func<long, int, double> calculateMultiplication = delegate (long a, int b)
        {
            return a + b;
        };
    }
}
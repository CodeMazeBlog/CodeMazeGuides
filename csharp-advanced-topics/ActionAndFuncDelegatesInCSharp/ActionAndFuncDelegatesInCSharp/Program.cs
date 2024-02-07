using ActionAndFuncDelegatesInCSharp.DelegatesExamples;
using static ActionAndFuncDelegatesInCSharp.DelegatesExamples.FuncDelegate;

namespace ActionAndFuncDelegatesInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fd = new FuncDelegate();
            fd.Execute(Operation.Multiply);

            var ad = new ActionDelegate();
            ad.Execute();

            var pd = new PredicateDelegate();
            pd.Execute();
        }
    }
}
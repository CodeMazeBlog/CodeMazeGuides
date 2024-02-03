
using ActionAndFuncDelegatesInCSharp.DelegatesExamples;

namespace ActionAndFuncDelegatesInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            FuncDelegate fd = new FuncDelegate();
            fd.Execute();

            ActionDelegate ad = new ActionDelegate();
            ad.Execute();

            PredicateDelegate pd = new PredicateDelegate();
            pd.Execute();
        }
    }
}
using _Delegate;
using _Action;
using _Func;

namespace _Program
{
    public class Program
    {
        static void Main(string[] args)
        {                
            Delegates funcAndAction = new Delegates();
            funcAndAction.MultiDelegateMethod(4,5);
            funcAndAction.DelegateMethod();
            Actions action = new Actions();
            action.ActionMethod();
            action.ActionMethod2();
            Funcs funcs = new Funcs();
            Console.WriteLine(funcs.FuncMethod());
            // funcs.FuncMethod2();
        }
    }
}
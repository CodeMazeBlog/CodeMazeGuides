using System.Diagnostics;
using System.Reflection;

namespace CallerMethod
{
    public static class Program
    {
        public static void Main()
        {
            DoWork();
        }

        public static void DoWork()
        {
            PrintCallerName();
            PrintCallerNameWithoutStack();
        }

        public static void PrintCallerName()
        {
            MethodBase caller = new StackTrace().GetFrame(1).GetMethod();
            string callerMethodName = caller.Name;
            string calledMethodName = MethodBase.GetCurrentMethod().Name;

            Console.WriteLine("The caller method is: " + callerMethodName);
            Console.WriteLine("The called method is: " + calledMethodName);
        }

        public static void PrintCallerNameWithoutStack()
        {
            MethodBase caller = new StackFrame(1, false).GetMethod();
            string callerMethodName = caller.Name;
            string calledMethodName = MethodBase.GetCurrentMethod().Name;

            Console.WriteLine("The caller method is: " + callerMethodName);
            Console.WriteLine("The called method is: " + calledMethodName);
        }
    }
}
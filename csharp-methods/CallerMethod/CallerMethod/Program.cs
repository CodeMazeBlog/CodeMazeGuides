using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

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
            PrintCallerNameWithCallerMemberNameAttribute();
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

        public static void PrintCallerNameWithCallerMemberNameAttribute([CallerMemberName] string callerMethodName = "")
        {
            string calledMethodName = MethodBase.GetCurrentMethod().Name;

            Console.WriteLine("The caller method is: " + callerMethodName);
            Console.WriteLine("The called method is: " + calledMethodName);
        }
    }
}
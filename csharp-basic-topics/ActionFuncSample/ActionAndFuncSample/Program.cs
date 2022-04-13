using System;

namespace ActionAndFuncSample
{
    public class Program
    {
        // Delegate declaration which is just a method reference.
        delegate string MyDelegate(string s);
        static void Main(string[] args)
        {
            // assign the delegate a method.
            MyDelegate myDelegate = (string s) => { return s; };
            // invoke a delegate
            Console.WriteLine(myDelegate?.Invoke("Hello World from delegate!!!"));

            // Action delegate.
            Action<string> action = (string s) => Console.WriteLine(s);
            action("Hello World from Action!!!");

            // Func delegate.
            Func<string, string> func = (string s) => s;
            Console.WriteLine(func("Hello World From Func"));

            // Covariance with func return type.

            // It has return type as object.
            Func<string, object> funcWithCovariance;

            // Assigned a delegate/lambda which has return type as string
            funcWithCovariance = (string s) => s;

            Console.WriteLine(funcWithCovariance("Hello from func with covariance of return type!!!"));

            // Assigned a delegate/lambda which has return type as int
            funcWithCovariance = (string s) => int.Parse(s);

            Console.WriteLine(funcWithCovariance("123"));


            // ContraVariance with Action parameter type.Same applies to Func input parameter type.
            Action<string> actionWithContravariance;

            // Assigning a lambda would require explicit type casting
            actionWithContravariance = (Action<object>)((object o) => Console.WriteLine(o));

            // Below is a complier error as the method assigned are contravariant not the parameters.
            //actionWithContravariance(1);
            
            actionWithContravariance("Hello!!!");

            // Assign a method 
            actionWithContravariance = Test;

            actionWithContravariance("Hello");

            // Passing delegate as method parameter.
            // something which is not possible with events.
            Parameterized(s => Console.WriteLine(s));

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        public static object CovarianceMethod(Func<string,object> covariant, string param)
        {
           return covariant(param);
        }

        public static string ContraVarianceMethod(Func<string, string> covariant, string param)
        {
            return covariant(param);
        }


        private static void Test(object o)
        {
            Console.WriteLine($"{o} World!!!");
        }

        private static void Parameterized(Action<string> action)
        {
            action("Hello from parameterized!!!");
        }
    }
}

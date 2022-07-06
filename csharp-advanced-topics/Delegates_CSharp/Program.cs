
namespace Delegates_CSharp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        // Main method
        static public void Main()
        {

            invokeAll_Action_Delegates();

            invokeAll_Func_Delegates();

        }


        #region Action_Delegates
        
        static void invokeAll_Action_Delegates()
        {
            //Custom Action Delegate
            // Creating object of my_delegate
            sub_custom_Delegate obj = Subtract;

            // Invoking 
            obj(10, 5);


            // Using Built-In / Generic Action delegate
            // Here, Action delegate 
            // has two input parameters
            Action<int, int> action_generic_Delegate = Subtract_Built_In;
            action_generic_Delegate(20, 5);


            //Anonymous Method Action Delegate
            Action<string> anony_action_Method = delegate (string str)
            {
                Console.WriteLine(str);
                Console.WriteLine();
            };
            anony_action_Method("System.Action / Built-In Delegate Invoked using Anonymous method !");


            //Lambda Expression Action Delegate
            Action<string> lambda_action_Delegate = str => Console.WriteLine(str);
            lambda_action_Delegate("System.Action / Built-In Delegate Invoked using Lambda Expression!");


            // Just to make separation on Console
            Console.WriteLine();
            Console.WriteLine("==== ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== ====");
            Console.WriteLine();

        }

        #region Custom Action Delegate

        // Declaring the delegate   
        public delegate void sub_custom_Delegate(int a, int b);

        // Method to be invoked
        public static void Subtract(int a, int b)
        {
            Console.WriteLine("Custom Action Delegate Invoked : " + (a - b));
            Console.WriteLine();
        }

        #endregion Custom Action Delegate


        #region Built-in / Generic Action Delegate

        // Declaring the delegate  NOT REQUIERD!!!
        //public delegate void sub_custom_Delegate(int p, int q);

        // Method to be invoked
        public static void Subtract_Built_In(int p, int q)
        {
            Console.WriteLine("System.Action / Built-In Delegate Invoked : " + (p - q));
            Console.WriteLine();
        }

        #endregion Built-in / Generic Action Delegate

        #endregion Action_Delegates



        #region Func_Delegates

        static void invokeAll_Func_Delegates()
        {
            // Creating object of my_delegate
            multiply_Custom_Delegate obj = Multiply;

            //Invoking
            Console.WriteLine("Custom Function Delegate Invoked : " + obj(12, 34, 35, 34));
            Console.WriteLine();


            // Using Built-In / Generic Func delegate
            // Here, Func delegate has
            // four Input parameters of int type
            // one result parameter of int type
            Func<int, int, int, int, int> func_generic_Delegate = Multiply_Built_In;
            Console.WriteLine("System.Func / Built-In Delegate Invoked : " + func_generic_Delegate(10, 100, 1000, 1));
            Console.WriteLine();


            //Anonymous Method Func Delegate
            Func<string, string> anony_function_Method = delegate (string a)
            {
                return a + "System.Func Built-In Delegate Invoked using Anonymous Method !";
            };
            Console.WriteLine(anony_function_Method("Message = "));
            Console.WriteLine();


            //Lambda Expression Func Delegate
            Func<string, string> lambda_func_Delegate = (string a) => a + "System.Func Built-In Delegate Invoked using Lambda Expression !";
            Console.WriteLine(lambda_func_Delegate("Message = "));

        }

        #region Custom Function Delegate
        // Declaring the delegate
        public delegate int multiply_Custom_Delegate(int a, int b, int c, int d);

        // Method to be invoked
        public static int Multiply(int a, int b, int c, int d)
        {
            return a * b * c * d;
        }

        #endregion Custom Function Delegate

        #region Built-In Function Delegate

        // Method to be Invoked
        public static int Multiply_Built_In(int a, int b, int c, int d)
        {
            return a * b * c * d;
        }

        #endregion Built-In Function Delegate


        #endregion Func_Delegates
    }
}

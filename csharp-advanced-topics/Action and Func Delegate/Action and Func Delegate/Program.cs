
using Action_and_Func_Delegate;

namespace DelegatesInCsharp
{
    class Program
    {
        static void Function1()
        {
            Console.WriteLine("This is a delegate");
        }

        static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }


        static void Main(string[] args)
        {
            //simple delegate usage
            var test = new TestDelegate(Function1);
            test();

            #region delegate with parameters but no return type
            //create a new instance of CalculatorDelegate and pass the Add function to it
            var addDelegate = new CalculatorDelegate(Add);

            //invoke the add function by calling addDelegate and passing the value
            addDelegate(3, 5);

            //create a new instance of CalculatorDelegate and pass the Multiply function to it
            var multipyDelegate = new CalculatorDelegate(Multiply);

            //invoke the add function by calling multipyDelegate and passing the value
            multipyDelegate(3, 5);
            #endregion



            #region delegate with parameters and return type
            //create a new instance of CalculatorDelegate and pass the Add function to it
            var addDel = new CalculateDelegate(DelegateMethod.Add);

            //invoke the add function by calling addDele and passing the parameters
            var result = addDel(3, 5);
            Console.WriteLine(result);
            #endregion




            #region ACTION DELEGATE
            //create a new instance of the action delegate
            var action = new Action<int, int>(Add);

            //invoke action
            action(3, 5);

            //you can also do this
            Action<int, int> action1 = Add;
            action1(3, 5);
            #endregion



            # region FUNC DELEGATE
            //create a new instance of the Func delegate
            var func = new Func<int, int, int>(DelegateMethod.Add);

            //invoke addDelegate
            func(3, 5);

            //you can also do this
            Func<int, int, int> func1 = DelegateMethod.Add;
            func1(3, 5);
            #endregion
        }
    }
}


using System;

namespace Action
{
    class Program
    {
        static void ConsolePrint(int i)
        {
            Console.WriteLine(i);
        }

        static void Main(string[] args)
        {
            Action<int> printActionDel = ConsolePrint;
            printActionDel(10);

            // You can initialize an Action delegate using the new keyword 

            Action<int> printActionDelWithNewKeyword = ConsolePrint;

            //Or

            Action<int> printActionDelWithNewKeyword2 = new Action<int>(ConsolePrint);

            // Anonymous method with Action delegate

            Action<int> printActionDelWithAnonymousMethod = delegate(int i)
            {
                Console.WriteLine(i);
            };

            printActionDelWithAnonymousMethod(10);

            // lambda method with Action delegate

            Action<int> printActionDelWithLambda = i => Console.WriteLine(i);
       
            printActionDelWithLambda(10);
        }
    }
}


using System.Runtime.CompilerServices;

namespace Delegate
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Action delegate
            Action<string> displayNameAndAge = DisplayDetails;
            displayNameAndAge("jack");


            /* delegate with anonymous method */
            Action<string> delegateWithAnonymousMethod = delegate (string message)
            {
                Console.WriteLine(message);
            };
            delegateWithAnonymousMethod("delegate with anonymous method");

            //delelgate with lamda expression

            Action<int> printNumber = Number => Console.WriteLine(Number);

            printNumber(1);
            #endregion

            #region Func delegate

            //func delegate takes input as string and return string

            Func<string, string> name = DisplayName;
            string namereceive = name("steve");
            Console.WriteLine(namereceive);


            //func delegate example
            Func<int, int, int> additionAnswer = Addition;

            int result = additionAnswer(5, 5);

            Console.WriteLine(result);

            //Func with anonymous type

           Func<int> showNumber = delegate () { int no = 5; return no; };

            showNumber();

            //func with lamda
            Func<int, int> square = no => no * no;

            Console.WriteLine(square(5));
            #endregion

        }

        #region Methods
        static void DisplayDetails(string name)
        {
            Console.WriteLine(name);
        }

        static string DisplayName(string name)
        {
            return name;
        }

        static int Addition(int no1, int no2)
        {
            return no1 + no2;
        }
        #endregion


    }
}

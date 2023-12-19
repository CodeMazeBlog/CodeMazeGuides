using System.Text;

namespace ActionAndFuncInCsharp
{
    public class Program
    {
        //Declare Action delegate with no parameters
        public static Action display = PrintMessage;

        //Creating Action delegate with parameters
        public static Action<string, int> printEmployeeNameAndNo = (name, no) =>
        {
            Console.WriteLine($"Employee Name: {name},and No: {no}");
        };

        //Creating Func delegate with parameters
        public static Func<int, int, int> add = (x, y) => x + y;

        //Creating Func delegate with no parameters
        public static Func<string> sayHello = () => "Hello";

        public static void Main(string[] args)
        {
            //Calling Action delegate
            display();

            //Calling Action delegate with parameter
            printEmployeeNameAndNo("John", 146);

            //Calling Func delegate with parameter
            Console.WriteLine(add.Invoke(10, 20));

            //Calling Func delegate
            sayHello();
        }
        internal static void PrintMessage()
        {
            Console.WriteLine("Hello is printed");
        }


    }

}


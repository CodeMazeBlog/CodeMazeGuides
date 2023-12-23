using System.Text;

namespace ActionAndFuncInCsharp
{
    public class Program
    {
        public static Action display = PrintMessage;

        public static Action<string, int> printEmployeeNameAndNo = (name, no) =>
        {
            Console.WriteLine($"Employee Name: {name},and No: {no}");
        };

        public static Func<int, int, int> add = (x, y) => x + y;

        public static Func<string> sayHello = () => "Hello";

        public static void Main(string[] args)
        {
            display();

            printEmployeeNameAndNo("John", 146);

            Console.WriteLine(add.Invoke(10, 20));

            sayHello();
        }

        internal static void PrintMessage()
        {
            Console.WriteLine("Hello is printed");
        }
    }
}


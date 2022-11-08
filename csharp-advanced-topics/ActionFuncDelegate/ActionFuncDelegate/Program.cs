
namespace ActionFuncDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            var displayMsg = new Action(ActionFuncMethods.DisplayMsg);

            var display = new Action<string>(ActionFuncMethods.Display);

            var displayNumbers = new Action<int, int>(ActionFuncMethods.DisplayNumbers);

            var add = new Func<int, int, int>(ActionFuncMethods.Add);

            var showAddition = new Func<int, int, string>(ActionFuncMethods.ShowAddition);

            var fullName = new Func<string, string, string>(ActionFuncMethods.FullName);

            var rand = new Func<int>(ActionFuncMethods.DisplayNum);

            Console.WriteLine("\n***************** Action Delegates ***************\n");

            displayMsg();

            display("Hello");

            displayNumbers(1, 8);

            Console.WriteLine();

            Console.WriteLine("**************** Func Delegates *****************\n");

            var addVal = add(13, 25);

            var showVal = showAddition(55, 85);

            var strName = fullName("abc", "xyz");

            var randNums = rand();

            Console.WriteLine("Sum of two numbers: {0}", addVal);
            Console.WriteLine(showVal);
            Console.WriteLine(strName);
            Console.WriteLine("Random Numbers: {0}", randNums);

            Console.ReadLine();
        }
    }
}

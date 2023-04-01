
namespace ActionFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            var example =  new ExampleDelegate();
            var test = example.TestDelegate(2);

            var actionExample = new ActionFuncExample();
            var result = actionExample.TestFuncDelegate(10, "Rambo");

            actionExample.TestActionDelegate("Test", 20);

            Console.WriteLine(test);
            Console.WriteLine(result);
        }
    }
}
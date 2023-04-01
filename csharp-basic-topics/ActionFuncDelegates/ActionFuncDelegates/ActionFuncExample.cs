
namespace ActionFuncDelegates
{
    public class ActionFuncExample
    {
        Action<string, int> ActionDelegate = TestMethod;
        Func<int, string, string> FuncDelegate;

        public void TestActionDelegate(string name, int age)
        {
            ActionDelegate(name, age);
        }

        public string TestFuncDelegate(int age, string name)
        {
            FuncDelegate += TestFunc;
            var result = FuncDelegate(age, name);
            return result;
        }

        public static void TestMethod(string name, int age)
        {
            Console.WriteLine($"{name} is {age} years old");
        }
        public static string TestFunc(int age, string name)
        {
            return $"{name} is {age} years old";
        }
    }
}

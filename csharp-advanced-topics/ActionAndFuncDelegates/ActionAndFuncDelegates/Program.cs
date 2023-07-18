namespace ActionAndFuncDelegates
{

    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = "Arya";
            int userAge = 17;

            Action<string, int> action = ActionDelegate.LogPerson;

            action(userName, userAge);

            
            Func<int, int, int> funcDelegate =FuncDelegate.Modulus;

            int result = funcDelegate(25, 10);

            Console.WriteLine(result);
        }
    }
}

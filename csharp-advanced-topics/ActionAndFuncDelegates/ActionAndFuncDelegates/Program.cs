namespace ActionAndFuncDelegates
{

    internal class Program
    {
        static void Main(string[] args)
        {
            string _userName = "Arya";
            int _userAge = 17;

            Action<string, int> action = ActionDelegate.LogPerson;

            action(_userName, _userAge);

            
            Func<int, int, int> funcDelegate = FuncDelegate.Modulus;

            int result = funcDelegate(25, 10);

            Console.WriteLine(result);
        }
    }
}

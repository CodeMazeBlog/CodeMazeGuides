namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> showMessage = Methods.DisplayMessage;
            Action displayNumber = Methods.DisplayRandomNumber;
            
            Func<int, int, int> addFunc = Methods.AddNumbers;
            Func<string, string, string> showName = Methods.ShowFullName;

            showMessage("Hello, World!");
            displayNumber();

            int result = addFunc(3, 4); 
            Console.WriteLine(result);

            string name = showName("Dhara", "Gondaliya");
            Console.WriteLine(name);
        }
    }
}

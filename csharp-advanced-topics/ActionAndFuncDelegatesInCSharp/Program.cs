namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an Action delegate and assign the method to it
            Action<string> showMessage = Methods.DisplayMessage;
            Action displayNumber = Methods.DisplayRandomNumber;
            

            // Create a Func delegate and assign the method to it
            Func<int, int, int> addFunc = Methods.AddNumbers;
            Func<string, string, string> showName = Methods.ShowFullName;

            // Invoke the delegates
            showMessage("Hello, World!"); // Output: Hello, World!
            displayNumber();

            int result = addFunc(3, 4); 
            Console.WriteLine(result); // Output: 7

            string name = showName("Dhara", "Gondaliya");
            Console.WriteLine(name);
        }
    }
}

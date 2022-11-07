namespace ActionAndFuncDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Action Example: syntax Action<T>
            Action<string> messageAction;

            //Action delegate example
            messageAction = BusinessClass.PrintMyMessage;
            messageAction("Hello, Hi there!");
            messageAction("Hope you are doing well!");

            //Action delegate with Anonymous method
            messageAction = delegate (string message) { Console.WriteLine(message); };
            messageAction("Hello, Hi there!");
            messageAction("Hope you are doing well!");

            //Action delegate with Lambda expression
            messageAction = (message) => { Console.WriteLine(message); };
            messageAction("Hello, Hi there!");
            messageAction("Hope you are doing well!");

            //Func Example: syntax Func<T, T, TResult>
            Func<string, string, string> messageFunc;

            //Func delegate example
            messageFunc = BusinessClass.GetMyMessage;
            Console.WriteLine(messageFunc("Hi there!", "Hope you are doing well."));
            Console.WriteLine(messageFunc(String.Empty, "Where have you been these days"));

            //Func with Anonymous Method
            messageFunc = delegate (string message1, string message2) { return $"You Said: {message1} {message2}"; }; 
            Console.WriteLine(messageFunc("Hi there!", "Hope you are doing well.")); 
            Console.WriteLine(messageFunc(String.Empty, "Where have you been these days"));

            //Func with Lambda expression
            messageFunc = (string message1, string message2) => { return $"You Said: {message1} {message2}"; }; 
            Console.WriteLine(messageFunc("Hi there!", "Hope you are doing well.")); 
            Console.WriteLine(messageFunc(String.Empty, "Where have you been these days"));

            //**************************************//

            //Real life example of using Func delegate with extension method
            Console.Write("Enter your number:");
            var inputNumber = Console.ReadLine(); 
            if (int.Parse(inputNumber).IsPrime()) 
                Console.WriteLine($"{inputNumber} is prime"); 
            else 
                Console.WriteLine($"{inputNumber} is not prime");

            Console.ReadLine();
        }

        
    }

    public class BusinessClass
    {
        public static void PrintMyMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetMyMessage(string message1, string message2)
        {
            return $"You Said: {message1} {message2}";
        }
    }
}

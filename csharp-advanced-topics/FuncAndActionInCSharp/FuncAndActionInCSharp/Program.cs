namespace FuncAndActionInCSharp
{
    internal class Program
    {
        // Define your delegate
        public delegate void MyDelegate(string message);

        static void Main(string[] args)
        {
            /************************************
             * EXAMPLE 1: Demonstration of a delegate
             ************************************/

            // Instantiate the delegate by assigning the `PrintMessage` method
            MyDelegate myDelegate = PrintMessage;

            // Call the delegate with the message "myDelegate: Hello World!".
            myDelegate("myDelegate: Hello World!");

            /************************************
             * EXAMPLE 2: Demonstration of an Action delegate
             ************************************/

            // Action with no parameters
            Action myAction = () => Console.WriteLine("myAction: Hello World!");
            myAction(); // Output -> myAction: Hello World!

            // Action with multiple parameters
            Action<string, string> myAction2 = (message1, message2) => Console.WriteLine($"myAction: {message1} {message2}");
            myAction2("Hello", "World!"); // Output -> myAction: Hello World!

            /************************************
             * EXAMPLE 3: Demonstration of a Func delegate
             ************************************/

            // Define a Func delegate that takes a string parameter and return an int
            Func<string, int> getStringLength = value => value.Length;

            // Invoke the getStringLength Func delegate and hold the return int value in a variable
            int stringLength = getStringLength("Hello World!");

            // Print the stringLength variable
            Console.WriteLine("The string length is: " + stringLength);
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
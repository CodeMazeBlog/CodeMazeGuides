

namespace CodeMazeGuides.Sample.Delegates
{
    public static class ActionDelegates
    {
        // Define a function that compute the cube of an integer .
        public static Action WelcomeToActionDelegate = () => Console.WriteLine("You are welcome to Action Delegate sample that takes no parameter");   // Declaration 
		 
		// Define a function that squares an integer.
		public static Action<string> WelcomeToActionDelegateWithParam = name => Console.WriteLine($"Dear {name}!, you are welcome to Action Delegate sample that takes one parameter"); // Declaration 
		 
		// Function composition using Func delegates.
		public static Action<int, int> ProductOfTwoNos = (a, b) => Console.WriteLine($"Product: {a * b}");   // Declaration 
																											 // Invocation productOfTwoNos(10, 4);   Invokes the action, which prints "Product: 40".
		public static Action<string, int, string, int> DisplayStdInfo = (stdName1, stdAge1, stdName2, stdAge2) => 
        { 
            Console.WriteLine($"Name: {stdName1}, Age: {stdAge1}"); 
            Console.WriteLine($"Name: {stdName2}, Age: {stdAge2}"); 
        }; // Declaration
           // displayStdInfo("Alice", 10, "Charice",11 ); // Invokes the action, which prints "Name: Alice, Age: 10 // Name: Charice, Age: 11" 
    }
}

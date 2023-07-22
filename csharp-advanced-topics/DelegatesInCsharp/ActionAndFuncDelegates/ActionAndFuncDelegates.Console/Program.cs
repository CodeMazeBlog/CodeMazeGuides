// See https://aka.ms/new-console-template for more information

using ActionAndFuncDelegates.Services;

// Create an instance of ActionDelegateService
var actionDelegateService = new ActionDelegateService();

// Create an instance of FuncDelegateService
var funcDelegateService = new FuncDelegateService();


#region Action Delegate

#region Greeting

Console.Write("Enter your name: ");
string userName = Console.ReadLine()!;
Methods.Greeting(actionDelegateService, userName);
Console.Write("\n");

#endregion

#region Event Handling

Console.Write("\nEnter event name(s) (comma separated): ");
string eventNamesInput = Console.ReadLine()!;
string[] eventNames = eventNamesInput.Split(',');

List<string> registeredEvents = new();
foreach (var eventName in eventNames)
{

    registeredEvents.Add(eventName.Trim());
    
}

Methods.EventRegistration(actionDelegateService, registeredEvents, userName);
Console.Write("\n");

#endregion

#endregion



#region Fucn Delegate

#region Mathematical Calculation

Console.Write("\nMathematical Operations using Func delegate:");

// Prompt the user to select a mathematical method
Console.Write("Select a mathematical method:");
Console.Write("\n1. Addition");
Console.Write("\n2. Subtraction");
Console.Write("\n3. Multiplication");
Console.Write("\n4. Division");
Console.Write("\n");
Console.Write("\nEnter your choice (1/2/3/4): ");

int choice;
if (int.TryParse(Console.ReadLine(), out choice))
{
    int num1, num2;
    Console.Write("\nEnter the first number: ");
    num1 = int.Parse(Console.ReadLine()!);
    Console.Write("\nEnter the second number: ");
    num2 = int.Parse(Console.ReadLine()!);

    Methods.PerformMathematicalCalculation(funcDelegateService, choice, num1, num2);

}
else
{
    Console.WriteLine("Invalid input. Please enter a numeric choice (1/2/3/4).");
}

#endregion

#region EventFiltering

#endregion

#endregion



public static class Methods
{

    #region Action Delegate Methods

    public static void Greeting(ActionDelegateService actionDelegateService, string userName)
    {
        // Assign a lambda expression to the GreetAction delegate
        actionDelegateService.GreetAction = (name) =>
        {
            Console.WriteLine($"Hello, {name}! Welcome to our the maze.");
        };

        actionDelegateService.Greet(userName);
    }

    public static void EventRegistration(ActionDelegateService actionDelegateService, List<string> eventNames, string userName)
    {
        actionDelegateService.EventRegistrationAction = (eventNames, userName) =>
        {
            Console.WriteLine($"'{userName}' has registered for the following events: ");
            foreach (var eventName in eventNames)
            {
                Console.WriteLine($"- {eventName}");
            }

        };

        actionDelegateService.RegisterForEvent(eventNames, userName);

    }



    #endregion

    #region Func Delegate Methods

    public static void PerformMathematicalCalculation(FuncDelegateService funcDelegateService, int choice, int num1, int num2)
    {
        

        // Implement mathematical operations using Func delegates
        funcDelegateService.AdditionFunc = (a, b) => a + b;
        funcDelegateService.SubtractionFunc = (a, b) => a - b;
        funcDelegateService.MultiplicationFunc = (a, b) => a * b;
        funcDelegateService.DivisionFunc = (a, b) => (double)a / b;

        switch (choice)
        {
            case 1:
                
                Console.WriteLine($"Result: {funcDelegateService.Add(num1, num2)}");
                Console.Read();
                break;
            case 2:
                
                Console.WriteLine($"Result: {funcDelegateService.Subtract(num1, num2)}");
                Console.Read();
                break;
            case 3:
                
                Console.WriteLine($"Result: {funcDelegateService.Multiply(num1, num2)}");
                Console.Read();
                break;
            case 4:
               
                Console.WriteLine($"Result: {funcDelegateService.Divide(num1, num2)}");
                Console.Read();
                break;
            default:

                Console.WriteLine("Invalid choice. Please select a valid option (1/2/3/4).");
                Console.Read();
                break;
        }

    }

    #endregion


}

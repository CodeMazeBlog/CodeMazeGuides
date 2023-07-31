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
Console.WriteLine($"{userName} has registered for the following events: ");

Methods.EventRegistration(actionDelegateService, registeredEvents, userName);
Console.Write("\n");

#endregion

#endregion



#region Func Delegate

#region EventFiltering From Predefined List

Console.Write("\nLet's try filter your events by event name:");

// Prompt the user to select a mathematical method
Console.Write("\nSelect an event:");

for (int i = 0; i < registeredEvents.Count; i++)
{
    // Get the current item's count and name
    string itemName = registeredEvents[i];

    // Display the count and name in the console
    Console.Write($"\n{i + 1}. {itemName}");
}

string choiceString = string.Join("/", Enumerable.Range(1, registeredEvents.Count));

Console.Write($"\n\nEnter your choice: {choiceString}: ");

int chosenValue;
bool validInput = false;
var filterString = string.Empty;

do
{
    string userInput = Console.ReadLine()!;
    if (!string.IsNullOrEmpty(userInput) && int.TryParse(userInput, out chosenValue))
    {
        if (chosenValue >= 1 && chosenValue <= registeredEvents.Count)
        {
            validInput = true;
            filterString = Methods.GetSelectedItem(registeredEvents, chosenValue);

        }
        else
        {
            Console.WriteLine($"\nInvalid input. Please enter a numeric choice {choiceString}:\n"); 
        }

    }
    else
    {
        Console.Write($"\nInvalid input. Please enter a numeric choice {choiceString}:\n");

    }

} while (!validInput);

var filteredEvents = Methods.FilterEvents(funcDelegateService, filterString, registeredEvents);

Methods.PrintFilteredEvents(filteredEvents);



#endregion

#region Event Filtering By Search Text

Console.Write("\n\nNow, let's type in a value to use a the filter criteria:");

string filerCriteria;

Console.Write("\nEnter your search value: ");

filerCriteria = Console.ReadLine()!;

if (!string.IsNullOrEmpty(filerCriteria))
{
    var eventsAfterFiltering = Methods.FilterEventsBySearchText(funcDelegateService, filerCriteria.Trim(), registeredEvents);

    Console.Write($"\n Filtered events:");

    for (int i = 0; i < eventsAfterFiltering.Count; i++)
    {
        string itemName = eventsAfterFiltering[i];

        Console.Write($"\n{i + 1}. {itemName}");
    }

}
else
{
    Console.Write("Invalid input. Please enter a value");
}



#endregion

#region Mathematical Calculation

Console.Write("\n\nMathematical Operations using Func delegate:");

// Prompt the user to select a mathematical method
Console.Write("Select a mathematical method:");
Console.Write("\n1. Addition");
Console.Write("\n2. Subtraction");
Console.Write("\n3. Multiplication");
Console.Write("\n4. Division");
Console.Write("\n\nEnter your choice (1/2/3/4): ");

int choice;
if (int.TryParse(Console.ReadLine(), out choice))
{
    int num1, num2;

    Console.Write("\nEnter the first number: ");
    num1 = int.Parse(Console.ReadLine()!);

    Console.Write("Enter the second number: ");
    num2 = int.Parse(Console.ReadLine()!);

    Methods.PerformMathematicalCalculation(funcDelegateService, choice, num1, num2);

}
else
{
    Console.WriteLine("Invalid input. Please enter a numeric choice (1/2/3/4):");
}

Console.Write("\nLet's calculate your tithe:");
Console.Write("\nEnter your earnings: ");
double earnings = double.Parse(Console.ReadLine()!);

// Calculate the tithe using the Func delegate
var titheAmount = Methods.CalculateTithe(funcDelegateService, earnings);

Console.Write($"\nYour tithe amount is: {titheAmount:C}!");
Console.Write($"\n\n\nAnd... That's my time! \n\nThank you for taking time to check out the Action and Func delegates examples!! Adios Amigo!\n\n");
Console.Read();

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
            Console.WriteLine($"Hello, {name}! Welcome to The Maze!");
        };

        actionDelegateService.Greet(userName);
    }

    public static void EventRegistration(ActionDelegateService actionDelegateService, List<string> eventNames, string userName)
    {
        actionDelegateService.EventRegistrationAction = (eventNames, userName) =>
        {
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
                break;
            case 2:

                Console.WriteLine($"Result: {funcDelegateService.Subtract(num1, num2)}");
                break;
            case 3:

                Console.WriteLine($"Result: {funcDelegateService.Multiply(num1, num2)}");
                break;
            case 4:

                Console.WriteLine($"Result: {funcDelegateService.Divide(num1, num2)}");
                break;
            default:

                Console.WriteLine("\nInvalid choice. Please select a valid option (1/2/3/4).\n");
                Console.Read();
                break;
        }

    }

    public static double CalculateTithe(FuncDelegateService funcDelegateService, double earnings)
    {
        // Define the tithe calculation logic using Func delegate
        funcDelegateService.CalculateTitheFunc = (earnings) => earnings * 0.1; // 10% tithe

        double titheAmount = funcDelegateService.CalculateTitheFunc(earnings);

        return titheAmount;
    }

    public static List<string> FilterEvents(FuncDelegateService funcDelegateService, string filterString, List<string> events)
    {
        funcDelegateService.EventFilterFunc = (eventName) => eventName.Contains(filterString);
        Func<string, bool> filterCriteria = (eventName) => eventName.Contains(filterString);
        return funcDelegateService.FilterEvents(filterCriteria, events);

    }

    public static List<string> FilterEventsBySearchText(FuncDelegateService funcDelegateService, string filterString, List<string> events)
    {
        string searchText = filterString;

        // Create a predicate (lambda expression) for case-insensitive comparison
        Predicate<string> filterPredicate = eventName => ContainsCaseInsensitive(eventName, searchText);

        funcDelegateService.EventFilterBySearchTextFunc = filterPredicate;

        //return events.FindAll(filterPredicate);
        return funcDelegateService.FilterEventsBySearchText(filterPredicate, events);
    }

    // Function to get the name of the selected item
    public static string GetSelectedItem(List<string> itemList, int userInput)
    {
        if (userInput > 0 && userInput <= itemList.Count)
        {
            return itemList[userInput - 1];
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(userInput), "Invalid choice");
        }
    }

    public static void PrintFilteredEvents(List<string> filteredEvents)
    {
        Console.Write("\nFiltered events:");

        for (int i = 0; i < filteredEvents.Count; i++)
        {
            string itemName = filteredEvents[i];
            Console.Write($"\n{i + 1}. {itemName}");
        }
    }

    private static bool ContainsCaseInsensitive(string source, string filterString)
    {
        return source.IndexOf(filterString, StringComparison.OrdinalIgnoreCase) >= 0;
    }



    #endregion


}


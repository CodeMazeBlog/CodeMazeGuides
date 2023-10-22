using ActionAndFuncDelegates;

//--------------------------Action delegate section --------------------- 
var recipients = new List<string> { "Alice", "Bob", "Matt" };
string message = "Hello, this is an important update.";

foreach (var recipient in recipients)
{
   new SendNotification().SendNotificationAction(recipient, message);
}


//--------------------------Func delegate section --------------------- 
var numbers = new List<int> { 1, 2, 3, 4, 5 };
List<int> squares = numbers.Select(new SquareCalculator().SquareCalculatorFunc).ToList();

Console.WriteLine("Original numbers: " + string.Join(", ", numbers));
Console.WriteLine("Squared numbers: " + string.Join(", ", squares));
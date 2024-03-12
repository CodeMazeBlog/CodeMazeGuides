// Preview post: https://drafts.code-maze.com/?p=114977&preview=true

Console.WriteLine("********* ACTION DELEGATE *********");
// ---------------- Action delegate ---------------
Action<int> ActionPrintNumber = number => Console.WriteLine($"The number is {number}");

ActionPrintNumber(1000);
// Output: The number is 1000

void Action_NameMethod(int number)
{
    Console.WriteLine($"The number is {number}");
}
Action<int> ActionUsingNameMethod = Action_NameMethod;

Action_NameMethod(1000);
// Output: The number is 1000

Console.WriteLine("");
Console.WriteLine("********* FUNC DELEGATE *********");
// ---------------- Func delegate ---------------
Func<string, string, string> funcFullName = (First, Last) => $"{First} {Last}";

// Func returns value
var Fullname = funcFullName("Bugs", "Bunny");

Console.WriteLine($"Full name is: {Fullname}");
// Output: "Full name is: Bugs Bunny"

string Func_NamedMethod(string First, string Last)
{
    return $"{First} {Last}";
}
Func<string, string, string> funcNamedMethod = Func_NamedMethod;

var Fullname2 = funcNamedMethod("Bugs", "Bunny");

Console.WriteLine("Full name is: " + Fullname2);
// Output: "Full name is: Bugs Bunny"
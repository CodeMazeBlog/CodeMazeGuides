
#region Action Delegates

PrintThis print = delegate(string val)
{
    Console.WriteLine(val);
};

print.Invoke("Anonymous method of Action delegate");

//Action delegate using Lambda expression  
Action<string> printActionDelegate = input => Console.WriteLine(input);
printActionDelegate("Lambda expression way of Action delegate");

//Assigning a method directly
Action<string> printActionDelegate2 = Print;
printActionDelegate2("Print this!");

// Initialize an Action delegate using the new keyword
Action<string> printActionDel = new Action<string>(Print);
printActionDel.Invoke("Invoke action delegate");


DoSomething(Function, "I invoked DoSomething Action Delegate");

//Passing action delegate as a parameter to a method 
static void DoSomething(Action<string> action, string input)
{
    action(input);
}

static void Function(string input)
{
    Console.WriteLine(input);
}

#endregion

#region Func Delegates
//Func delegate with return value full name in caps-lock 
Func<string, string, string> getFullName = FullNameInCapital;

//Calling getFullName delegate and assign the return value to a variable
string fullNameInCaps = getFullName("john", "doe");
Console.WriteLine(fullNameInCaps);

static void Print(string input)
{
    Console.WriteLine(input);
}

static string FullNameInCapital(string firstName, string lastName)
{
    return (firstName+ " " + lastName).ToUpper();
}

User[] users =
{
    new(1, "Peter", "UK"), 
    new(2, "John", "USA"), 
    new(3, "Mark", "KSA"), 
    new(4, "Pal", "UAE"),
};

//From the array of users, we are going to filter who are living in USA.
var country = "USA";
Func<User, bool> livesIn = e => e.Country == country;

//Iterate through user list and return the user object of
//whose country attribute is equal to the 'country' variable.
var result = users.Where(livesIn);

foreach (var user in result)
{
    Console.WriteLine($"User Id : {user.Id}");
    Console.WriteLine($"User Name : {user.Name}");
}

internal record User(int Id, string Name, string Country);

#endregion

#region Declraing an Action delegate

//Action delegate with string input parameter 
delegate void PrintThis(string value);

#endregion




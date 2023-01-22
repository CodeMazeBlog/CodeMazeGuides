
//Action delegate
var printFullName = PrintFullName;  
printFullName("John", "Doe");

//Func delegate
var buildFullName = BuildFullName;
var result = buildFullName("John", "Doe");
Console.WriteLine($"Triggered by Func delegate {result}");

static string BuildFullName(string firstName, string lastName)
{
    return $"{firstName} {lastName}";
}

static void PrintFullName(string firstName, string lastName)
{
    Console.WriteLine($"Triggered by Action delegate {firstName} {lastName}");
}

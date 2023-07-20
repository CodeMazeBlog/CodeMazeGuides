
// Action delegate example
static void PrintFullName (string gender, string firstName, string lastName)
{
    Console.WriteLine("Full Name is : {0} {1} {2}", gender, firstName, lastName);
}


Action<string, string, string> actPrintName = PrintFullName;
actPrintName("Mr.", "Deepak", "Jain");


// Func delegate example
static int GetSum (int x, int y)
{
    return (x + y);
}



Func<int, int, int> funcSum = GetSum;
int output = funcSum(10, 20);
Console.WriteLine("Sum of 10 and 20 is : {0}", output);



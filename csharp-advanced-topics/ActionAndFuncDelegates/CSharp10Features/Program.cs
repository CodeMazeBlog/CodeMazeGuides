//Declaring and assigning Action and Func variables before C# 10
Action<int> exceptionAction1 = ThrowNumberShouldBeOddException;
Func<int, bool> validateFunc1 = IsOdd;

//Since C# 10 the var keyword can be used as well
var exceptionAction2 = ThrowNumberShouldBeOddException;
var validateFunc2 = IsOdd;

Console.WriteLine($"Type of {nameof(exceptionAction2)} is {exceptionAction2.GetType()}");
Console.WriteLine($"Type of {nameof(validateFunc2)} is {validateFunc2.GetType()}");

//Declaring Action and Func variables before C# 10
/// <summary>
/// Checks if a number is odd
/// </summary>
bool IsOdd(int number)
{
    return number % 2 != 0;
}

/// <summary>
/// Throws exception with odd logic related message
/// </summary>
void ThrowNumberShouldBeOddException(int number)
{
    throw new Exception($"Provided number {number} is not odd");
}

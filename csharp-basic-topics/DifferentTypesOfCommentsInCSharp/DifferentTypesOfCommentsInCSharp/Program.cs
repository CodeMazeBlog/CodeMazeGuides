using DifferentTypesOfCommentsInCSharp;

for (int number = 0; number <= 15; number++)
{
    var result = SingleLineComments.Factorial(number);
    Console.WriteLine($"Factorial of {number,3} is {result,14}");
}
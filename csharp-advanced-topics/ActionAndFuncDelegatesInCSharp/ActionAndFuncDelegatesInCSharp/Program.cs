// Using Action with no parameters
Action displayMessage = () => Console.WriteLine("Hello, C#!");

// Using Action with two parameters
Action<int, int> displaySum = (a, b) => Console.WriteLine($"The sum is: {a + b}");

displayMessage();  // Outputs: Hello, C#!
displaySum(3, 4);  // Outputs: The sum is: 7

// Using Func with no input but a return type
Func<int> getRandomNumber = () => new Random().Next(1, 100);

// Using Func with two input parameters and a return type
Func<int, int, int> findMax = (a, b) => a > b ? a : b;

Console.WriteLine(getRandomNumber());  // Outputs a random number between 1 and 99
Console.WriteLine(findMax(5, 8));      // Outputs: 8

// LINQ example
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Func<int, bool> isEven = n => n % 2 == 0;

var evenNumbers = numbers.Where(isEven).ToList();
Console.WriteLine(string.Join(", ", evenNumbers));  // Outputs: 2, 4

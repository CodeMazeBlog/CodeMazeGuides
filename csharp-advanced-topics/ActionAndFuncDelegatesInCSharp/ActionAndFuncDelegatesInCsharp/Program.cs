using System;

Action helloWorldDelegate = () => Console.Write("Hello, World!");
helloWorldDelegate(); // Output: "Hello, World!"

//👇 First and second arguments are integers
Action<int, int> WriteSumOfDelegate = (operator1, operator2) =>
{
    Console.Write("Sum of {0} and {1} is {2}", operator1, operator2, operator1 + operator2);
};

WriteSumOfDelegate(10, 20); //Output: "Sum of 10 and 20 is 30"

Func<int, int> DoubleItDelegate = (operator1) =>
{
    return operator1 * 2;
};
var result = DoubleItDelegate(2); //returns 4

Console.WriteLine("Func Double result {0}", result); //Output: "Func Double result 4"


Console.WriteLine("Press any key to exit");
Console.ReadKey();
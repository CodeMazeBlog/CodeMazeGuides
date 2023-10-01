// Create a new Calculator object.
var calculator = new Calculator();

// Subscribe to the OnAddIntegers event.
calculator.OnAddIntegers += (a, b) =>
{
// Do something with the result of adding the two integers.
Console.WriteLine($"The sum of {a} and {b} is {a + b}.");

return 0; // Return a dummy value.
};

// Add two integers.
var sum = calculator.AddIntegers(10, 20);
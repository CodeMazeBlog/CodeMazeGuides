using System;

public class Class1
{
	public Class1()
	{
        // Define a Func delegate that takes an int and returns a string
        Func<int, string> doubleToString = x =>
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"The double is: {x * 2}");
            return sb.ToString(); // Return the formatted string instead of printing it
        };

        // Invoke the Func delegate and store the result
        string result = doubleToString(5);
        // Use the result later as needed...

        // Data transformation example
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        List<string> doubledNumbers = numbers.Select(x =>
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(x * 2);
            return sb.ToString(); // Return the formatted string for each element
        }).ToList();

        // Function composition example
        Func<int, int> square = x => x * x;
        Func<int, string> squareAndFormat = square.Compose(x =>
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"The square is: {x}");
            return sb.ToString(); // Return the formatted string with the square value
        });

        string formattedSquare = squareAndFormat(5);
        // Use the formatted square value later as needed...



    }
}

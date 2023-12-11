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
            return sb.ToString(); 
        };

        string result = doubleToString(5);

        // Data transformation example
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        List<string> doubledNumbers = numbers.Select(x =>
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(x * 2);
            return sb.ToString(); 
        }).ToList();

        // Function composition example
        Func<int, int> square = x => x * x;
        Func<int, string> squareAndFormat = square.Compose(x =>
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"The square is: {x}");
            return sb.ToString(); 
        });

        string formattedSquare = squareAndFormat(5);



    }
}

public class FuncDelegate
{
    public void PerformFiltration(IEnumerable<int> numbers)
    {
        //Func delegate for filtering even numbers
        Func<int, int, bool> isEven = (x, y) => x % 2 == 0;

        //Use the Func delegate in a LINQ query
        var evenNumbers = numbers.Where(isEven);

        Console.WriteLine("Even number: ");
        foreach (var number in evenNumbers)
        {
            Console.WriteLine($"{number} ");
        }
    }
}



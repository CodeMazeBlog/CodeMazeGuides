public class FuncDelegate
{
    public IEnumerable<int> PerformFiltration(IEnumerable<int> numbers)
    {
        //Func delegate for filtering even numbers
        Func<int, bool> isEven = (x) => x % 2 == 0;

        //Use the Func delegate in a LINQ query
        var evenNumbers = numbers.Where(isEven);

        return evenNumbers;
    }
}
namespace FuncActionDelegate
{
    public class FuncSample
    {
        public int FilterAndSum(List<int> numbers)
        {
            // Define a Func delegate to filter numbers (e.g., keep only even numbers)
            Func<int, bool> isEven = n => n % 2 == 0;

            // Use LINQ to filter and sum the even numbers
            int sumOfEvens = numbers.Where(isEven).Sum();
            return sumOfEvens;
        }
    }
}



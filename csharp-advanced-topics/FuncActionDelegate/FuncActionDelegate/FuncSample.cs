namespace FuncActionDelegate
{
    public class FuncSample
    {
        public int FilterAndSum(List<int> numbers)
        {
            
            Func<int, bool> isEven = n => n % 2 == 0;

            var  sumOfEvens = numbers.Where(isEven).Sum();

            return sumOfEvens;
        }
    }
}



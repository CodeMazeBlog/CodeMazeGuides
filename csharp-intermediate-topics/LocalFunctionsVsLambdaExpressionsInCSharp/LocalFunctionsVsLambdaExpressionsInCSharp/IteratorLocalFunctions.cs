namespace LocalFunctionsVsLambdaExpressionsInCSharp;

public class IteratorLocalFunctions
{
    public static IEnumerable<int> IntegersToAbsoluteValue(IEnumerable<int> input)
    {
        return AbsoluteValueIterator();

        IEnumerable<int> AbsoluteValueIterator()
        {
            foreach (var number in input)
            {
                yield return Math.Abs(number);
            }
        }
    }
}

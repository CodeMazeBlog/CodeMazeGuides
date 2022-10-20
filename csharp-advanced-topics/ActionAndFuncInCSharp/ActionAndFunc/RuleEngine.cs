using System.Collections.ObjectModel;

namespace ActionAndFunc;

public class RuleEngine
{
    public readonly IDictionary<string, Func<int, bool>> Rules = new Dictionary<string, Func<int, bool>>();

    public RuleEngine()
    {
        Rules.Add("PositiveNumber", IsPositiveNumber);
        Rules.Add("NegativeNumber", IsNegativeNumber);
        Rules.Add("IsNumberZero", IsEqualToZero);
    }

    private bool IsPositiveNumber(int number)
    {
        return number > 0;
    }
    
    private bool IsNegativeNumber(int number)
    {
        return number < 0;
    }
    
    private bool IsEqualToZero(int number)
    {
        return number == 0;
    }
}
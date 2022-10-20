using System.Collections.ObjectModel;

namespace ActionAndFunc;

public class RuleEngine
{
    private readonly IDictionary<string, Func<int, bool>> Rules = new Dictionary<string, Func<int, bool>>();

    public RuleEngine()
    {
        Rules.Add("Positive", IsPositiveNumber);
        Rules.Add("Negative", IsNegativeNumber);
        Rules.Add("Zero", IsEqualToZero);
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

    public List<string> ExecuteRules(int number)
    {
        var errors = new List<string>();

        foreach (var rule in Rules)
        {
            if (!rule.Value(number))
            {
                errors.Add($"Given number is not {rule.Key}");
            }
        }
        return errors;
    }
}
namespace ActionAndFuncDelegatesInCSharp
{
    public class RuleEngine
    {
        private readonly Dictionary<string, Func<int, bool>> _rules = new();

        public RuleEngine()
        {
            _rules.Add("Positive", IsPositiveNumber);
            _rules.Add("Negative", IsNegativeNumber);
            _rules.Add("Zero", IsEqualToZero);
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
            var validationResults = new List<string>();

            foreach (var rule in _rules)
            {
                if (!rule.Value(number))
                {
                    validationResults.Add($"Given number is not {rule.Key}");
                }
            }
            return validationResults;
        }
    }

}

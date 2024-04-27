using CompareTwoDictionaries;

namespace Tests;

public class DictionaryComparisonFalseTest
{
    private static readonly Dictionary<int, string> _dict1
         = new()
         {
            {1, "Rosary Ogechi"},
            {2, "Clare Chiamaka"},
         };

    private static readonly Dictionary<int, string> _dict2
        = new()
        {
            {1, "Clare Chiamaka"},
            {2, "Rosary Ogechi"},
        };

    private readonly DictionaryComparisonHelper _comparer = new(_dict1, _dict2);

    [Fact]
    public void WhenUseSequenceEqualsIsCalledWithUnEqualDictionaries_ThenReturnsFalse()
    {
        Assert.False(_comparer.UseSequenceEqual());
    }

    [Fact]
    public void WhenUseEnumerableAllIsCalledWithUnEqualDictionaries_ThenReturnsFalse()
    {
        Assert.False(_comparer.UseEnumerableAll());
    }

    [Fact]
    public void WhenUseForeachLoopIsCalledWithUnEqualDictionaries_ThenReturnsFalse()
    {
        Assert.False(_comparer.UseForeachLoop());
    }
}
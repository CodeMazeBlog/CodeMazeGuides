using CompareTwoDictionaries;

namespace Tests;

public class CompareTwoDictionaryTest
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
            {1, "Rosary Ogechi"},
            {2, "Clare Chiamaka"},
         };

    private readonly DictionaryComparisonHelper _comparer = new(_dict1, _dict2);

    [Fact]
    public void WhenUseSequenceEqualsIsCalledWithEqualDictionaries_ThenReturnsTrue()
    {
        Assert.True(_comparer.UseSequenceEqual());
    }

    [Fact]
    public void WhenUseEnumerableAllIsCalledWithEqualDictionaries_ThenReturnsTrue()
    {
        Assert.True(_comparer.UseEnumerableAll());
    }

    [Fact]
    public void WhenUseForeachLoopIsCalledWithEqualDictionaries_ThenReturnsTrue()
    {
        Assert.True(_comparer.UseForeachLoop());
    }
}
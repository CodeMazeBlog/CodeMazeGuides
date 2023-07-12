using static MergingDictionariesInCSharp.Methods;

[TestFixture]
public class MergingMethodsTests
{
    private Dictionary<int, string> _dictionaryA;
    private Dictionary<int, string> _dictionaryB;

    [SetUp]
    public void SetUp()
    {
        _dictionaryA = new Dictionary<int, string>()
        {
            { 1, "Apple" },
            { 2, "Banana" },
            { 3, "Orange" }
        };

        _dictionaryB = new Dictionary<int, string>()
        {
            { 4, "Grapes" },
            { 5, "Watermelon" },
            { 6, "Pineapple" }
        };
    }

    [Test]
    public void ConcatMethod_ShouldMergeDictionaries()
    {
        Dictionary<int, string> mergedDictionary = ConcatMethod(_dictionaryA, _dictionaryB);

        Dictionary<int, string> expectedDictionary = GetExpectedDictionary();

        CollectionAssert.AreEqual(expectedDictionary, mergedDictionary);
    }

    [Test]
    public void ForEachMethod_ShouldMergeDictionaries()
    {
        Dictionary<int, string> mergedDictionary = ForEachMethod(_dictionaryA, _dictionaryB);

        Dictionary<int, string> expectedDictionary = GetExpectedDictionary();

        CollectionAssert.AreEqual(expectedDictionary, mergedDictionary);
    }

    [Test]
    public void GroupByMethod_ShouldMergeDictionaries()
    {
        Dictionary<int, string> mergedDictionary = GroupByMethod(_dictionaryA, _dictionaryB);

        Dictionary<int, string> expectedDictionary = GetExpectedDictionary();

        CollectionAssert.AreEqual(expectedDictionary, mergedDictionary);
    }

    [Test]
    public void LookupMethod_ShouldMergeDictionaries()
    {
        Dictionary<int, string> mergedDictionary = LookupMethod(_dictionaryA, _dictionaryB);

        Dictionary<int, string> expectedDictionary = GetExpectedDictionary();

        CollectionAssert.AreEqual(expectedDictionary, mergedDictionary);
    }

    [Test]
    public void UnionMethod_ShouldMergeDictionaries()
    {
        Dictionary<int, string> mergedDictionary = UnionMethod(_dictionaryA, _dictionaryB);

        Dictionary<int, string> expectedDictionary = GetExpectedDictionary();

        CollectionAssert.AreEqual(expectedDictionary, mergedDictionary);
    }

    [Test]
    public void HashSetMethod_ShouldMergeDictionaries()
    {
        Dictionary<int, string> mergedDictionary = UsingHashSetMethod(_dictionaryA, _dictionaryB);

        Dictionary<int, string> expectedDictionary = GetExpectedDictionary();

        CollectionAssert.AreEqual(expectedDictionary, mergedDictionary);
    }

    private Dictionary<int, string> GetExpectedDictionary()
    {
        return new Dictionary<int, string>()
        {
            { 1, "Apple" },
            { 2, "Banana" },
            { 3, "Orange" },
            { 4, "Grapes" },
            { 5, "Watermelon" },
            { 6, "Pineapple" }
        };
    }
}
using static MergingDictionariesInCSharp.Methods;

[TestFixture]
public class MergingMethodsTests
{
    private Dictionary<int, string> _dictionaryA;
    private Dictionary<int, string> _dictionaryB;
    private Dictionary<int, string> _expectedMergedDictionary;

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

        _expectedMergedDictionary = new Dictionary<int, string>()
        {
            { 1, "Apple" },
            { 2, "Banana" },
            { 3, "Orange" },
            { 4, "Grapes" },
            { 5, "Watermelon" },
            { 6, "Pineapple" }
        };
    }

    [Test]
    public void ConcatMethod_ShouldMergeDictionaries()
    {
        var mergedDictionary = ConcatMethod(_dictionaryA, _dictionaryB);

        CollectionAssert.AreEqual(_expectedMergedDictionary, mergedDictionary);
    }

    [Test]
    public void ForEachMethod_ShouldMergeDictionaries()
    {
        var mergedDictionary = ForEachMethod(_dictionaryA, _dictionaryB);

        CollectionAssert.AreEqual(_expectedMergedDictionary, mergedDictionary);
    }

    [Test]
    public void GroupByMethod_ShouldMergeDictionaries()
    {
        var mergedDictionary = GroupByMethod(_dictionaryA, _dictionaryB);

        CollectionAssert.AreEqual(_expectedMergedDictionary, mergedDictionary);
    }

    [Test]
    public void LookupMethod_ShouldMergeDictionaries()
    {
        var mergedDictionary = LookupMethod(_dictionaryA, _dictionaryB);

        CollectionAssert.AreEqual(_expectedMergedDictionary, mergedDictionary);
    }

    [Test]
    public void UnionMethod_ShouldMergeDictionaries()
    {
        var mergedDictionary = UnionMethod(_dictionaryA, _dictionaryB);

        CollectionAssert.AreEqual(_expectedMergedDictionary, mergedDictionary);
    }

    [Test]
    public void HashSetMethod_ShouldMergeDictionaries()
    {
        var mergedDictionary = UsingListsMethod(_dictionaryA, _dictionaryB);

        CollectionAssert.AreEqual(_expectedMergedDictionary, mergedDictionary);
    }

    [Test]
    public void ConcatMethod_WhenDictionariesWithDublicateKeys_ThenException()
    {
        Assert.Throws<ArgumentException>(() => ConcatMethod(_dictionaryA, _dictionaryA));
    }

    [Test]
    public void UnionMethod_WhenDictionariesWithDublicateKeys_ThenException()
    {
        Assert.Throws<ArgumentException>(() => UnionMethod(_dictionaryA, new Dictionary<int, string>()
            {
                {1, "Watermelon" } 
                //key:1 already exists in _dictionaryA,
                //but UnionMethod needs different key value pair to throw exception.
            })
        );
    }

    [Test]
    public void UsingListsMethod_WhenDictionariesWithDublicateKeys_ThenException()
    {
        Assert.Throws<ArgumentException>(() => UsingListsMethod(_dictionaryA, _dictionaryA));
    }
}
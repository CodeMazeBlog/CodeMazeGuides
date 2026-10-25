using static MergingDictionariesInCSharp.Methods;

[TestFixture]
public class MergingMethodsTests
{
    private Dictionary<int, string> _dictionaryA = [];
    private Dictionary<int, string> _dictionaryB = [];
    private Dictionary<int, string> _expectedMergedDictionary = [];
    private Dictionary<int, string> _clashingDictionary = [];

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

        // key 1 already exists in _dictionaryA, with a different value
        _clashingDictionary = new Dictionary<int, string>()
        {
            { 1, "Watermelon" }
        };
    }

    [Test]
    public void GivenConcatMethod_WhenDictionaryAB_ThenExpectedDictionary()
    {
        var mergedDictionary = ConcatMethod(_dictionaryA, _dictionaryB);

        Assert.That(mergedDictionary, Is.EqualTo(_expectedMergedDictionary));
    }

    [Test]
    public void GivenForEachMethod_WhenDictionaryAB_ThenExpectedDictionary()
    {
        var mergedDictionary = ForEachMethod(_dictionaryA, _dictionaryB);

        Assert.That(mergedDictionary, Is.EqualTo(_expectedMergedDictionary));
    }

    [Test]
    public void GivenGroupByMethod_WhenDictionaryAB_ThenExpectedDictionary()
    {
        var mergedDictionary = GroupByMethod(_dictionaryA, _dictionaryB);

        Assert.That(mergedDictionary, Is.EqualTo(_expectedMergedDictionary));
    }

    [Test]
    public void GivenToLookupMethod_WhenDictionaryAB_ThenExpectedDictionary()
    {
        var mergedDictionary = LookupMethod(_dictionaryA, _dictionaryB);

        Assert.That(mergedDictionary, Is.EqualTo(_expectedMergedDictionary));
    }

    [Test]
    public void GivenUnionMethod_WhenDictionaryAB_ThenExpectedDictionary()
    {
        var mergedDictionary = UnionMethod(_dictionaryA, _dictionaryB);

        Assert.That(mergedDictionary, Is.EqualTo(_expectedMergedDictionary));
    }

    [Test]
    public void GivenListsMethod_WhenDictionaryAB_ThenExpectedDictionary()
    {
        var mergedDictionary = UsingListsMethod(_dictionaryA, _dictionaryB);

        Assert.That(mergedDictionary, Is.EqualTo(_expectedMergedDictionary));
    }

    [Test]
    public void GivenConcatMethod_WhenDictionariesWithDuplicateKeys_ThenException()
    {
        Assert.Throws<ArgumentException>(() => ConcatMethod(_dictionaryA, _dictionaryA));
    }

    [Test]
    public void GivenUnionMethod_WhenDictionariesWithDuplicateKeys_ThenException()
    {
        Assert.Throws<ArgumentException>(() => UnionMethod(_dictionaryA, _clashingDictionary));
    }

    [Test]
    public void GivenUnionMethod_WhenSameKeyWithSameValue_ThenNoException()
    {
        var mergedDictionary = UnionMethod(_dictionaryA, _dictionaryA);

        Assert.That(mergedDictionary, Is.EqualTo(_dictionaryA));
    }

    [Test]
    public void GivenListsMethod_WhenDictionariesWithDuplicateKeys_ThenException()
    {
        Assert.Throws<ArgumentException>(() => UsingListsMethod(_dictionaryA, _dictionaryA));
    }

    [Test]
    public void GivenForEachMethod_WhenDictionariesWithDuplicateKeys_ThenFirstValueKept()
    {
        var mergedDictionary = ForEachMethod(_dictionaryA, _clashingDictionary);

        Assert.That(mergedDictionary[1], Is.EqualTo("Apple"));
    }

    [Test]
    public void GivenGroupByMethod_WhenDictionariesWithDuplicateKeys_ThenFirstValueKept()
    {
        var mergedDictionary = GroupByMethod(_dictionaryA, _clashingDictionary);

        Assert.That(mergedDictionary[1], Is.EqualTo("Apple"));
    }

    [Test]
    public void GivenToLookupMethod_WhenDictionariesWithDuplicateKeys_ThenFirstValueKept()
    {
        var mergedDictionary = LookupMethod(_dictionaryA, _clashingDictionary);

        Assert.That(mergedDictionary[1], Is.EqualTo("Apple"));
    }
}

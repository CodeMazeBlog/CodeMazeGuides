using SortedSetInCSharp;

namespace SortedSetInCSharpTests;

[TestClass]
public class SortedSetInCSharpUnitTests
{
    private readonly SortedSetMethods _sortedSet;
    private readonly SortedSet<string> _languages;

    public SortedSetInCSharpUnitTests()
    {
        _sortedSet = new SortedSetMethods();
        _languages = _sortedSet.ProgrammingLanguages();
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyCountAndContains()
    {
        Assert.IsInstanceOfType(_languages, typeof(SortedSet<string>));
        Assert.AreEqual(9, _languages.Count);
        Assert.IsTrue(_languages.Contains("Java"));
        Assert.AreEqual("C", _languages.First());
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyHasNoDuplicates()
    {
        _languages.Add("C");
        _languages.Add("C++");
        _languages.Add("C#");

        Assert.IsInstanceOfType(_languages, typeof(SortedSet<string>));
        Assert.AreEqual(9, _languages.Count);
    }

    [TestMethod]
    public void GivenASortedSet_WhenAddingADuplicate_ThenAddReturnsFalse()
    {
        Assert.IsFalse(_languages.Add("Java"));
        Assert.IsTrue(_languages.Add("Go"));
    }

    [TestMethod]
    public void GivenASortedSetOfStrings_WhenAddingNull_ThenNullIsTheFirstElement()
    {
        SortedSet<string?> languages = new(_languages);

        Assert.IsTrue(languages.Add(null));
        Assert.IsFalse(languages.Add(null));
        Assert.AreEqual(10, languages.Count);
        Assert.IsNull(languages.Min);
    }

    [TestMethod]
    public void GivenAComparerByYear_WhenTwoLanguagesShareAYear_ThenTheSecondIsDropped()
    {
        var byYear = Comparer<(string Name, int Year)>.Create(
            (x, y) => x.Year.CompareTo(y.Year));

        var languages = new SortedSet<(string Name, int Year)>(byYear)
        {
            ("Python", 1991), ("Java", 1995), ("C", 1972), ("JavaScript", 1995)
        };

        Assert.AreEqual(3, languages.Count);
        Assert.AreEqual(("C", 1972), languages.Min);
        Assert.IsFalse(languages.Any(l => l.Name == "JavaScript"));
    }

    [TestMethod]
    public void GivenAComparerByYearThenName_WhenTwoLanguagesShareAYear_ThenBothAreKept()
    {
        var byYearThenName = Comparer<(string Name, int Year)>.Create(
            (x, y) => x.Year != y.Year
                ? x.Year.CompareTo(y.Year)
                : string.CompareOrdinal(x.Name, y.Name));

        var languages = new SortedSet<(string Name, int Year)>(byYearThenName)
        {
            ("Python", 1991), ("Java", 1995), ("C", 1972), ("JavaScript", 1995)
        };

        Assert.AreEqual(4, languages.Count);
        Assert.AreEqual(("JavaScript", 1995), languages.Max);
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyMinAndMax()
    {
        Assert.AreEqual("C", _languages.Min);
        Assert.AreEqual("TypeScript", _languages.Max);
    }

    [TestMethod]
    public void GivenASortedSet_WhenGettingAViewBetweenTwoValues_ThenTheViewTracksTheSet()
    {
        var view = _languages.GetViewBetween("C", "Java");

        CollectionAssert.AreEqual(new[] { "C", "C#", "C++", "Java" }, view.ToArray());

        _languages.Add("Go");
        view.Add("F#");

        CollectionAssert.AreEqual(new[] { "C", "C#", "C++", "F#", "Go", "Java" }, view.ToArray());
        Assert.IsTrue(_languages.Contains("F#"));
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => view.Add("Rust"));
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyOverlapsSuccessful()
    {
        var commonLanguages = new SortedSet<string> { "C", "C++", "C#", "Java", "Scala", "TypeScript", "Python", "JavaScript", "Rust", "Assembly", "Pascal" };
        var differentLanguages = new SortedSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

        Assert.IsTrue(commonLanguages.Overlaps(_languages));
        Assert.IsTrue(differentLanguages.Overlaps(commonLanguages));
        Assert.IsFalse(differentLanguages.Overlaps(_languages));
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyAnElementRemoved()
    {
        var elementToRemove = "Java";

        var updatedLanguages = _sortedSet.RemoveElement(_languages, elementToRemove);

        Assert.IsFalse(updatedLanguages.Contains(elementToRemove));
        Assert.AreEqual(8, _languages.Count);
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyRemoveWhereWorks()
    {
        _languages.RemoveWhere(element => element.StartsWith("C"));

        Assert.IsFalse(_languages.Contains("C"));
        Assert.IsFalse(_languages.Contains("C++"));
        Assert.IsFalse(_languages.Contains("C#"));
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyElementsReversed()
    {
        var reversedSet = _languages.Reverse();
        var firstElement = reversedSet.First();
        var lastElement = reversedSet.Last();

        Assert.IsInstanceOfType(reversedSet, typeof(IEnumerable<string>));
        Assert.AreEqual("TypeScript", firstElement);
        Assert.AreEqual("C", lastElement);
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyAllElementsCleared()
    {
        _languages.Clear();

        Assert.AreEqual(0, _languages.Count);
        Assert.IsNull(_languages.FirstOrDefault());
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyAllElementsCopied()
    {
        var languagesArray = new string[9];

        _languages.CopyTo(languagesArray);

        Assert.AreEqual(9, languagesArray.Length);
        Assert.AreEqual("C", languagesArray[0]);
        Assert.AreEqual("TypeScript", languagesArray[8]);
        Assert.IsNotNull(languagesArray);
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyProperSubset()
    {
        var moreLanguages = new SortedSet<string> { "C", "C++", "C#", "Java", "Scala", "TypeScript", "Python", "JavaScript", "Rust", "Assembly", "Pascal" };

        Assert.IsTrue(_languages.IsSubsetOf(moreLanguages));
        Assert.IsTrue(_languages.IsProperSubsetOf(moreLanguages));
        Assert.IsTrue(moreLanguages.IsSupersetOf(_languages));
        Assert.IsTrue(moreLanguages.IsProperSupersetOf(_languages));
    }

    [TestMethod]
    public void GivenTwoEqualSets_WhenCheckingSubsets_ThenOnlyTheNonProperChecksPass()
    {
        var sameLanguages = new SortedSet<string>(_languages);

        Assert.IsTrue(_languages.IsSubsetOf(sameLanguages));
        Assert.IsFalse(_languages.IsProperSubsetOf(sameLanguages));
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyUnionWithSuccessful()
    {
        var moreLanguages = new SortedSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

        _languages.UnionWith(moreLanguages);

        Assert.AreEqual(14, _languages.Count);
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifyIntersectWithSuccessful()
    {
        var moreLanguages = new SortedSet<string> { "C", "C++", "C#", "Java", "Scala", "Assembly", "Pascal", "HTML", "CSS", "PHP" };

        _languages.IntersectWith(moreLanguages);

        Assert.AreEqual(5, _languages.Count);
        Assert.IsTrue(_languages.Contains("C"));
        Assert.IsTrue(_languages.Contains("C++"));
        Assert.IsTrue(_languages.Contains("C#"));
        Assert.IsTrue(_languages.Contains("Java"));
        Assert.IsTrue(_languages.Contains("Scala"));
        Assert.IsFalse(_languages.Contains("Assembly"));
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_ExceptWithSuccessful()
    {
        var moreLanguages = new SortedSet<string> { "C", "C++", "C#", "Java", "Scala", "Assembly", "Pascal", "HTML", "CSS", "PHP" };

        _languages.ExceptWith(moreLanguages);

        Assert.AreEqual(4, _languages.Count);
        Assert.IsTrue(_languages.Contains("TypeScript"));
        Assert.IsTrue(_languages.Contains("Python"));
        Assert.IsTrue(_languages.Contains("JavaScript"));
        Assert.IsTrue(_languages.Contains("Rust"));
        Assert.IsFalse(_languages.Contains("Assembly"));
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifySetEqualsSuccessful()
    {
        var moreLanguages = new SortedSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };
        var sameLanguagesInAList = new List<string>
        {
            "Rust", "Java", "C", "C#", "C++", "Scala", "TypeScript", "Python", "JavaScript", "Java"
        };

        Assert.IsFalse(_languages.SetEquals(moreLanguages));
        Assert.IsTrue(_languages.SetEquals(sameLanguagesInAList));
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_VerifySymmetricExceptWithSuccessful()
    {
        var moreLanguages = new SortedSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

        _languages.SymmetricExceptWith(moreLanguages);

        Assert.AreEqual(14, _languages.Count);
    }

    [TestMethod]
    public void GivenASortedSet_WhenNotEmpty_TryToGetValue()
    {
        Assert.IsTrue(_languages.TryGetValue("C#", out var found));
        Assert.AreEqual("C#", found);
        Assert.IsTrue(_languages.Contains("C#"));
        Assert.IsFalse(_languages.TryGetValue("Assembly", out _));
        Assert.IsFalse(_languages.Contains("Assembly"));
    }
}

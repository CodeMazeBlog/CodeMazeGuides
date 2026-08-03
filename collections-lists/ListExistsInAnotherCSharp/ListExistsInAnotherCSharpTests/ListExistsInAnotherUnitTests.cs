namespace ListExistsInAnotherCSharpTests;

[TestClass]
public class ListExistsInAnotherUnitTests
{
    private readonly CompareListsMethods _compareListsMethods = new();
    private readonly List<int> _firstList;
    private readonly List<int> _secondList;
    private readonly List<int> _thirdList;
    private readonly string _listName;
    private readonly List<Student> _artStudents;
    private readonly List<Student> _scienceStudents;
    private readonly List<Student> _businessStudents;

    public ListExistsInAnotherUnitTests()
    {
        _firstList = new List<int> { 0, 1, 2, 3, 4 };
        _secondList = new List<int> { 5, 6, 7, 8, 9 };
        _thirdList = new List<int> { 0, 1, 2, 3, 5 };
        _listName = string.Empty;
        _artStudents = new List<Student>
        {
            new() { Id = 1, FirstName = "John", LastName = "Doe" },
            new() { Id = 2, FirstName = "Alice", LastName = "Lee" },
            new() { Id = 3, FirstName = "Christopher", LastName = "Davis" },
            new() { Id = 4, FirstName = "Sophia", LastName = "Martinez" },
            new() { Id = 5, FirstName = "Liam", LastName = "Thompson" },
            new() { Id = 6, FirstName = "Olivia", LastName = "Anderson" },
            new() { Id = 7, FirstName = "Emily", LastName = "Johnson"}
        };
        _businessStudents = new() 
        { 
            new Student { Id = 1, FirstName = "Noah", LastName = "Garcia" },
            new Student { Id = 2, FirstName = "Isabella", LastName = "Taylor" },
            new Student { Id = 3, FirstName = "Mason", LastName = "Robinson" },
            new Student { Id = 4, FirstName = "Mia", LastName = "Smith" },
            new Student { Id = 5, FirstName = "Sophia", LastName = "Martinez" },
            new Student { Id = 6, FirstName = "Jacob", LastName = "Hernandez" },
            new Student { Id = 7, FirstName = "Harper", LastName = "White" },
            new Student { Id = 8, FirstName = "Aiden", LastName = "Brown" } 
        };
        _scienceStudents = new() 
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe" },
            new Student { Id = 2, FirstName = "Alice", LastName = "Lee" },
            new Student { Id = 3, FirstName = "Ethan", LastName = "Wilson" },
            new Student { Id = 4, FirstName = "Christopher", LastName = "Davis" },
            new Student { Id = 5, FirstName = "Liam", LastName = "Thompson" },
            new Student { Id = 6, FirstName = "Olivia", LastName = "Anderson" },
            new Student { Id = 7, FirstName = "Ava", LastName = "Miller" } 
        };
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingIntersect_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingIntersect(_firstList, _thirdList, _listName));
        Assert.IsFalse(_compareListsMethods.CompareListUsingIntersect(_firstList, _secondList, _listName));
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingIteration_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingIteration(_firstList, _thirdList, _listName));
        Assert.IsFalse(_compareListsMethods.CompareListUsingIteration(_firstList, _secondList, _listName));
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingAnyContains_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingAnyContains(_firstList, _thirdList, _listName));
        Assert.IsFalse(_compareListsMethods.CompareListUsingAnyContains(_firstList, _secondList, _listName));
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingExcept_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingExcept(_firstList, _thirdList, _listName));
        Assert.IsFalse(_compareListsMethods.CompareListUsingExcept(_firstList, _secondList, _listName));
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingWhereAny_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingWhereAny(_firstList, _thirdList, _listName));
        Assert.IsFalse(_compareListsMethods.CompareListUsingWhereAny(_firstList, _secondList, _listName));
    }

    [TestMethod]
    public void GivenTwoStudentLists_WhenComparedUsingIntersect_ValidateCorrectResults()
    {
        Assert.IsTrue(CompareStudentsExamples.CompareStudentsUsingIntersect(_artStudents, _scienceStudents));
        Assert.IsFalse(CompareStudentsExamples.CompareStudentsUsingIntersect(_scienceStudents, _businessStudents));
    }

    [TestMethod]
    public void GivenTwoStudentLists_WhenComparedUsingIteration_ValidateCorrectResults()
    {
        Assert.IsTrue(CompareStudentsExamples.CompareStudentsUsingIteration(_artStudents, _scienceStudents));
        Assert.IsFalse(CompareStudentsExamples.CompareStudentsUsingIteration(_scienceStudents, _businessStudents));
    }

    [TestMethod]
    public void GivenTwoStudentLists_WhenComparedUsingAnyContains_ValidateCorrectResults()
    {
        Assert.IsTrue(CompareStudentsExamples.CompareStudentsUsingAnyContains(_artStudents, _scienceStudents));
        Assert.IsFalse(CompareStudentsExamples.CompareStudentsUsingAnyContains(_scienceStudents, _businessStudents));
    }

    [TestMethod]
    public void GivenTwoStudentLists_WhenComparedUsingExcept_ValidateCorrectResults()
    {
        Assert.IsTrue(CompareStudentsExamples.CompareStudentsUsingExcept(_artStudents, _scienceStudents));
        Assert.IsFalse(CompareStudentsExamples.CompareStudentsUsingExcept(_scienceStudents, _businessStudents));
    }

    [TestMethod]
    public void GivenTwoStudentLists_WhenComparedUsingWhereAny_ValidateCorrectResults()
    {
        Assert.IsTrue(CompareStudentsExamples.CompareStudentsUsingWhereAny(_artStudents, _scienceStudents));
        Assert.IsFalse(CompareStudentsExamples.CompareStudentsUsingWhereAny(_scienceStudents, _businessStudents));
    }

    [TestMethod]
    public void GivenListSize_WhenMiddleElementOptionSelected_ValidateCorrectResults()
    {
        var testList = _compareListsMethods.GenerateIntegerList(false, true, 100, 100);

        Assert.AreEqual(100, testList.Count);
        Assert.AreEqual(50, testList[50]);
    }

    [TestMethod]
    public void GivenListSize_WhenReversedElementOptionSelected_ValidateCorrectResults()
    {
        var testList = _compareListsMethods.GenerateIntegerList(true, false, 100, 100);

        Assert.AreEqual(199, testList.First());
        Assert.AreEqual(100, testList.Last());
    }
}
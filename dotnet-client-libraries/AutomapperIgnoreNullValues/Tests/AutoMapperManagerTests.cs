namespace AutoMapperUseTests;

[TestClass]
public class AutoMapperManagerTests
{
    private IFixture _fixture;

    [TestInitialize]
    public void Setup()
    {
        _fixture = new Fixture();
    }

    [TestMethod]
    public void WhenUpdateStudentCalled_WithDefaultProfile_ThenAllSourceMembersWillMappedToDestination()
    {
        var source = _fixture.Create<StudentItemDto>();

        var result = AutoMapperManager.UpdateStudent(source);

        Assert.IsNotNull(result);
        Assert.AreEqual(result.Name, source.Name);
        Assert.AreEqual(result.University, source.University);
        Assert.AreEqual(result.Department, source.Department);
        CollectionAssert.AreEqual(result.Grades, source.Grades);
    }

    [TestMethod]
    public void WhenUpdateStudentCalled_WithDefaultProfile_WithNullSource_ThenDestinationWontChange()
    {
        StudentItemDto source = null;

        var result = AutoMapperManager.UpdateStudent(source);
        var expected = AutoMapperManager.GetSampleEntity();

        Assert.IsNotNull(result);
        Assert.AreEqual(result.Id, expected.Id);
        Assert.AreEqual(result.Name, expected.Name);
        Assert.AreEqual(result.University.Name, expected.University.Name);
        Assert.AreEqual(result.Department, expected.Department);
        CollectionAssert.AreEqual(result.Grades, expected.Grades);
    }

    [TestMethod]
    public void WhenUpdateStudentCalled_WithDefaultProfile_WithNullSourceMembers_ThenDestinationMembersWillBeNull()
    {
        var source = _fixture.Create<StudentItemDto>();
        source.Grades = null;
        source.University = null;

        var result = AutoMapperManager.UpdateStudent(source);

        Assert.IsNotNull(result);
        Assert.AreEqual(result.Name, source.Name);
        Assert.IsNull(result.University);
        Assert.IsNotNull(result.Grades);
        Assert.IsFalse(result.Grades.Any());
    }

    [TestMethod]
    public void WhenUpdateStudentCalled_WithDefaultProfile_WithNullDepertment_ThenItWillThrowException()
    {
        var source = _fixture.Create<StudentItemDto>();
        source.Department = null;

        Assert.ThrowsException<ArgumentNullException>(() => AutoMapperManager.UpdateStudent(source));
    }

    [TestMethod]
    public void WhenUpdateStudentCalled_WithCustomProfile_ThenAllSourceMembersWillMappedToDestination()
    {
        var source = _fixture.Create<StudentItemDto>();

        var result = AutoMapperManager.UpdateStudent(source);

        Assert.IsNotNull(result);
        Assert.AreEqual(result.Name, source.Name);
        Assert.AreEqual(result.University, source.University);
        Assert.AreEqual(result.Department, source.Department);
        CollectionAssert.AreEqual(result.Grades, source.Grades);
    }

    [TestMethod]
    public void WhenUpdateStudentCalled_WithCustomProfile_WithNullSource_ThenDestinationWontChange()
    {
        StudentItemDto source = null;

        var result = AutoMapperManager.UpdateStudent(source);
        var expected = AutoMapperManager.GetSampleEntity();

        Assert.IsNotNull(result);
        Assert.AreEqual(result.Id, expected.Id);
        Assert.AreEqual(result.Name, expected.Name);
        Assert.AreEqual(result.University.Name, expected.University.Name);
        Assert.AreEqual(result.Department, expected.Department);
        CollectionAssert.AreEqual(result.Grades, expected.Grades);
    }

    [TestMethod]
    public void WhenUpdateStudentCalled_WithCustomProfile_WithNullSourceMembers_ThenNullSourceMembersWillBeIgnored()
    {
        var source = _fixture.Create<StudentItemDto>();
        source.Grades = null;
        source.University = null;

        var result = AutoMapperManager.UpdateStudentIgnoreNullValues(source);

        Assert.IsNotNull(result);
        Assert.AreEqual(result.Name, source.Name);
        Assert.IsNotNull(result.University);
        Assert.IsNotNull(result.Grades);
        Assert.IsTrue(result.Grades.Any());
    }

    [TestMethod]
    public void WhenUpdateStudentCalled_WithCustomProfile_WithNullDepertment_ThenItWontThrowException()
    {
        var source = _fixture.Create<StudentItemDto>();
        source.Department = null;

        var result = AutoMapperManager.UpdateStudentIgnoreNullValues(source);

        Assert.IsNotNull(result.Department);
    }
}
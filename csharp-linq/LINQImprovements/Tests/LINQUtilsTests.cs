using LINQImprovements;

namespace Tests;

[TestClass]
public class LINQUtilsTests
{
    [TestMethod]
    public void WhenCalledChunk_ThenSplitStudentsListIntoChunks()
    {
        var studentChunks = LINQUtils.Chunk(2);

        studentChunks.ForEach(studentArray => Assert.AreEqual(studentArray.Count(), 2));
    }

    [TestMethod]
    public void WhenCalledMaxGrade_ThenReturnStudentWithMaxGrade()
    {
        var maxStudent = LINQUtils.MaxGrade();

        Assert.AreEqual(maxStudent?.Grade, 10);
    }

    [TestMethod]
    public void WhenCalledMinGrade_ThenReturnStudentWithMinGrade()
    {
        var minStudent = LINQUtils.MinGrade();

        Assert.AreEqual(minStudent?.Grade, 0);
    }

    [TestMethod]
    public void WhenCalledFirstOrDefault_AndStudentDoesNotExist_ThenReturnDefaultValue()
    {
        var defaultStudent = new Student(name: "", department: "", grade: -1);
        var firstStudent = LINQUtils.FirstOrDefaultStudent();

        Assert.AreEqual(defaultStudent, firstStudent);
    }

    [TestMethod]
    public void WhenCalledLastOrDefault_AndStudentDoesNotExist_ThenReturnDefaultValue()
    {
        var defaultStudent = new Student(name: "", department: "", grade: -1);
        var lastStudent = LINQUtils.LastOrDefaultStudent();

        Assert.AreEqual(defaultStudent, lastStudent);
    }

    [TestMethod]
    public void WhenCalledSingleOrDefault_AndStudentDoesNotExist_ThenReturnDefaultValue()
    {
        var defaultStudent = new Student(name: "", department: "", grade: -1);
        var singleStudent = LINQUtils.SingleOrDefaultStudent();

        Assert.AreEqual(defaultStudent, singleStudent);
    }

    [TestMethod]
    public void WhenCalledWithNegativeIndex_ThenReturnElementFromLast()
    {
        var student = LINQUtils.ElementAt(^1);

        Assert.AreEqual(LINQUtils.students[3], student);
    }

    [TestMethod]
    public void WhenCalledWithRange_ThenReturnStudentsInThatRange()
    {
        var studentsList = LINQUtils.Take(1..3);

        Assert.AreEqual(2, studentsList.Count());
    }

    [TestMethod]
    public void WhenCalledToCountStudents_AndStudentsIsAQueryable_ThenReturnFalse()
    {
        int count = -1; 
        var areStudentsEnumerated = LINQUtils.CountStudents(out count);

        Assert.AreEqual(false, areStudentsEnumerated);
        Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void WhenEnumerablesAreZipped_ThenReturnEnumeratedTupleWithAllEnumerables()
    {
        var names = new List<String>() { "student1", "student2" };
        var departments = new List<String>() { "dept1", "dept2" };
        var grades = new List<int>() { 1, 2};
        var expectedResult = new List<(String, String, int)>() { ("student1", "dept1", 1), ("student2", "dept2", 2) };

        var zippedEnumerables = LINQUtils.ZipEnumerables(names, departments, grades);

        CollectionAssert.AreEqual(expectedResult.ToArray(), zippedEnumerables.ToArray());
    }

    [TestMethod]
    public void WhenCalledDisticntByDepartment_ThenReturnDistinctStudentsByDepartment()
    {
        var distinctStudents = LINQUtils.DistinctDepartmentStudents();

        Assert.AreEqual(2, distinctStudents.Count());
    }

    [TestMethod]
    public void WhenCalledExceptBy_ThenReturnUnCommonNames()
    {
        var names = new List<string>() { "John", "James", "Mike" };
        var studentNames = new List<string>() { "Ross", "Stokes", "James", "Mike" };

        var uncommonNames = LINQUtils.ExceptBy(names, studentNames);

        Assert.AreEqual(1, uncommonNames.Count());
    }

    [TestMethod]
    public void WhenCalledIntersectBy_ThenReturnCommonNames()
    {
        var names = new List<string>() { "John", "James", "Mike" };
        var studentNames = new List<string>() { "Ross", "Stokes", "James", "Mike" };

        var commonNames = LINQUtils.IntersectBy(names, studentNames);

        Assert.AreEqual(2, commonNames.Count());
    }

    [TestMethod]
    public void WhenCalledUnionBy_ThenReturnAllNames()
    {
        var names = new List<string>() { "John", "James", "Mike" };
        var studentNames = new List<string>() { "Ross", "Stokes", "James", "Mike" };

        var allNames = LINQUtils.UnionBy(names, studentNames);

        Assert.AreEqual(5, allNames.Count());
    }

}

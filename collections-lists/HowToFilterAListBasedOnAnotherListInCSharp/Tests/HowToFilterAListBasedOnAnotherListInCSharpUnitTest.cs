using HowToFilterAListBasedOnAnotherListInCSharp;

namespace Tests;

public class HowToFilterAListBasedOnAnotherListInCSharpUnitTest
{
    [Fact]
    public void GivenList_WhenPrintListMethodCalled_ThenListItemsArePrintedCorrectly()
    {
        // Arrange
        List<char> chars = ['a', 'b', 'c', 'd', 'e'];

        // Act
        var output = Utilities.PrintList(chars);

        // Assert
        Assert.Equal("a, b, c, d, e", output);
    }

    [Fact]
    public void Given2Lists_WhenFilterContainedUsingLoopMethodCalled_ThenOnlyElementsContainedInList2AreKept()
    {
        // Arrange
        List<int> numbers = [17, 34, 50, 68, 121, 7, 145];
        List<int> otherNumbers = [50, 44, 121];

        // Act
        var output = Utilities.FilterContainedUsingLoop(numbers, otherNumbers);

        // Assert
        Assert.Equal([50, 121], output);
    }

    [Fact]
    public void Given2Lists_WhenFilterNotContainedUsingLoopMethodCalled_ThenOnlyElementsNotContainedInList2AreKept()
    {
        // Arrange
        List<int> numbers = [17, 34, 50, 68, 121, 7, 145];
        List<int> otherNumbers = [50, 44, 121];

        // Act
        var output = Utilities.FilterNotContainedUsingLoop(numbers, otherNumbers);

        // Assert
        Assert.Equal([17, 34, 68, 7, 145], output);
    }

    [Fact]
    public void Given2Lists_WhenFilterContainedUsingWhereMethodCalled_ThenOnlyElementsContainedInList2AreKept()
    {
        // Arrange
        List<int> numbers = [17, 34, 50, 68, 121, 7, 145];
        List<int> otherNumbers = [50, 44, 121];

        // Act
        var output = Utilities.FilterContainedUsingWhere(numbers, otherNumbers);

        // Assert
        Assert.Equal([50, 121], output);
    }

    [Fact]
    public void Given2Lists_WhenFilterNotContainedUsingWhereMethodCalled_ThenOnlyElementsNotContainedInList2AreKept()
    {
        // Arrange
        List<int> numbers = [17, 34, 50, 68, 121, 7, 145];
        List<int> otherNumbers = [50, 44, 121];

        // Act
        var output = Utilities.FilterNotContainedUsingWhere(numbers, otherNumbers);

        // Assert
        Assert.Equal([17, 34, 68, 7, 145], output);
    }    

    [Fact]
    public void Given2Lists_WhenFilterContainedUniqueMethodCalled_ThenOnlyUniqueElementsAreKept()
    {
        // Arrange
        List<int> numbers = [17, 34, 34, 50, 50, 50, 68, 68, 121, 7, 145];
        List<int> otherNumbers = [50, 44, 121];

        // Act
        var output = Utilities.FilterContainedUnique(numbers, otherNumbers);

        // Assert
        Assert.Equal([50, 121], output);
    }

    [Fact]
    public void Given2Lists_WhenFilterNotContainedUsingExceptMethodCalled_ThenOnlyElementsNotContainedInList2AreKept()
    {
        // Arrange
        List<int> numbers = [17, 34, 50, 68, 121, 7, 145];
        List<int> otherNumbers = [50, 44, 121];

        // Act
        var output = Utilities.FilterNotContainedUsingExcept(numbers, otherNumbers);

        // Assert
        Assert.Equal([17, 34, 68, 7, 145], output);
    }

    [Fact]
    public void Given2Lists_WhenFilterStringsByIntsMethodCalled_ThenStringsWithIntCounterpartsAreKept()
    {
        // Arrange
        List<string> numbersAsStrings = ["5", "11", "8", "40"];
        List<int> numbersAsInts = [3, 5, 8, 15, 30];

        // Act
        var output = Utilities.FilterStringsByInts(numbersAsStrings, numbersAsInts);

        // Assert
        Assert.Equal(["5", "8"], output);
    }

    [Fact]
    public void Given2Lists_WhenFilterAnimalNamesByLengthsMethodCalled_ThenOnlyNamesOfSpecificLengthsAreKept()
    {
        // Arrange
        List<string> animals = ["monkey", "rabbit", "bee", "crow", "jellyfish"];
        List<int> lengths = [4, 6];

        // Act
        var output = Utilities.FilterAnimalNamesByLengths(animals, lengths);

        // Assert
        Assert.Equal(["monkey", "rabbit", "crow"], output);
    }
        
    [Fact]
    public void Given2Lists_WhenFilterStudentsBySchoolCityMethodCalled_ThenStudentsWhoAttendSchoolInTheirCityAreKept()
    {
        // Arrange
        List<Student> students = 
        [
            new Student { Id = 1, Name = "Alice", SchoolId = 1, City = "Paris" },
            new Student { Id = 2, Name = "Bob", SchoolId = 2, City = "Reims" },
            new Student { Id = 3, Name = "Charlie", SchoolId = 1, City = "Versailles" },
            new Student { Id = 4, Name = "David", SchoolId = 1, City = "Calais" },
            new Student { Id = 5, Name = "Eve", SchoolId = 2, City = "Reims" },
            new Student { Id = 6, Name = "Frank", SchoolId = 1, City = "Nantes" }
        ];

        List<School> schools = 
        [
            new School { Id = 1, City = "Paris" },
            new School { Id = 2, City = "Reims" }
        ];

        // Act
        var filteredStudents = Utilities.FilterStudentsBySchoolCity(students, schools);
        var output = filteredStudents.Select(student => student.ToString()).ToList();

        // Assert
        Assert.Equal(["Alice from Paris", "Bob from Reims", "Eve from Reims"], output);
    }

    [Fact]
    public void Given2Lists_WhenFilterStudentsWithPropertiesMethodCalled_ThenCorrectStudentNamesAreKept()
    {
        // Arrange
        List<Student> students =
        [
            new Student { Id = 1, Name = "Alice", SchoolId = 1, City = "Paris" },
            new Student { Id = 2, Name = "Bob", SchoolId = 2, City = "Reims" },
            new Student { Id = 3, Name = "Charlie", SchoolId = 3, City = "Versailles" },
            new Student { Id = 4, Name = "David", SchoolId = 1, City = "Calais" },
            new Student { Id = 5, Name = "Eve", SchoolId = 2, City = "Reims" },
            new Student { Id = 6, Name = "Frank", SchoolId = 1, City = "Nantes" }
        ];

        List<int> schoolIds = [2, 3];

        // Act
        var output = Utilities.FilterStudentsWithProperties(students, schoolIds);

        // Assert
        Assert.Equal(["Bob", "Charlie", "Eve"], output);
    }

    [Fact]
    public void Given2Lists_WhenUpdateCityPropertyMethodCalled_ThenCityIsUpdatedCorrectly()
    {
        // Arrange
        List<Student> students =
        [
            new Student { Id = 1, Name = "Alice", SchoolId = 1, City = "Paris" },
            new Student { Id = 2, Name = "Bob", SchoolId = 2, City = "Reims" },
            new Student { Id = 3, Name = "Charlie", SchoolId = 3, City = "Versailles" },
            new Student { Id = 4, Name = "David", SchoolId = 1, City = "Calais" },
            new Student { Id = 5, Name = "Eve", SchoolId = 2, City = "Reims" },
            new Student { Id = 6, Name = "Frank", SchoolId = 1, City = "Nantes" }
        ];

        List<int> ids = [2, 4];

        // Act
        Utilities.UpdateCityProperty(students, ids);
        var output = students.Where(student => student.City == "Berlin").ToList().Count;

        // Assert
        Assert.Equal(2, output);
    }

    [Fact]
    public void Given2Lists_WhenFilterUsingHashSetMethodCalled_ThenOnlyElementsContainedInList2AreKept()
    {
        // Arrange
        List<int> numbers = [17, 34, 50, 68, 121, 7, 145];
        List<int> otherNumbers = [50, 44, 121];

        // Act
        var output = Utilities.FilterUsingHashSet(numbers, otherNumbers);

        // Assert
        Assert.Equal([50, 121], output);
    }

    [Fact]
    public void Given2Lists_WhenFilterUsingMaskMethodCalled_ThenOnlyElementsCorrespondingToTrueValuesAreKept()
    {
        // Arrange
        List<int> numbers = [17, 34, 50, 68, 121, 7, 145];
        List<bool> mask = [false, false, true];

        // Act
        var output = Utilities.FilterUsingMask(numbers, mask);

        // Assert
        Assert.Equal([50, 7], output);
    }
}
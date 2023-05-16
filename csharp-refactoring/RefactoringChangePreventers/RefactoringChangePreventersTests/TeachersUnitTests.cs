using RefactoringChangePreventers.ParallelInheritanceHierarchies.Correct;

namespace RefactoringChangePreventersTests;

[TestClass]
public class TeachersUnitTests
{
    [TestMethod]
    public void WhenShowingCurriculumForLanguageTeacher_ThenExpectedStringIsReturned()
    {
        // Arrange
        var teacher = new LanguageTeacher();

        // Act
        var result = teacher.ShowCurriculum();

        // Assert
        Assert.AreEqual("Educational outcomes for language learning", result);
    }

    [TestMethod]
    public void WhenShowingCurriculumForPhysicalEducationTeacher_ThenExpectedStringIsReturned()
    {
        // Arrange
        var teacher = new PhysicalEducationTeacher();

        // Act
        var result = teacher.ShowCurriculum();

        // Assert
        Assert.AreEqual("Educational outcomes for physical education", result);
    }
}
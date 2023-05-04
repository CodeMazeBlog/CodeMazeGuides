using RefactoringChangePreventers.ParallelInheritanceHierarchies.Correct;

namespace RefactoringChangePreventersTests;

[TestClass]
public class TeachersTests
{
    [TestMethod]
    public void LanguageTeacher_ShowCurriculum_ReturnsExpectedString()
    {
        // Arrange
        var teacher = new LanguageTeacher();

        // Act
        var result = teacher.ShowCurriculum();

        // Assert
        Assert.AreEqual("Educational outcomes for language learning", result);
    }

    [TestMethod]
    public void PhysicalEducationTeacher_ShowCurriculum_ReturnsExpectedString()
    {
        // Arrange
        var teacher = new PhysicalEducationTeacher();

        // Act
        var result = teacher.ShowCurriculum();

        // Assert
        Assert.AreEqual("Educational outcomes for physical education", result);
    }
}
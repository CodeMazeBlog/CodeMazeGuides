using FluentAssertions;

namespace NullConditionalOperators.Tests
{
    public class StudentTests
    {
        [Fact]
        public void GivenValidParamaters_WhenConstructorIsInvoked_ThenValidObjectIsReturned()
        {
            // Arrange
            var name = "John";
            var courses = new List<string> { "Math" };

            // Act
            var student = new Student(name, courses.ToList());

            // Assert
            student.Should().NotBeNull();
            student.Name.Should().Be(name);
            student.Courses.Should().NotBeNull();
            student.Courses.Count.Should().Be(courses.Count);
        }

        [Fact]
        public void GivenValidCourse_WhenEnrollIsInvoked_ThenCourseIsAddedToCourses()
        {
            // Arrange
            var name = "John";
            var courses = new List<string> { "Math" };
            var student = new Student(name, courses.ToList());

            // Act
            student.Enroll("Art");

            // Assert
            student.Courses.Count.Should().Be(courses.Count + 1);
        }
    }
}
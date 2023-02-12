using FluentAssertions;
using LinqInnerJoin;
using Xunit;
namespace Tests
{
    public class LinqInnerJoinUnitTest
    {
        [Fact]
        public void WhenFetchingCourses_ThenGetCoursesWithCategoryName()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course { Id = 1, Name = "C#", CategoryId = 1 },
                new Course { Id = 2, Name = "Docker", CategoryId = 2 },
                new Course { Id = 3, Name = "Python", CategoryId = 1 },
            };

            // Act
            var result = EnrolmentHelper.GetCoursesWithCategoryName(courses).ToList();

            // Assert
            var expectedResult = new List<dynamic>
            {
                new { Id = 1, Name = "C#", CategoryName = "Programming" },
                new { Id = 2, Name = "Docker", CategoryName = "DevOps" },
                new { Id = 3, Name = "Python", CategoryName = "Programming" },
            };

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void WhenFetchingCourses_ThenGetCoursesWithCategory()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course { Id = 1, Name = "C#", CategoryId = 1 },
                new Course { Id = 2, Name = "Docker", CategoryId = 2 },
                new Course { Id = 3, Name = "SQL", CategoryId = 3 },
                new Course { Id = 4, Name = "Jenkins", CategoryId = 2 },
            };

            // Act
            var result = EnrolmentHelper.GetCoursesWithCategory(courses).ToList();

            // Assert
            var expectedResult = new List<dynamic>
            {
                new { Id = 1, Name = "C#", CategoryName = "Programming" },
                new { Id = 2, Name = "Docker", CategoryName = "DevOps" },
                new { Id = 3, Name = "SQL", CategoryName = "Database System" },
                new { Id = 4, Name = "Jenkins", CategoryName = "DevOps" },
            };

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void WhenFetchingEnrollments_ThenFetchWithStudentAndCourseName()
        {
            // Arrange
            var enrollments = new List<Enrolment>
            {
                new Enrolment { Id = 1, StudentId = 1, CourseId = 1 },
                new Enrolment { Id = 2, StudentId = 2, CourseId = 6 },
                new Enrolment { Id = 3, StudentId = 3, CourseId = 8 },
            };

            // Act
            var result = EnrolmentHelper.GetEnrolments(enrollments).ToList();

            // Assert
            var expectedResult = new List<dynamic>
            {
                new { Id = 1, StudentName = "John", CourseName = "CSHARP" },
                new { Id = 2, StudentName = "Abhi", CourseName = "MSSQL" },
                new { Id = 3, StudentName = "Rahul", CourseName = "MONGODB" },
            };

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void WhenFilterEnrollments_ThenReturnsCorrectData()
        {
            // Arrange
            IEnumerable<Enrolment> enrollments = new List<Enrolment>
            {
                new Enrolment { Id = 1, StudentId = 1, CourseId = 1 },
                new Enrolment { Id = 2, StudentId = 2, CourseId = 2 },
                new Enrolment { Id = 3, StudentId = 3, CourseId = 1 },
            };
            var expected = new List<dynamic>
            {
                new { Id = 1, StudentName = "John", CourseId = 1, CourseName = "CSHARP" },
                new { Id = 3, StudentName = "Rahul", CourseId = 1, CourseName = "CSHARP" },
            };

            // Act
            var actual = EnrolmentHelper.FilterEnrolments(enrollments).ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void WhenFilterAndGroupEnrollments_ThenReturnCorrectData()
        {
            // Arrange
            IEnumerable<Enrolment> enrollments = Enrolment.GetDummyEnrolment();

            // Act
            var result = EnrolmentHelper.FilterAndGroupEnrolments(enrollments).ToList();

            // Assert
            result.Should().NotBeNull();

            // Check if the number of groups is correct
            int expectedGroupCount = 4;
            int actualGroupCount = result.Count();
            actualGroupCount.Should().Be(expectedGroupCount);

            // Check if the number of items in each group is correct
            int[] expectedGroupSizes = { 3, 1, 1, 1 };
            int index = 0;
            foreach (var group in result)
            {
                int expectedSize = expectedGroupSizes[index];
                int actualSize = Enumerable.Count(group);
                actualSize.Should().Be(expectedSize);

                index++;
            }

            var expectedResult = new List<List<dynamic>>
            {
              new List<dynamic>
              {
                new  { Id = 1, StudentName = "John", CourseId = 1, CourseName = "CSHARP" },
                new  { Id = 7, StudentName = "Rahul", CourseId = 1, CourseName = "CSHARP" },
                new  { Id = 16, StudentName = "Anita", CourseId = 1, CourseName = "CSHARP" }
              },
              new List<dynamic>
              {
                new  { Id = 4, StudentName = "Abhi", CourseId = 2, CourseName = "PYTHON" }
              },
              new List<dynamic>
              {
                new  { Id = 5, StudentName = "Abhi", CourseId = 3, CourseName = "JAVA" }
              },
              new List<dynamic>
              {
                new  { Id = 18, StudentName = "Jenny", CourseId = 4, CourseName = "RUBY" }
              }
            };

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

    }
}

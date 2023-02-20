using ReadAndParseAJSONFileInCSharp;

namespace Tests
{
    public class SystemTextJsonReadAndParseMethodsTest
    {
        private static readonly Teacher _expectedTeacher
            = new()
            {
                TeacherId = 1,
                FirstName = "Clare",
                LastName = "Anyanwu",
                BirthYear = 1987,
                Level = 8,
                Courses = new List<Course>
                {
                    new Course
                    {
                        Name = "Biology",
                        CreditUnits = 3,
                        NumberOfStudents = 42
                    },
                    new Course
                    {
                        Name = "Basic Science",
                        CreditUnits = 4,
                        NumberOfStudents = 35
                    }
                }

            };

        [Fact]
        public void GivenJsonFile_WhenUsingStreamReaderWithSystemTextJson_ThenParsesToAList()
        {
            var teachers = ReadAndParseJsonFileWithSystemTextJson.UseStreamReaderWithSystemTextJson();
            var firstTeacher = teachers.FirstOrDefault();

            Assert.IsType<List<Teacher>>(teachers);
            Assert.Equivalent(_expectedTeacher, firstTeacher, true);
        }

        [Fact]
        public void GivenJsonFile_WhenUsingFileReadAllTextWithSystemTextJson_ThenParsesToAList()
        {
            var teachers = ReadAndParseJsonFileWithSystemTextJson.UseFileReadAllTextWithSystemTextJson();
            var firstTeacher = teachers.FirstOrDefault();

            Assert.IsType<List<Teacher>>(teachers);
            Assert.Equivalent(_expectedTeacher, firstTeacher, true);
        }

        [Fact]
        public void GivenJsonFile_WhenUsingFileOpenReadTextWithSystemTextJson_ThenParsesToAList()
        {
            var teachers = ReadAndParseJsonFileWithSystemTextJson.UseFileOpenReadTextWithSystemTextJson();
            var firstTeacher = teachers.FirstOrDefault();
           
            Assert.IsType<List<Teacher>>(teachers);
            Assert.Equivalent(_expectedTeacher, firstTeacher, true);
        }
    }
}
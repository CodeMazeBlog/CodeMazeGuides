using ReadAndParseAJSONFileInCSharp;

namespace Tests
{
    public class NewtonsoftJsonReadAndParseMethodsTest
    {
        private static readonly Teacher _expectedTeacher =
            new()
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
        public void GivenJsonFile_WhenUsingUserDefinedObjectWithNewtonsoftJson_ThenParsesToAList()
        {
            var teachers = ReadAndParseJsonFileWithNewtonsoftJson.UseUserDefinedObjectWithNewtonsoftJson();
            var firstTeacher = teachers.FirstOrDefault();
            
            Assert.IsType<List<Teacher>>(teachers);
            Assert.Equivalent(_expectedTeacher, firstTeacher, true);
        }

        [Fact]
        public void GivenJsonFile_WhenUsingJArrayParseInNewtonsoftJson_ThenParsesToAList()
        {
            var teachers = ReadAndParseJsonFileWithNewtonsoftJson.UseJArrayParseInNewtonsoftJson();
            var firstTeacher = teachers.FirstOrDefault();

            Assert.IsType<List<Teacher>>(teachers);
            Assert.Equivalent(_expectedTeacher, firstTeacher, true);
        }

        [Fact]
        public void GivenJsonFile_WhenUsingJsonTextReaderInNewtonsoftJson_ThenParsesToAList()
        {
            var teachers = ReadAndParseJsonFileWithNewtonsoftJson.UseJsonTextReaderInNewtonsoftJson();
            var firstTeacher = teachers.FirstOrDefault();

            Assert.IsType<List<Teacher>>(teachers);
            Assert.Equivalent(_expectedTeacher, firstTeacher, true);
        }
    }
}
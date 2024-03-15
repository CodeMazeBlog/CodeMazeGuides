using ReadAndParseAJSONFileInCSharp;

namespace Tests
{
    public class NewtonsoftJsonReadAndParseMethodsTest
    {
        private readonly ReadAndParseJsonFileWithNewtonsoftJson _readJson
            = new(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data", "teachers-json.json"));

        private readonly Teacher _expectedTeacher 
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
        public void GivenJsonFile_WhenUsingUserDefinedObjectWithNewtonsoftJson_ThenParsesToAList()
        {
            var teachers = _readJson.UseUserDefinedObjectWithNewtonsoftJson();
            var firstTeacher = teachers.FirstOrDefault();
            
            Assert.IsType<List<Teacher>>(teachers);
            Assert.Equivalent(_expectedTeacher, firstTeacher, true);
        }

        [Fact]
        public void GivenJsonFile_WhenUsingJArrayParseInNewtonsoftJson_ThenParsesToAList()
        {
            var teachers = _readJson.UseJArrayParseInNewtonsoftJson();
            var firstTeacher = teachers.FirstOrDefault();

            Assert.IsType<List<Teacher>>(teachers);
            Assert.Equivalent(_expectedTeacher, firstTeacher, true);
        }

        [Fact]
        public void GivenJsonFile_WhenUsingJsonTextReaderInNewtonsoftJson_ThenParsesToAList()
        {
            var teachers = _readJson.UseJsonTextReaderInNewtonsoftJson();
            var firstTeacher = teachers.FirstOrDefault();

            Assert.IsType<List<Teacher>>(teachers);
            Assert.Equivalent(_expectedTeacher, firstTeacher, true);
        }
    }
}
using Newtonsoft.Json;

namespace HowToConvertJSONToDataTableInCSharp
{
    public class GenerateBenchmarkStudentJson
    {
        public static string Generate10000StudentsJsonData()
        {
            var students = new List<Student>();
            for (int i = 0; i < 10000; i++)
            {
                students.Add(new Student
                {
                    FirstName = "Student " + i,
                    LastName = "Male",
                    BirthYear = 2000 + i,
                    Subjects = new string[] { "Physics", "Chemistry", "Mathematics", "English" }
                });
            }
            var json = JsonConvert.SerializeObject(students);

            return json;
        }
    }
}
using MultiplePostActionsInController.Models;

using Newtonsoft.Json;

namespace MultiplePostActionsInController.Services
{
    public class StudentGradeService
    {
        public List<StudentGrade> GetAll()
        {
            using StreamReader sreader = new("StudentInfo.json");
            string json = sreader.ReadToEnd();
            var grades = JsonConvert.DeserializeObject<List<StudentGrade>>(json);

            return grades;
        }


        public void Add(StudentGrade student)
        {
            var grades = GetAll();
            if (grades is null)
            {
                grades = new List<StudentGrade>();
            }
            grades.Add(student);

            string sudnetJsonData = JsonConvert.SerializeObject(grades, Formatting.None);
            File.WriteAllText("StudentGrades.json", sudnetJsonData);
        }
    }
}

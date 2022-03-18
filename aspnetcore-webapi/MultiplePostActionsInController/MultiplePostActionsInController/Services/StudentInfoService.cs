using MultiplePostActionsInController.Models;

using Newtonsoft.Json;

namespace MultiplePostActionsInController.Services
{
    public class StudentInfoService
    {
        public List<StudentInfo> GetAll()
        {
            using StreamReader sreader = new("StudentInfo.json");
            string json = sreader.ReadToEnd();
            var students = JsonConvert.DeserializeObject<List<StudentInfo>>(json);

            return students;
        }


        public void Add(StudentInfo student)
        {
            var students = GetAll();
            if (students is null)
            {
                students = new List<StudentInfo>();
            }
            students.Add(student);

            string sudnetJsonData = JsonConvert.SerializeObject(students, Formatting.None);
            File.WriteAllText("StudentInfo.json", sudnetJsonData);
        }
    }
}

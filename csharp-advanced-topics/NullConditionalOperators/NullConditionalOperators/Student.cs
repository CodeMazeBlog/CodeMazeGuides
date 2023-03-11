namespace NullConditionalOperators
{
    public class Student
    {
        public string? Name { get; set; }
        public List<string> Courses { get; set; }

        public Student(string name, List<string> courses)
        {
            Name = name;
            Courses = courses;
        }

        public void Enroll(string course)
        {
            Courses.Add(course);
        }
    }
}

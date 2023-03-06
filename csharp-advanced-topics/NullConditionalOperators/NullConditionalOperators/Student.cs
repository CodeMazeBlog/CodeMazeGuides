namespace NullConditionalOperators
{
    public class Student
    {
        public string? Name { get; set; }
        public string[]? Courses { get; set; }

        public Student()
        {
        }

        public Student(string name, string[] courses)
        {
            Name = name;
            Courses = courses;
        }

        public void Study(string course)
        {
            Console.WriteLine($"Studying for the {course} exam...");
        }
    }
}

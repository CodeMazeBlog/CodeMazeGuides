namespace NullConditionalOperators
{
    public class Student
    {
        public const int MaxNumberOfCourses = 10;

        public string? Name { get; set; }
        public List<string> Courses { get; set; }

        public event EventHandler? MaxNumberOfCoursesReached;

        public Student(string name, List<string> courses)
        {
            Name = name;
            Courses = courses;
        }

        public void Enroll(string course)
        {
            Courses.Add(course);

            if (Courses.Count >= MaxNumberOfCourses)
            {
                MaxNumberOfCoursesReached?.Invoke(this, EventArgs.Empty);
            }
        }       
    }
}

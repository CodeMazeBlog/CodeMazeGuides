namespace ActionFuncInCsharp
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();

        public static IEnumerable<Student> DummyStudents()
        {
            return new List<Student>
            {
                new Student { Id = 1, Name = "Rahul" },
                new Student { Id = 2, Name = "Vikas" },
                new Student { Id = 3, Name = "Neha" },
                new Student { Id = 4, Name = "Abhi" },
                new Student { Id = 5, Name = "Lara" },
            };
        }
    }
}

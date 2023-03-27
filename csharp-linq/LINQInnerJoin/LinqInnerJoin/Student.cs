namespace LinqInnerJoin
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static IEnumerable<Student> GetDummyStudents()
        {
            var studentNames = new List<string>
            {
                "John",
                "Abhi",
                "Rahul",
                "Nisha",
                "Mike",
                "Joana",
                "Nick",
                "Julie",
                "Anita",
                "Jenny"
            };

            var students = new List<Student>();

            for (var i = 0; i < 10; i++)
            {
                var student = new Student
                {
                    Id = i + 1,
                    Name = studentNames[i]
                };

                students.Add(student);
            }

            return students;
        }
    }
}

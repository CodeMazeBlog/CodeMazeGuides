namespace LinqInnerJoin
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    
        public static IEnumerable<Student> GetDummyStudents()
        {
            var studentNames = new List<string> { "John", "Abhi", "Rahul", "Nisha", "Mike", "Joana", "Nick", "Julie", "Anita", "Jenny" };
            var studentAges = new List<int> { 20, 22, 25, 30, 40, 45, 23, 29, 32, 55 };
            var students = new List<Student>();

            for (var i = 0; i < 10; i++)
            {
                var student = new Student
                {
                    Id = i + 1,
                    Name = studentNames[i],
                    IsActive = i % 2 == 0,
                    Age = studentAges[i % 10]
                };

                students.Add(student);
            }

            return students;
        }
    }
}

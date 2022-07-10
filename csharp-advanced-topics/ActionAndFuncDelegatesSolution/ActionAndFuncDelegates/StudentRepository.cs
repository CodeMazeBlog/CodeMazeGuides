namespace ActionAndFuncDelegates
{
    public class StudentRepository
    {
        public static IList<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = 101,
                    Name = "John",
                    CGPA = 8.5f
                },
                new Student
                {
                    Id = 102,
                    Name = "Mary",
                    CGPA = 9.5f
                },
                new Student
                {
                    Id = 103,
                    Name = "Dave",
                    CGPA = 6.23f
                },
                new Student
                {
                    Id = 104,
                    Name = "Jose",
                    CGPA = 5.54f
                },
                new Student
                {
                    Id = 105,
                    Name = "Alex",
                    CGPA = 8.2f
                }

            };
        }

        public static void GetDistinctionStudents(Func<Student, bool> isEligibleForAward)
        {
            foreach (var student in GetStudents())
            {
                if (isEligibleForAward(student))
                {
                    Console.WriteLine($"{student.Name} is awarded the distinction prize");
                }
            }
        }
    }
}

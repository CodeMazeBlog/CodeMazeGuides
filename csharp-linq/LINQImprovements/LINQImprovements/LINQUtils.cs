using System;
namespace LINQImprovements
{
    public static class LINQUtils
    {
        public static IList<Student> Students => new List<Student>()
        {
            new Student("John", "CS", 10),
            new Student("James", "CS", 6),
            new Student("Mike", "IT", 8),
            new Student("Stokes", "IT", 0),
        };

        static Student defaultStudent = new Student(name: "", department: "", grade: -1);


        public static List<Student[]> Chunk(int pageSize)
        {
            var studentChunks = Students.Chunk(pageSize);

            return studentChunks.ToList();
        }

        public static Student? MaxGrade()
        {
            return Students.MaxBy(student => student.Grade);
        }

        public static Student? MinGrade()
        {
            return Students.MinBy(student => student.Grade);
        }

        public static Student FirstOrDefaultStudent()
        {
            return Students.FirstOrDefault(student => student.Name.Equals("Fake Student"), defaultStudent);
        }

        public static Student LastOrDefaultStudent()
        {
            return Students.LastOrDefault(student => student.Name.Equals("Fake Student"), defaultStudent);
        }

        public static Student SingleOrDefaultStudent()
        {
            return Students.SingleOrDefault(student => student.Name.Equals("Fake Student"), defaultStudent);
        }

        public static Student ElementAt(Index index)
        {
            return Students.ElementAt(index);
        }

        public static List<Student> Take(Range range)
        {
            return Students.Take(range).ToList();
        }

        public static bool CountStudents(out int count)
        {
            var queryableStudents = Students.AsQueryable();

            return queryableStudents.TryGetNonEnumeratedCount(out count);
        }

        public static IEnumerable<(string, string, int)> ZipEnumerables(List<string> names, List<string> departments, List<int> grades)
        {
            return names.Zip(departments, grades);
        }

        public static IEnumerable<Student> DistinctByDepartment()
        {
            return Students.DistinctBy(student => student.Department);
        }

        public static IEnumerable<Student> ExceptByDepartment(List<Student> secondList)
        {
            return Students.ExceptBy(secondList.Select(student => student.Department), student => student.Department);
        }

        public static IEnumerable<Student> IntersectByDepartment(List<Student> secondList)
        {
            return Students.IntersectBy(secondList.Select(student => student.Department), student => student.Department);
        }

        public static IEnumerable<Student> UnionByDepartment(List<Student> secondList)
        {
            return Students.UnionBy(secondList, student => student.Department);
        }
    }
}


using System;
namespace LINQImprovements
{
    public static class LINQUtils
    {
        public static IList<Student> students = new List<Student>()
        {
            new Student("John", "CS", 10),
            new Student("James", "CS", 6),
            new Student("Mike", "IT", 8),
            new Student("Stokes", "IT", 0),
        };

        static Student defaultStudent = new Student(name: "", department: "", grade: -1);


        public static List<Student[]> Chunk( int pageSize)
        {
            var studentChunks =  students.Chunk(pageSize);

            return studentChunks.ToList();
        }

        public static Student? MaxGrade()
        {
            return students.MaxBy(student => student.Grade);
        }

        public static Student? MinGrade()
        {
            return students.MinBy(student => student.Grade);
        }

        public static Student FirstOrDefaultStudent()
        {
            return students.FirstOrDefault(student => student.Name.Equals("Fake Student"), defaultStudent);
        }

        public static Student LastOrDefaultStudent()
        {
            return students.LastOrDefault(student => student.Name.Equals("Fake Student"), defaultStudent);
        }

        public static Student SingleOrDefaultStudent()
        {
            return students.SingleOrDefault(student => student.Name.Equals("Fake Student"), defaultStudent);
        }

        public static Student ElementAt(Index index)
        {
            return students.ElementAt(index);
        }

        public static List<Student> Take(Range range)
        {
            return students.Take(range).ToList();
        }

        public static bool CountStudents(out int count)
        {
            var queryableStudents = students.AsQueryable();

            return queryableStudents.TryGetNonEnumeratedCount(out count);
        }

        public static IEnumerable<(string, string, int)> ZipEnumerables(List<string> names, List<string> departments, List<int> grades)
        {
            return names.Zip(departments, grades);
        }

        public static IEnumerable<Student> DistinctDepartmentStudents()
        {
            return students.DistinctBy(student => student.Department);
        }

        public static IEnumerable<String> ExceptBy(List<string> firstList, List<string> secondList)
        {
            return firstList.ExceptBy(secondList, student => student);
        }

        public static IEnumerable<String> IntersectBy(List<string> firstList, List<string> secondList)
        {
            return firstList.IntersectBy(secondList, student => student);
        }

        public static IEnumerable<String> UnionBy(List<string> firstList, List<string> secondList)
        {
            return firstList.UnionBy(secondList, student => student);
        }
    }
}


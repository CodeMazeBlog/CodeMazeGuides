using System.Collections.Generic;
using System.Linq;

namespace LINQBasicExample
{
    public class FrequentlyUsedLINQExamples
    {
        static IQueryable<Student> GetStudentsFromDb()
        {
            return new[] {  
                new Student() { StudentID = 1, StudentName = "John Nigel", Mark = 73, City ="NYC"} ,
                new Student() { StudentID = 2, StudentName = "Alex Roma",  Mark = 51 , City ="CA"} ,
                new Student() { StudentID = 3, StudentName = "Noha Shamil",  Mark = 88 , City ="CA"} ,
                new Student() { StudentID = 4, StudentName = "James Palatte" , Mark = 60, City ="NYC"} ,
                new Student() { StudentID = 5, StudentName = "Ron Jenova" , Mark = 85 , City ="NYC"} 
            }.AsQueryable();
        }

        public static IEnumerable<Student> DemoLINQQueryOperation()
        {
            var studentList = GetStudentsFromDb();
            var highPerformingStudents = from student in studentList
                                         where student.Mark > 80
                                         select student;
            return highPerformingStudents;
        }

        public static IEnumerable<Student> SelectHighPerformingStudents()
        {
            var studentList = GetStudentsFromDb();
            var selectHighPerformingStudents = studentList.Where(s => s.Mark > 80);
            return selectHighPerformingStudents;
        }

        public static IEnumerable<Student> SelectStudentsOrderById()
        {
            var studentList = GetStudentsFromDb();
            var selectStudentsWithOrderById = studentList.OrderBy(x => x.StudentID);
            return selectStudentsWithOrderById;
        }

        public static IEnumerable<Student> StudentsGetOrderByDescending()
        {
            var studentList = GetStudentsFromDb();
            var selectStudentsWithOrderByDecendingIds = studentList.OrderByDescending(x => x.StudentID);
            return selectStudentsWithOrderByDecendingIds;
        }

        public static IEnumerable<IGrouping<string, Student>> SelectStudentsGroupBy()
        {
            var studentList = GetStudentsFromDb();
            var studentListGroupByCity = studentList.GroupBy(x => x.City);
            return studentListGroupByCity;
        }

        public static bool GetStatusOfAllStudentsWhoPassed()
        {
            var studentList = GetStudentsFromDb();
            var hasAllStudentsPassed = studentList.All(x => x.Mark > 50);
            return hasAllStudentsPassed;
        }

        public static bool GetStatusOfAnyStudentsWithDistinction()
        {
            var studentList = GetStudentsFromDb();
            var hasAnyStudentGotDistinction = studentList.Any(x => x.Mark > 86);
            return hasAnyStudentGotDistinction;
        }

        public static bool GetStudentContainsId()
        {
            var studentList = GetStudentsFromDb();
            var studentContainsId = studentList.Contains(new Student { StudentName = "Noha Shamil"}, new StudentNameComparer());
            return studentContainsId;
        }

        public static IEnumerable<Student> GetStudentsSkipAtIndex()
        {
            var studentList = GetStudentsFromDb();
            var skipStuentsUptoIndexTwo = studentList.Skip(2);
            return skipStuentsUptoIndexTwo;
        }

        public static IEnumerable<Student> TakeStudentsUptoIndex()
        {
            var studentList = GetStudentsFromDb();
            var takeStudentsUptoIndexTwo = studentList.Take(2);
            return takeStudentsUptoIndexTwo;
        }

        public static IEnumerable<Student> SelectStudentNames(string name)
        {
            var studentList = GetStudentsFromDb();
            var studentsIdentified = studentList.Where(c => c.StudentName == name).Select(stu => new Student {StudentName = stu.StudentName , Mark = stu.Mark});
            return studentsIdentified;
        }

        public static int SumOfStudentMarks()
        {
            var studentList = GetStudentsFromDb();
            var sumOfMarks = studentList.Sum(x => x.Mark);
            return sumOfMarks;
        }

        public static int CountOfStudents()
        {
            var studentList = GetStudentsFromDb();
            var countOfStudents = studentList.Count(x => x.Mark > 65);
            return countOfStudents;
        }

        public static int MaxMarksOfStudent()
        {
            var studentList = GetStudentsFromDb();
            var maxMarks = studentList.Max(x => x.Mark);
            return maxMarks;
        }

        public static int MinMarksOfStudent()
        {
            var studentList = GetStudentsFromDb();
            var minMarks = studentList.Min(x => x.Mark);
            return minMarks;
        }

        public static double AverageMarksOfStudent()
        {
            var studentList = GetStudentsFromDb();
            var avgMarks = studentList.Average(x => x.Mark);
            return avgMarks;
        }

        public static Student FirstStudentOccurence()
        {
            var studentList = GetStudentsFromDb();
            var firstStudent = studentList.First(x => x.StudentID % 2 == 0);
            return firstStudent;
        }

        public static Student FirstOrDefaultStudentOccurence()
        {
            var studentList = GetStudentsFromDb();
            var firstOrDefaultStudent = studentList.FirstOrDefault(x => x.StudentID == 1);
            return firstOrDefaultStudent;
        }

        public static Student SingleStudentOccurence()
        {
            var studentList = GetStudentsFromDb();
            var singleStudent = studentList.Single(x => x.StudentID == 1);
            return singleStudent;
        }

        public static Student SingleOrDefaultStudentOccurence()
        {
            var studentList = GetStudentsFromDb();
            var singleOrDefaultStudent = studentList.SingleOrDefault(x => x.StudentID == 1);
            return singleOrDefaultStudent;
        }
    }
}
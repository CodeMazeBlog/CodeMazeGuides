using System.Collections.Generic;
using System.Linq;

namespace LINQBasicExample
{
    public class FrequentlyUsedLINQExamples
    {
        static IQueryable<Student> GetStudnetsFromDb()
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
            /*Comment to Marinko : I am initializing GetStudnetsFromDb() to a var and then using it in the query for better readability. I will delete this comment*/
            var studentList = GetStudnetsFromDb();
            var highPerformingStudents = from student in studentList
                                         where student.Mark > 80
                                         select student;
            return highPerformingStudents;
        }

        public static IEnumerable<Student> DemoHighPerformingStudents()
        {
            var studentList = GetStudnetsFromDb();
            var highPerformingStudents = studentList.Where(s => s.Mark > 80);
            return highPerformingStudents;
        }

        public static IEnumerable<Student> SelectHighPerformingStudents()
        {
            var studentList = GetStudnetsFromDb();
            var selectHighPerformingStudents = studentList.Where(s => s.Mark > 80);
            return selectHighPerformingStudents;
        }

        public static IEnumerable<Student> SelectStudentsOrderById()
        {
            var studentList = GetStudnetsFromDb();
            var selectStudentsWithOrderById = studentList.OrderBy(x => x.StudentID);
            return selectStudentsWithOrderById;
        }

        public static IEnumerable<Student> StudentsGetOrderByDescending()
        {
            var studentList = GetStudnetsFromDb();
            var selectStudentsWithOrderByDecendingIds = studentList.OrderByDescending(x => x.StudentID);
            return selectStudentsWithOrderByDecendingIds;
        }

        public static IEnumerable<IGrouping<string, Student>> SelectStudentsGroupBy()
        {
            var studentList = GetStudnetsFromDb();
            var studentListGroupByCity = studentList.GroupBy(x => x.City);
            return studentListGroupByCity;
        }

        public static int SumOfStudentMarks()
        {
            var studentList = GetStudnetsFromDb();
            var sumOfMarks = studentList.Sum(x => x.Mark);
            return sumOfMarks;
        }

        public static int CountOfStudents()
        {
            var studentList = GetStudnetsFromDb();
            var countOfStudents = studentList.Count(x => x.Mark > 65);
            return countOfStudents;
        }

        public static int MaxMarksOfStudent()
        {
            var studentList = GetStudnetsFromDb();
            var maxMarks = studentList.Max(x => x.Mark);
            return maxMarks;
        }

        public static int MinMarksOfStudent()
        {
            var studentList = GetStudnetsFromDb();
            var minMarks = studentList.Min(x => x.Mark);
            return minMarks;
        }

        public static Student FirstStudentOccurence()
        {
            var studentList = GetStudnetsFromDb();
            var firstStudent = studentList.First(x => x.StudentID % 2 == 0);
            return firstStudent;
        }

        public static Student FirstOrDefaultStudentOccurence()
        {
            var studentList = GetStudnetsFromDb();
            var firstOrDefaultStudent = studentList.FirstOrDefault(x => x.StudentID == 1);
            return firstOrDefaultStudent;
        }

        public static Student SingleStudentOccurence()
        {
            var studentList = GetStudnetsFromDb();
            var singleStudent = studentList.Single(x => x.StudentID == 1);
            return singleStudent;
        }

        public static Student SingleOrDefaultStudentOccurence()
        {
            var studentList = GetStudnetsFromDb();
            var singleOrDefaultStudent = studentList.SingleOrDefault(x => x.StudentID == 1);
            return singleOrDefaultStudent;
        }
    }
}
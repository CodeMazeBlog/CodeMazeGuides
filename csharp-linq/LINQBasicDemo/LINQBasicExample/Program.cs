using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQBasicExample
{
    public class Program
    {
        readonly static IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John Nigel", Marks = 73, City ="NYC"} ,
                new Student() { StudentID = 2, StudentName = "Alex Roma",  Marks = 51 , City ="CA"} ,
                new Student() { StudentID = 3, StudentName = "Noha Shamil",  Marks = 88 , City ="CA"} ,
                new Student() { StudentID = 4, StudentName = "James Palatte" , Marks = 60, City ="NYC"} ,
                new Student() { StudentID = 5, StudentName = "Ron Jenova" , Marks = 85 , City ="NYC"}
        };

        static void Main(string[] args)
        {
            int[] studentIds = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var studentsWithEvenIds =
                from studentId in studentIds
                where (studentId % 2) == 0
                select studentId;

            foreach (int studentId in studentsWithEvenIds)
            {
                Console.WriteLine("Studnet Id {0} which is even.", studentId);
            }

            int countOfStudentsWithEvenIds = studentsWithEvenIds.Count();
            Console.WriteLine($"\n\n Count of students with even Ids {countOfStudentsWithEvenIds}");

            Console.WriteLine("\n\n ## Query Syntax ##");

            List<Student> students = DemoLINQQueryOperation().ToList();
            PrintStudentList(students);

            Console.WriteLine("\n\n ## Method Syntax ##");

            List<Student> highPerformingStudents = DemoHighPerformingStudents().ToList();
            PrintStudentList(highPerformingStudents);

            Console.WriteLine("\n\n ## Examples : Frequently Used LINQ Methods ##");

            Console.WriteLine("\n ## Where() ##");
            List<Student> studentsWhoScoredHighGrades = SelectHighPerformingStudents().ToList();
            PrintStudentList(studentsWhoScoredHighGrades);

            Console.WriteLine("\n ## OrderBy() ##");
            List<Student> studentsAfterOrderById = SelectStudentsOrderById().ToList();
            PrintStudentList(studentsAfterOrderById);

            Console.WriteLine("\n ## OrderByyDescending() ##");
            List<Student> studentsAfterOrderByDec = StudentsGetOrderByDescending().ToList();
            PrintStudentList(studentsAfterOrderByDec);

            Console.WriteLine("\n ## GroupBy() ##");
            var studentsAfterGroupBy = SelectStudentsGroupBy().ToList();
            foreach (var item in studentsAfterGroupBy)
            {
                foreach (var element in item)
                {
                    Console.WriteLine($"{item.Key} - {element.StudentName}");
                }
            }

            Console.WriteLine("\n ## Sum() ##");
            int totalMarks = SumOfStudentMarks();
            PrintStudentProperty(totalMarks);

            Console.WriteLine("\n ## Count() ##");
            int countOfStudents = CountOfStudents();
            PrintStudentProperty(countOfStudents);

            Console.WriteLine("\n ## Max() ##");
            int maxMarks = MaxMarksOfStudent();
            PrintStudentProperty(maxMarks);

            Console.WriteLine("\n ## Min() ##");
            int minMarks = MinMarksOfStudent();
            PrintStudentProperty(minMarks);

            Console.WriteLine("\n ## First() ##");
            Student firstStudent = FirstStudentOccurence();
            PrintStudentObject(firstStudent);

            Console.WriteLine("\n ## FirstOrDefault() ##");
            Student firstOrDefaultStudent = FirstOrDefaultStudentOccurence();
            PrintStudentObject(firstOrDefaultStudent);

            Console.WriteLine("\n ## Single() ##");
            Student singleStudent = SingleStudentOccurence();
            PrintStudentObject(singleStudent);

            Console.WriteLine("\n ## SingleOrDefault() ##");
            Student singleOrDefaultStudent = SingleOrDefaultStudentOccurence();
            PrintStudentObject(singleOrDefaultStudent);
        }

        public static void PrintStudentObject(Student student)
        {
            Console.WriteLine($"{student.StudentID} - {student.StudentName}");
        }
        public static void PrintStudentProperty(int studentProperty)
        {
            Console.WriteLine(studentProperty);
        }

        public static void PrintStudentList(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentID} - {student.StudentName}");
            }
        }

        public static IEnumerable<Student> DemoLINQQueryOperation()
        {
            var highPerformingStudents = from student in studentList
                                         where student.Marks > 80
                                         select student;
            return highPerformingStudents;
        }

        public static IEnumerable<Student> DemoHighPerformingStudents()
        {
            var highPerformingStudents = studentList.Where(s => s.Marks > 80).ToList<Student>();
            return highPerformingStudents;
        }


        public static IEnumerable<Student> SelectHighPerformingStudents()
        {
            var selectHighPerformingStudents = studentList.Where(s => s.Marks > 80).ToList<Student>();
            return selectHighPerformingStudents;
        }

        public static IEnumerable<Student> SelectStudentsOrderById()
        {
            var selectStudentsWithOrderById = studentList.OrderBy(x => x.StudentID);
            return selectStudentsWithOrderById;
        }

        public static IEnumerable<Student> StudentsGetOrderByDescending()
        {
            var selectStudentsWithOrderByDecendingIds = studentList.OrderByDescending(x => x.StudentID);
            return selectStudentsWithOrderByDecendingIds;
        }

        public static IEnumerable<IGrouping<string, Student>> SelectStudentsGroupBy()
        {
            var studentListGroupByCity = studentList.GroupBy(x => x.City);
            return studentListGroupByCity;
        }

        public static int SumOfStudentMarks()
        {
            var sumOfMarks = studentList.Sum(x => x.Marks);
            return sumOfMarks;
        }

        public static int CountOfStudents()
        {
            int countOfStudents = studentList.Count(x => x.Marks > 65);
            return countOfStudents;
        }

        public static int MaxMarksOfStudent()
        {
            int maxMarks = studentList.Max(x => x.Marks);
            return maxMarks;
        }

        public static int MinMarksOfStudent()
        {
            int minMarks = studentList.Min(x => x.Marks);
            return minMarks;
        }

        public static Student FirstStudentOccurence()
        {
            var firstStudent = studentList.First(x => x.StudentID % 2 == 0);
            return firstStudent;
        }

        public static Student FirstOrDefaultStudentOccurence()
        {
            var firstOrDefaultStudent = studentList.FirstOrDefault(x => x.StudentID == 1);
            return firstOrDefaultStudent;
        }

        public static Student SingleStudentOccurence()
        {
            var singleStudent = studentList.Single(x => x.StudentID == 1);
            return singleStudent;
        }

        public static Student SingleOrDefaultStudentOccurence()
        {
            var singleOrDefaultStudent = studentList.SingleOrDefault(x => x.StudentID == 1);
            return singleOrDefaultStudent;
        }
    }
}
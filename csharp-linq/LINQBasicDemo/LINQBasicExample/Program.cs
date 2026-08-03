using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQBasicExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var studentIds = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var studentsWithEvenIds =
                from studentId in studentIds
                where (studentId % 2) == 0
                select studentId;

            foreach (int studentId in studentsWithEvenIds)
            {
                Console.WriteLine("Studnet Id {0} which is even.", studentId);
            }

            var countOfStudentsWithEvenIds = studentsWithEvenIds.Count();
            Console.WriteLine($"\n\n Count of students with even Ids {countOfStudentsWithEvenIds}");

            Console.WriteLine("\n\n ## Query Syntax ##");
            var students = FrequentlyUsedLINQExamples.DemoLINQQueryOperation().ToList();
            PrintStudentList(students);

            Console.WriteLine("\n\n ## Method Syntax - Where() ##");

            var highPerformingStudents = FrequentlyUsedLINQExamples.SelectHighPerformingStudents().ToList();
            PrintStudentList(highPerformingStudents);

            Console.WriteLine("\n\n ## Examples : Frequently Used LINQ Methods ##");

            Console.WriteLine("\n ## Select() ##");
            var studentsSelected = FrequentlyUsedLINQExamples.SelectStudentNames("Noha Shamil").ToList();
            PrintStudentList(studentsSelected);

            Console.WriteLine("\n ## OrderBy() ##");
            var studentsAfterOrderById = FrequentlyUsedLINQExamples.SelectStudentsOrderById().ToList();
            PrintStudentList(studentsAfterOrderById);

            Console.WriteLine("\n ## OrderByyDescending() ##");
            var studentsAfterOrderByDec = FrequentlyUsedLINQExamples.StudentsGetOrderByDescending().ToList();
            PrintStudentList(studentsAfterOrderByDec);

            Console.WriteLine("\n ## GroupBy() ##");
            var studentsAfterGroupBy = FrequentlyUsedLINQExamples.SelectStudentsGroupBy().ToList();
            foreach (var item in studentsAfterGroupBy)
            {
                foreach (var element in item)
                {
                    Console.WriteLine($"{item.Key} - {element.StudentName}");
                }
            }

            Console.WriteLine("\n ## All() ##");
            var hasStudentsPassed = FrequentlyUsedLINQExamples.GetStatusOfAllStudentsWhoPassed();
            PrintBoolStatus(hasStudentsPassed);

            Console.WriteLine("\n ## Any() ##");
            var hasAnyStudentGotADistinction = FrequentlyUsedLINQExamples.GetStatusOfAllStudentsWhoPassed();
            PrintBoolStatus(hasAnyStudentGotADistinction);

            Console.WriteLine("\n ## Contains() ##");
            var isStudentContainsIdex = FrequentlyUsedLINQExamples.GetStudentContainsId();
            PrintBoolStatus(isStudentContainsIdex);

            Console.WriteLine("\n ## Skip() ##");
            var skipStudentAtIndex = FrequentlyUsedLINQExamples.GetStudentsSkipAtIndex().ToList();
            PrintStudentList(skipStudentAtIndex);

            Console.WriteLine("\n ## Take() ##");
            var takeStudentAtIndex = FrequentlyUsedLINQExamples.TakeStudentsUptoIndex().ToList();
            PrintStudentList(takeStudentAtIndex);

            Console.WriteLine("\n ## Sum() ##");
            var totalMarks = FrequentlyUsedLINQExamples.SumOfStudentMarks();
            PrintStudentProperty(totalMarks);

            Console.WriteLine("\n ## Count() ##");
            var countOfStudents = FrequentlyUsedLINQExamples.CountOfStudents();
            PrintStudentProperty(countOfStudents);

            Console.WriteLine("\n ## Max() ##");
            var maxMarks = FrequentlyUsedLINQExamples.MaxMarksOfStudent();
            PrintStudentProperty(maxMarks);

            Console.WriteLine("\n ## Min() ##");
            var minMarks = FrequentlyUsedLINQExamples.MinMarksOfStudent();
            PrintStudentProperty(minMarks);

            Console.WriteLine("\n ## Average() ##");
            var averageStudentMark = FrequentlyUsedLINQExamples.AverageMarksOfStudent();
            Console.WriteLine("Average Marks : {0} ", averageStudentMark);

            Console.WriteLine("\n ## First() ##");
            var firstStudent = FrequentlyUsedLINQExamples.FirstStudentOccurence();
            PrintStudentObject(firstStudent);

            Console.WriteLine("\n ## FirstOrDefault() ##");
            var firstOrDefaultStudent = FrequentlyUsedLINQExamples.FirstOrDefaultStudentOccurence();
            PrintStudentObject(firstOrDefaultStudent);

            Console.WriteLine("\n ## Single() ##");
            var singleStudent = FrequentlyUsedLINQExamples.SingleStudentOccurence();
            PrintStudentObject(singleStudent);

            Console.WriteLine("\n ## SingleOrDefault() ##");
            var singleOrDefaultStudent = FrequentlyUsedLINQExamples.SingleOrDefaultStudentOccurence();
            PrintStudentObject(singleOrDefaultStudent);
        }

        static void PrintStudentList(List<Student> students)
        {
            foreach(var student in students)
                Console.WriteLine("Student name: {0} ", student.StudentName);
        }

        static void PrintBoolStatus(bool result)
        {
            Console.WriteLine("Result: {0} ", result);
        }

        static void PrintStudentObject(Student student)
        {
            Console.WriteLine("Student name: {0} ", student.StudentName);
        }

        static void PrintStudentProperty(int value)
        {
            Console.WriteLine("Attribute value: {0} ", value);
        }
    }
}
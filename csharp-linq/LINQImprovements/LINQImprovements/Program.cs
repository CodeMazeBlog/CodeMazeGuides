using System;
using LINQImprovements;

namespace LINQImrpovements
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student("John", "CS", 10),
                new Student("James", "CS", 6),
                new Student("Mike", "IT", 8),
                new Student("Mahesh", "IT", 3),
            };

            //Pages of Students with page size 2
            var studentChunks = students.Chunk(2);
            studentChunks.ToList().ForEach(studentChunk => Console.WriteLine(studentChunk.Count()));

            //Get student with maximum and minimum grades by using maxBy and minBy
            var student1 = students.MaxBy(student => student.Grade);
            Console.WriteLine(student1);

            var student2 = students.MinBy(student => student.Grade);
            Console.WriteLine(student2);

            //Get Default value when element does not exist
            var defaultStudent = new Student(name: "", department: "", grade: -1);

            var firstStudent = students.FirstOrDefault(student => student.Name.Equals("Fake Student"), defaultStudent);
            var lastStudent = students.LastOrDefault(student => student.Name.Equals("Fake Student"), defaultStudent);
            var singleStudent = students.SingleOrDefault(student => student.Name.Equals("Fake Student"), defaultStudent);

            Console.WriteLine(firstStudent);
            Console.WriteLine(lastStudent);
            Console.WriteLine(singleStudent);

            //Index and Range Arguments
            var student = students.ElementAt(^3);
            Console.WriteLine(student);

            var studentsRange = students.Take(1..3);
            PrintEnumerable(studentsRange);

            //Avoid count if count does not exist
            int count = -1;
            var queryableStudents = students.AsQueryable();

            var doesCountExist = queryableStudents.TryGetNonEnumeratedCount(out count);
            Console.WriteLine(doesCountExist);

            //3 Way Zip
            var names = new List<string>() { "John", "James", "Mike" };
            var departments = new List<string>() { "CS", "AP", "IT" };
            var grades = new List<int>() { 10, 6, 8 };

            var enumeratedList = names.Zip(departments, grades);
            PrintEnumerable(enumeratedList);

            //Set operations
            var distinctStudents = students.DistinctBy(student => student.Department);
            PrintEnumerable(distinctStudents);

            var studentNames = new List<string>()
            {
                "Ross", "Stokes", "James", "Mike"
            };

            var unCommonStudents = names.ExceptBy(studentNames, student => student);
            PrintEnumerable(unCommonStudents);

            var commonStudents = names.IntersectBy(studentNames, student => student);
            PrintEnumerable(commonStudents);

            var allStudents = names.UnionBy(studentNames, student => student);
            PrintEnumerable(allStudents);
        }

        public static void PrintEnumerable<T>(IEnumerable<T> students)
        {
            students.ToList().ForEach(student => Console.WriteLine(student));
        }
    }
}

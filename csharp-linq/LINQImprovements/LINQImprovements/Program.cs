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
            var studentChunks = LINQUtils.Chunk(2);
            foreach(var studentChunk in studentChunks)
            {
                Console.WriteLine(studentChunk.Count());
            }

            //Get students with maximum and minimum grades by using maxBy and minBy
            var maxStudent = LINQUtils.MaxGrade();
            Console.WriteLine(maxStudent);

            var minStudent = LINQUtils.MinGrade();
            Console.WriteLine(minStudent);

            //Get Default value when the element does not exist
            var firstStudent = LINQUtils.FirstOrDefaultStudent();
            var lastStudent = LINQUtils.LastOrDefaultStudent();
            var singleStudent = LINQUtils.SingleOrDefaultStudent();

            Console.WriteLine(firstStudent);
            Console.WriteLine(lastStudent);
            Console.WriteLine(singleStudent);

            //Index and Range Arguments
            var student = LINQUtils.ElementAt(^3);
            Console.WriteLine(student);

            var studentsRange = LINQUtils.Take(1..3);
            PrintEnumerable(studentsRange);

            //Avoid count if the count does not exist
            int count = -1;

            var doesCountExist = LINQUtils.CountStudents(out count);
            Console.WriteLine(doesCountExist);

            //3 Way Zip
            var names = new List<string>() { "John", "James", "Mike" };
            var departments = new List<string>() { "CS", "AP", "IT" };
            var grades = new List<int>() { 10, 6, 8 };

            var enumeratedList = LINQUtils.ZipEnumerables(names, departments, grades);
            PrintEnumerable(enumeratedList);

            //Set operations
            var distinctStudents = LINQUtils.DistinctDepartmentStudents();
            PrintEnumerable(distinctStudents);

            var studentNames = new List<string>(){ "Ross", "Stokes", "James", "Mike" };

            var unCommonStudents = LINQUtils.ExceptBy(names, studentNames);
            PrintEnumerable(unCommonStudents);

            var commonStudents = LINQUtils.IntersectBy(names, studentNames);
            PrintEnumerable(commonStudents);

            var allStudents = LINQUtils.UnionBy(names, studentNames);
            PrintEnumerable(allStudents);
        }

        public static void PrintEnumerable<T>(IEnumerable<T> students)
        {
            foreach(var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}

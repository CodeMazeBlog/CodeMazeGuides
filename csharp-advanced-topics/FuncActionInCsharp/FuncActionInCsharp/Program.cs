using System;
using System.Collections.Generic;

namespace FuncActionInCsharp
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public List<string> MessageBox { get; set; }

        public Student(string firstName, string lastName, int yearOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
            MessageBox = new List<string>();
        }
    }
    public class StudentRegistry
    {
        public List<Student> Students;

        public StudentRegistry()
        {
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public StudentRegistry Where(Func<Student, bool> criteria)
        {
            StudentRegistry StudentsFound = new StudentRegistry();
            foreach (var student in Students)
            {
                if (criteria(student))
                    StudentsFound.AddStudent(student);
            }
            return StudentsFound;
        }

        public void ForEach(Action<Student> actionForStudent)
        {
            foreach (var student in Students)
            {
                actionForStudent(student);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentRegistry registry = new StudentRegistry();
            registry.AddStudent(new Student("John", "Doe", 1997));
            registry.AddStudent(new Student("Jim", "Beam", 2001));
            registry.AddStudent(new Student("John", "Walker", 2000));
            registry.AddStudent(new Student("William", "Lawson", 1999));

            StudentRegistry newMilleniumStudents = registry.Where((student) => { return (student.YearOfBirth >= 2000); });

            newMilleniumStudents.ForEach((student) => { student.MessageBox.Add("hello"); });

            registry
                .Where((student) => { return (student.YearOfBirth < 2000); })
                .ForEach((student) => { student.MessageBox.Add("hello"); });
        }
    }
}

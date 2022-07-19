using System;

namespace LINQImprovements
{
	public class Student
	{
		public string Name { get; set; }
		public string Department { get; set; }
		public int Grade { get; set; }

        public Student(string name, string department, int grade)
        {
            Name = name;
            Department = department;
            Grade = grade;
        }

        public override string? ToString()
        {
            return "Name: " + Name + " Dept: " + Department + " Grade: " + Grade;
        }
    }
}


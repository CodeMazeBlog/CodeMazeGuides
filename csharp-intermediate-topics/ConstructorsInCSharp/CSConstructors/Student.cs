using System;
namespace CSConstructors
{
    public class Student : Person
    {
        public string Department { get; set; }

        public Student(string name, int age, string department) : base(name, age)
        {
            Department = department;
        }

        public void Print()
        {
            base.Display();
            Console.WriteLine("department is:" + Department);
        }
    }
}


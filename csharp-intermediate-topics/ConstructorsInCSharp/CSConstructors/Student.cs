using System;
namespace CSConstructors
{
    public class Student : Person
    {
        private string _department;

        public Student(string name, int age, string department) : base(name, age)
        {
            _department = department;
        }

        public void Print()
        {
            base.Display();
            Console.WriteLine("department is:" + _department);
        }
    }
}


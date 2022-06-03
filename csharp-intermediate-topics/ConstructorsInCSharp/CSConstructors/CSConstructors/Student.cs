using System;
namespace CSConstructors
{
	public class Student: Person
	{
		private string department;

		public Student(string name, int age, string department):base(name, age)
		{
			this.department = department;
		}

		public void print()
		{
			base.display();
			Console.WriteLine("department is:" + department);
		}
	}
}


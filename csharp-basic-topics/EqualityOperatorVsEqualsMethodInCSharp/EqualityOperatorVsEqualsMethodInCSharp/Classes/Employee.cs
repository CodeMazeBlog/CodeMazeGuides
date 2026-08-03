namespace EqualityOperatorVsEqualsMethodInCSharp.Classes
{
    public class Employee
    {
        public string FullName { get; set; }
        public int Salary { get; set; }

        public Employee(string fullName, int salary)
        {
            FullName = fullName;
            Salary = salary;
        }
    }
}

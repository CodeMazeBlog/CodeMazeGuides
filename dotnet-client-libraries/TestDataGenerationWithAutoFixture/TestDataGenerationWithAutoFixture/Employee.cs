namespace TestDataGenerationWithAutoFixture
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public decimal Salary { get; set; }

        public Employee(string firstName, decimal salary)
        {
            FirstName = firstName;
            Salary = salary;
        }

        public Employee(string firstName, string lastName, int age, decimal salary)
            : this(firstName, salary)
        {
            LastName = lastName;
            Age = age;
        }

        public string GetFullName() => $"{FirstName} {LastName}";
    }
}
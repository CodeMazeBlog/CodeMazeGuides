namespace RefactoringDispensables.DeadCode
{
    public class Employee
    {
        public double Salary { get; private set; }

        public void GiveSalaryRaise()
        {
            Salary = Salary * 1.25;
        }

        public void DecreaseSalary()
        {
            Salary = Salary * 0.75;
        }
    }
}

namespace RefactoringDispensables.DeadCode
{
    public class Employee
    {
        public int Salary { get; private set; }

        public void GiveSalaryRaise()
        {
            Salary = Salary * 2;
        }
    }
}

namespace csharp_refactoring.Bloaters.PrimitiveObsession.Correct
{
    public class Administrator : Employee
    {
        public Administrator(string firstName, string lastName)
            : base(firstName, lastName)
        { }

        public override int Type { get { return Employee.Administrator; } }

        public override double GetMonthlyBonus(double monthlySalary)
        {
            return monthlySalary * 0.1;
        }
    }
}

namespace csharp_refactoring.Bloaters.PrimitiveObsession.Correct
{
    public class ContentWriter : Employee
    {
        public ContentWriter(string firstName, string lastName) : base(firstName, lastName)
        { }

        public override int Type { get { return Employee.ContentWriter; } }

        public override double GetMonthlyBonus(double monthlySalary)
        {
            return monthlySalary * 0.05;
        }
    }
}

namespace csharp_refactoring.Bloaters.PrimitiveObsession.Correct
{
    public class Developer : Employee
    {
        public DeveloperSpecialization Specialization { get; set; }

        public Developer(string firstName, string lastName) 
            : base(firstName, lastName)
        { }

        public override int Type { get { return Employee.Developer; } }

        public override double GetMonthlyBonus(double monthlySalary)
        {
            return monthlySalary * 0.15;
        }
    }
}

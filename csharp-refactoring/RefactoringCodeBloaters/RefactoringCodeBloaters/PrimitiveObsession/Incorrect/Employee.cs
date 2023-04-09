namespace RefactoringCodeBloaters.PrimitiveObsession.Incorrect
{
    public class Employee : Person
    {
        public const int Administrator = 0;
        public const int ContentWriter = 1;
        public const int Developer = 2;

        public Employee(string firstName, string lastName, int type)
            : base(firstName, lastName)
        {
            Type = type;
        }

        public int Type { get; private set; }

        public double GetMonthlyBonus(double monthlySalary)
        {
            if (Type == ContentWriter)
            {
                return monthlySalary * 0.05;
            }
            else if (Type == Administrator)
            {
                return monthlySalary * 0.1;
            }
            else
            {
                return monthlySalary * 0.15;
            }
        }
    }
}

namespace RefactoringCodeBloaters.PrimitiveObsession.Correct
{
    public abstract class Employee : Person
    {
        public const int Administrator = 0;
        public const int ContentWriter = 1;
        public const int Developer = 2;

        protected Employee(string firstName, string lastName)
            : base(firstName, lastName)
        { }

        public abstract int Type { get; }
        public abstract double GetMonthlyBonus(double monthlySalary);

        public static Employee Create(string firstName, string lastName, int type)
        {
            return type switch
            {
                Administrator => new Administrator(firstName, lastName),
                ContentWriter => new ContentWriter(firstName, lastName),
                Developer => new Developer(firstName, lastName),
                _ => throw new ArgumentOutOfRangeException($"Incorrect value: {type}")
            };
        }
    }
}

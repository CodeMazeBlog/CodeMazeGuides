namespace RefactoringCodeBloaters.PrimitiveObsession.Correct
{
    public abstract class DeveloperSpecialization
    {
        public const int Frontend = 0;
        public const int Backend = 1;
        public const int FullStack = 2;

        public abstract int Specialization { get; }

        public static DeveloperSpecialization Create(int specialization)
        {
            return specialization switch
            {
                Frontend => new FrontendDeveloper(),
                Backend => new BackendDeveloper(),
                FullStack => new FullstackDeveloper(),
                _ => throw new ArgumentOutOfRangeException($"Incorrect value: {specialization}")
            };
        }
    }
}

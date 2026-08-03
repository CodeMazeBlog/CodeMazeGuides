namespace RefactoringCodeBloaters.PrimitiveObsession.Incorrect
{
    public class User : Person
    {
        public static int Free = 0;
        public static int Family = 1;
        public static int Premium = 2;

        public User(string firstName, string lastName, int subscriptionCode) : base(firstName, lastName)
        {
            SubscriptionCode = subscriptionCode;
        }

        public int SubscriptionCode { get; private set; }
    }
}

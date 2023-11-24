namespace RefactoringCodeBloaters.PrimitiveObsession.Correct
{
    public class User : Person
    {
        public User(string firstName, string lastName, Subscription subscription) : base(firstName, lastName)
        {
            Subscription = subscription;
        }

        public Subscription Subscription { get; private set; }
    }
}
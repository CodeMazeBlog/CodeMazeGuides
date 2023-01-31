namespace RefactoringCodeBloaters.PrimitiveObsession.Correct
{
    public class Subscription
    {
        public static Subscription Free = new(0);
        public static Subscription Family = new(1);
        public static Subscription Premium = new(2);

        private int Code { get; }

        private Subscription(int code)
        {
            Code = code;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            return Code == ((Subscription)obj).Code;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}

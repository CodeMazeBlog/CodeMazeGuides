namespace IntroductionToDelegates
{
    public class Program
    {
        delegate string SaySomething();

        public static string SayHi() { return "Hi!"; }

        static void Main(string[] args)
            => InvokeSayHiWithDelegate();

        public static string InvokeSayHiWithDelegate()
        {
            SaySomething methodSayHi = SayHi;
            return methodSayHi.Invoke();
        }
    }
}

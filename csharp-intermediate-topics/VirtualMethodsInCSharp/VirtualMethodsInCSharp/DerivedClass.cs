namespace VirtualMethodsInCSharp
{
    public class DerivedClass : BaseClass
    {
        public override string IntroduceYourSelf()
        {
            return "I am the derived class!";
        }

        public override string IntroduceBaseClass()
        {
            Console.WriteLine("I will call the base class introduction, but before I will execute some code.");
            return base.IntroduceBaseClass();
        }

        public new string IntroduceYourSelfForNewKeyword()
        {
            return "I am the derived class!";
        }

        public override sealed string IntroduceYourSelfForSealedKeyword()
        {
            return "I am the derived class!";
        }
    }
}
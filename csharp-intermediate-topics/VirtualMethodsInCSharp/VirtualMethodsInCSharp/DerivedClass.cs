namespace VirtualMethodsInCSharp
{
    public class DerivedClass : BaseClass
    {
        public override string IntroduceYourSelf()
        {
            return "Derived class's IntroduceYourSelf method.";
        }

        public string CallBaseClassIntroduction()
        {
            Console.WriteLine("I will call the base class introduction, but before I will execute some code.");
            return base.IntroduceBaseClass();
        }

        public new static string IntroduceYourSelfForNewKeyword()
        {
            return "Derived class's IntroduceYourSelfForNewKeyword method.";
        }

        public override sealed string IntroduceYourSelfForSealedKeyword()
        {
            return "Derived class's IntroduceYourSelfForSealedKeyword method.";
        }
    }
}
namespace VirtualMethodsInCSharp
{
    public class BaseClass
    {
        public virtual string IntroduceYourSelf()
        {
            return "Base class's IntroduceYourSelf method.";
        }

        public virtual string IntroduceBaseClass()
        {
            return "Base class's IntroduceBaseClass method.";
        }

        public static string IntroduceYourSelfForNewKeyword()
        {
            return "Base class's IntroduceYourSelfForNewKeyword method.";
        }

        public virtual string IntroduceYourSelfForSealedKeyword()
        {
            return "Base class's IntroduceYourSelfForSealedKeyword method.";
        }
    }
}
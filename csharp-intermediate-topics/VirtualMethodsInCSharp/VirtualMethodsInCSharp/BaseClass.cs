namespace VirtualMethodsInCSharp
{
    public class BaseClass
    {
        public virtual string IntroduceYourSelf()
        {
            return "I am the base class!";
        }

        public virtual string IntroduceBaseClass()
        {
            return "I am the base class!";
        }

        public virtual string IntroduceYourSelfNotOverriden()
        {
            return "I am the base class!";
        }

        public virtual string IntroduceYourSelfForNewKeyword()
        {
            return "I am the base class!";
        }

        public virtual string IntroduceYourSelfForSealedKeyword()
        {
            return "I am the base class!";
        }
    }
}
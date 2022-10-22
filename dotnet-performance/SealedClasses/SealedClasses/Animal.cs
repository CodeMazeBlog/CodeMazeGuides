namespace SealedClasses
{
    public class Animal
    {
        public virtual void DoNothing() { }
        public virtual int GetAge() => -1;
        public static string Walk() => "I'm walking..";
    }
}

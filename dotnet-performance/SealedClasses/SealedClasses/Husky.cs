namespace SealedClasses
{
    public sealed class Husky : Animal
    {
        public override void DoNothing() { }
        public override int GetAge() => 11;
    }
}

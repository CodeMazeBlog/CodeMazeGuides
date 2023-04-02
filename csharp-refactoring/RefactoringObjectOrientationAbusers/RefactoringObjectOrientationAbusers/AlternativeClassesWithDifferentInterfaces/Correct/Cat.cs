namespace RefactoringObjectOrientationAbusers.AlternativeClassesWithDifferentInterfaces.Correct
{
    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} meows.");
        }
    }
}

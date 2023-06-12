namespace RefactoringObjectOrientationAbusers.AlternativeClassesWithDifferentInterfaces.Correct
{
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} barks.");
        }
    }
}

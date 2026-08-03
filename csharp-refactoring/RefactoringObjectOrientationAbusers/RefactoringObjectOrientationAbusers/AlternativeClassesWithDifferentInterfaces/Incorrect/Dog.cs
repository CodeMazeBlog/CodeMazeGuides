namespace RefactoringObjectOrientationAbusers.AlternativeClassesWithDifferentInterfaces.Incorrect
{
    public class Dog
    {
        public string Name { get; set; }

        public void Bark()
        {
            Console.WriteLine($"{Name} makes a sound.");
        }
    }
}

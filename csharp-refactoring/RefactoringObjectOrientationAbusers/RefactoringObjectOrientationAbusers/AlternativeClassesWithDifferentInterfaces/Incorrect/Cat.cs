namespace RefactoringObjectOrientationAbusers.AlternativeClassesWithDifferentInterfaces.Incorrect
{
    public class Cat
    {
        public string Name { get; set; }

        public void Meow()
        {
            Console.WriteLine($"{Name} makes a sound.");
        }
    }
}

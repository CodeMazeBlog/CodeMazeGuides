namespace RefactoringDispensables.DuplicatedCode.Correct
{
    public abstract class Animal
    {
        public ICollection<string> Toys { get; set; }

        public string GetToysAsString()
            => Toys.ToCommaSeparatedString();
    }
}

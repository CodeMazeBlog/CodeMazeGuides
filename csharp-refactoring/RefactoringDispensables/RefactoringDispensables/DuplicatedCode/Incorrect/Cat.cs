namespace RefactoringDispensables.DuplicatedCode.Incorrect
{
    public class Cat
    {
        public ICollection<string> Toys { get; set; }

        public string GatherStrings()
            => string.Join(',', Toys);
    }
}

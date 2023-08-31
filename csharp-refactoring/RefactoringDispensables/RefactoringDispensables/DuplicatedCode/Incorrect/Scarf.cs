namespace RefactoringDispensables.DuplicatedCode.Incorrect
{
    public class Scarf
    {
        public ICollection<string> Materials { get; set; }

        public Scarf(ICollection<string> materials)
        {
            Materials = materials;
        }

        public string GatherStrings()
            => string.Join(',', Materials);
    }
}

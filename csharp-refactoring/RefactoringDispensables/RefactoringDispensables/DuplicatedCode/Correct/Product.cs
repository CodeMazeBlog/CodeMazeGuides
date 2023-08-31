namespace RefactoringDispensables.DuplicatedCode.Correct
{
    public abstract class Product
    {
        public ICollection<string> Materials { get; set; }

        protected Product(ICollection<string> materials)
        {
            Materials = materials;
        }

        public string GetMaterialsAsString()
            => Materials.ToCommaSeparatedString();
    }
}

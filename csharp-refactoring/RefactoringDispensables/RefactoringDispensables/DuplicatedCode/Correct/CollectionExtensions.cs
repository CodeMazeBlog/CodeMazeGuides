namespace RefactoringDispensables.DuplicatedCode.Correct
{
    public static class CollectionExtensions
    {
        public static string ToCommaSeparatedString(this ICollection<string> array) 
            => string.Join(',', array);
    }
}

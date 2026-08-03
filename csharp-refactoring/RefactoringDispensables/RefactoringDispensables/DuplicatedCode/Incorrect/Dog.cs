using System.Text;

namespace RefactoringDispensables.DuplicatedCode.Incorrect
{
    public class Dog
    {
        public ICollection<string> Toys { get; set; }

        public string CompileToys()
            => string.Join(',', Toys);
    }
}

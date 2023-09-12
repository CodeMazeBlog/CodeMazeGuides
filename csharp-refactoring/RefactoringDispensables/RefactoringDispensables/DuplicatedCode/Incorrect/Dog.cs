using System.Text;

namespace RefactoringDispensables.DuplicatedCode.Incorrect
{
    public class Dog
    {
        public ICollection<string> Toys { get; set; }

        public string CompileToys()
        {
            var toys = Toys.ToArray();
            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < toys.Length; i++)
            {
                resultBuilder.Append(toys[i]);

                if (i < toys.Length - 1)
                {
                    resultBuilder.Append(',');
                }
            }

            return resultBuilder.ToString();
        }
    }
}

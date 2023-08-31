using System.Text;

namespace RefactoringDispensables.DuplicatedCode.Incorrect
{
    public class Jacket
    {
        public ICollection<string> Materials { get; set; }

        public Jacket(ICollection<string> materials)
        {
            Materials = materials;
        }

        public string CompileMaterials()
        {
            var materials = Materials.ToArray();
            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < materials.Length; i++)
            {
                resultBuilder.Append(materials[i]);

                if (i < materials.Length - 1)
                {
                    resultBuilder.Append(',');
                }
            }

            return resultBuilder.ToString();
        }
    }
}

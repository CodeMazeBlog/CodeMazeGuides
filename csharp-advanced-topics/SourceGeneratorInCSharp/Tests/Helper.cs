using Generator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Tests
{
    public static class Helper
    {
        public static string GetGeneratedOutput(string sourceCode)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            var references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => !assembly.IsDynamic)
                .Select(assembly => MetadataReference.CreateFromFile(assembly.Location))
                .Cast<MetadataReference>();

            var compilation = CSharpCompilation.Create("SourceGeneratorTests",
                new[] { syntaxTree },
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            // Source Generator to test
            var generator = new ServiceGenerator();

            CSharpGeneratorDriver.Create(generator)
                .RunGeneratorsAndUpdateCompilation(compilation, out var outputCompilation, out var diagnostics);

            return outputCompilation.SyntaxTrees.Skip(1).LastOrDefault()?.ToString();
        }
    }
}

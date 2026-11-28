using Generator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Tests
{
    public static class Helper
    {
        public static CSharpCompilation CreateCompilation(string sourceCode)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            var references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => !assembly.IsDynamic)
                .Select(assembly => MetadataReference.CreateFromFile(assembly.Location));

            return CSharpCompilation.Create("SourceGeneratorTests",
                [syntaxTree],
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }

        public static GeneratorRunResult RunGenerator(string sourceCode)
        {
            GeneratorDriver driver = CSharpGeneratorDriver.Create(new ServiceGenerator());

            driver = driver.RunGenerators(CreateCompilation(sourceCode));

            return driver.GetRunResult().Results.Single();
        }

        public static string? GetGeneratedOutput(string sourceCode, string hintName)
        {
            return RunGenerator(sourceCode).GeneratedSources
                .SingleOrDefault(source => source.HintName == hintName)
                .SourceText?.ToString();
        }
    }
}

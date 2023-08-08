using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Text;

namespace Generator
{
    [Generator]
    public sealed class ExampleGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var callingEntrypoint = context.Compilation.GetEntryPoint(context.CancellationToken);

            var sourceText = $$"""
                namespace {{callingEntrypoint.ContainingNamespace.Name}}
                {
                    public static class HelloWorld
                    {
                        public static void SayHello()
                        {
                            Console.WriteLine("Hello From Generator");
                        }
                    }
                }
                """;

            context.AddSource("ExampleGenerator.g", SourceText.From(sourceText, Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}
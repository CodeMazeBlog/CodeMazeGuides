using Generator.Diagnostics;
using Generator.Helper;
using Generator.SyntaxReceiver;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Scriban;
using System.IO;
using System.Text;

namespace Generator
{
    [Generator]
    public sealed class ServiceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForPostInitialization(ctx => ctx.AddSource(
                "GenerateServiceAttribute.g.cs",
                SourceText.From(SourceGenerationHelper.Attribute, Encoding.UTF8)));

            context.RegisterForSyntaxNotifications(() =>
                new GenerateServiceAttributeSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not GenerateServiceAttributeSyntaxReceiver syntaxReceiver)
            {
                return;
            }

            foreach (var classSyntax in syntaxReceiver.Classes)
            {
                // Converting the class to semantic model to access much more meaningful data.
                var model = context.Compilation.GetSemanticModel(classSyntax.SyntaxTree);

                // Parse to declared symbol, so you can access each part of code separately,
                // such as interfaces, methods, members, contructor parameters etc.
                var symbol = model.GetDeclaredSymbol(classSyntax);

                var className = symbol.Name;

                if (!className.Contains("Model"))
                {
                    var error = Diagnostic.Create(DiagnosticsDescriptors.ClassWithWrongNameMessage,
                        classSyntax.Identifier.GetLocation(),
                        className);

                    context.ReportDiagnostic(error);

                    return;
                }

                var classNamespace = symbol.ContainingNamespace?.ToDisplayString();

                var classAssembly = symbol.ContainingAssembly?.Name;

                // Get the template string
                var text = GetEmbededResource("Generator.Templates.Service.scriban");

                var template = Template.Parse(text);

                var sourceCode = template.Render(new { ClassName = className, ClassNamespace = classNamespace, ClassAssembly = classAssembly });

                context.AddSource(
                    $"{className}{"Service"}.g.cs",
                    SourceText.From(sourceCode, Encoding.UTF8)
                );
            }
        }

        private string GetEmbededResource(string path)
        {
            using var stream = GetType().Assembly.GetManifestResourceStream(path);

            using var streamReader = new StreamReader(stream);

            return streamReader.ReadToEnd();
        }
    }
}

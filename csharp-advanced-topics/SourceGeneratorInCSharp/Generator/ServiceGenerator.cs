using Generator.Diagnostics;
using Generator.Helper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Scriban;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace Generator
{
    [Generator]
    public sealed class ServiceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(
                "GenerateServiceAttribute.g.cs",
                SourceText.From(SourceGenerationHelper.Attribute, Encoding.UTF8)));

            IncrementalValuesProvider<ClassDeclarationSyntax> enumDeclarations = context.SyntaxProvider
              .CreateSyntaxProvider(
                  predicate: static (s, _) => IsSyntaxTargetForGeneration(s),
                  transform: static (ctx, _) => GetTargetForGeneration(ctx));

            IncrementalValueProvider<(Compilation, ImmutableArray<ClassDeclarationSyntax>)> compilationAndEnums
                 = context.CompilationProvider.Combine(enumDeclarations.Collect());

            context.RegisterSourceOutput(compilationAndEnums,
                (spc, source) => Execute(source.Item1, source.Item2, spc));
        }

        public static bool IsSyntaxTargetForGeneration(SyntaxNode syntaxNode)
        {
            return syntaxNode is ClassDeclarationSyntax classDeclarationSyntax &&
                classDeclarationSyntax.AttributeLists.Count > 0 &&
                classDeclarationSyntax.AttributeLists
                    .Any(al => al.Attributes
                        .Any(a => a.Name.ToString() == "GenerateService"));
        }

        public static ClassDeclarationSyntax GetTargetForGeneration(GeneratorSyntaxContext context)
        {
            var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;

            return classDeclarationSyntax;
        }
        public void Execute(Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes, SourceProductionContext context)
        {
            foreach (var classSyntax in classes)
            {
                // Converting the class to a semantic model to access much more meaningful data.
                var model = compilation.GetSemanticModel(classSyntax.SyntaxTree);

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

                var sourceCode = template.Render(new { 
                    ClassName = className, 
                    ClassNamespace = classNamespace, 
                    ClassAssembly = classAssembly 
                });

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

using Generator.Diagnostics;
using Generator.Helper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Scriban;
using System.IO;
using System.Text;

namespace Generator
{
    [Generator]
    public sealed class ServiceGenerator : IIncrementalGenerator
    {
        private static readonly Template ServiceTemplate =
            Template.Parse(GetEmbeddedResource("Generator.Templates.Service.scriban"));

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(ctx =>
            {
                ctx.AddEmbeddedAttributeDefinition();
                ctx.AddSource(
                    "GenerateServiceAttribute.g.cs",
                    SourceText.From(SourceGenerationHelper.Attribute, Encoding.UTF8));
            });

            IncrementalValuesProvider<ServiceModel> models = context.SyntaxProvider
                .ForAttributeWithMetadataName(
                    "Generator.GenerateServiceAttribute",
                    predicate: static (node, _) => IsSyntaxTargetForGeneration(node),
                    transform: static (ctx, _) => GetTargetForGeneration(ctx));

            context.RegisterSourceOutput(models,
                static (spc, model) => Execute(model, spc));
        }

        public static bool IsSyntaxTargetForGeneration(SyntaxNode syntaxNode)
            => syntaxNode is ClassDeclarationSyntax;

        public static ServiceModel GetTargetForGeneration(GeneratorAttributeSyntaxContext context)
        {
            var symbol = context.TargetSymbol;
            var location = context.TargetNode is ClassDeclarationSyntax classSyntax
                ? classSyntax.Identifier.GetLocation()
                : symbol.Locations[0];

            return new ServiceModel(
                ClassName: symbol.Name,
                ClassNamespace: symbol.ContainingNamespace.ToDisplayString(),
                ClassAssembly: symbol.ContainingAssembly.Name,
                Location: LocationInfo.From(location));
        }

        public static void Execute(ServiceModel model, SourceProductionContext context)
        {
            if (!model.ClassName.Contains("Model"))
            {
                var error = Diagnostic.Create(DiagnosticsDescriptors.ClassWithWrongNameMessage,
                    model.Location.ToLocation(),
                    model.ClassName);

                context.ReportDiagnostic(error);

                return;
            }

            var sourceCode = ServiceTemplate.Render(new
            {
                model.ClassName,
                model.ClassNamespace,
                model.ClassAssembly
            });

            context.AddSource(
                $"{model.ClassName}Service.g.cs",
                SourceText.From(sourceCode, Encoding.UTF8));
        }

        private static string GetEmbeddedResource(string path)
        {
            using var stream = typeof(ServiceGenerator).Assembly.GetManifestResourceStream(path)!;
            using var streamReader = new StreamReader(stream);

            return streamReader.ReadToEnd();
        }
    }

    public readonly record struct ServiceModel(
        string ClassName,
        string ClassNamespace,
        string ClassAssembly,
        LocationInfo Location);

    public readonly record struct LocationInfo(string FilePath, TextSpan Span, LinePositionSpan LineSpan)
    {
        public Location ToLocation() => Location.Create(FilePath, Span, LineSpan);

        public static LocationInfo From(Location location)
            => new(location.SourceTree?.FilePath ?? string.Empty,
                location.SourceSpan,
                location.GetLineSpan().Span);
    }
}

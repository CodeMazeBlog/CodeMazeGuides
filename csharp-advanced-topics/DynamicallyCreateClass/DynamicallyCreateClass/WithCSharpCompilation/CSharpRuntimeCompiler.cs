using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace WithCSharpCompilation;

public class CSharpRuntimeCompiler
{
    private readonly string _assemblyName;
    private readonly Assembly _assembly;

    public CSharpRuntimeCompiler(string code, params MetadataReference[] references)
        : this("testing_for_dynamic", code, references) { }

    public CSharpRuntimeCompiler(
        string assemblyName,
        string code,
        params MetadataReference[] references
    )
    {
        _assemblyName = assemblyName;
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

        CSharpCompilation compilation = CSharpCompilation
            .Create(assemblyName)
            .AddSyntaxTrees(syntaxTree)
            .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
            .AddReferences(Basic.Reference.Assemblies.Net60.All.Concat(references));

        using (var ms = new MemoryStream())
        {
            EmitResult result = compilation.Emit(ms);

            if (!result.Success)
            {
                IEnumerable<Diagnostic> failures = result.Diagnostics.Where(
                    diagnostic =>
                        diagnostic.IsWarningAsError
                        || diagnostic.Severity == DiagnosticSeverity.Error
                );

                var messages = string.Join(
                    Environment.NewLine,
                    failures.Select(f => f.GetMessage())
                );
                throw new AggregateException(messages);
            }
            else
            {
                ms.Seek(0, SeekOrigin.Begin);
                _assembly = Assembly.Load(ms.ToArray());
            }
        }
    }

    public dynamic? GetInstance(string fqClassName)
    {
        return _assembly.CreateInstance(fqClassName);
    }
}

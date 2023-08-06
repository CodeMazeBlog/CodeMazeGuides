using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Generator.SyntaxReceiver
{
    public class GenerateServiceAttributeSyntaxReceiver : ISyntaxReceiver
    {
        public IList<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax &&
                classDeclarationSyntax.AttributeLists.Count > 0 &&
                classDeclarationSyntax.AttributeLists
                    .Any(al => al.Attributes
                        .Any(a => a.Name.ToString() == "GenerateService")))
            {
                Classes.Add(classDeclarationSyntax);
            }
        }
    }
}

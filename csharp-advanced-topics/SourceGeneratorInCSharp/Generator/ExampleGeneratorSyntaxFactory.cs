using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace Generator
{
    [Generator]
    public sealed class ExampleGeneratorSyntaxFactory : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(ctx => 
            {
                var classBlock = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("SourceGeneratorInCSharp"))
                    .AddMembers(
                        SyntaxFactory.ClassDeclaration("SyntaxFactoryHelloWorld")
                        .AddModifiers(
                            SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                            SyntaxFactory.Token(SyntaxKind.StaticKeyword)
                        )
                        .AddMembers(
                            SyntaxFactory.MethodDeclaration(
                                SyntaxFactory.ParseTypeName("void"),
                                "SayHello"
                            )
                            .AddModifiers(
                                SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                                SyntaxFactory.Token(SyntaxKind.StaticKeyword)
                            )
                            .AddBodyStatements(
                                SyntaxFactory.ExpressionStatement(
                                    SyntaxFactory.InvocationExpression(
                                        SyntaxFactory.MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            SyntaxFactory.IdentifierName("Console"),
                                            SyntaxFactory.IdentifierName("WriteLine")
                                        ))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList()
                                                .AddArguments(
                                                    SyntaxFactory.Argument(
                                                        SyntaxFactory.LiteralExpression(
                                                            SyntaxKind.StringLiteralExpression,
                                                            SyntaxFactory.Literal("Hello From Generator")
                                                        )
                                                    )
                                                )
                                        )
                                )
                            )
                        )
                    ).NormalizeWhitespace();

                ctx.AddSource("ExampleGeneratorSyntaxFactory.g",
                    SourceText.From(classBlock.ToFullString(), Encoding.UTF8));
            });
        }
    }
}

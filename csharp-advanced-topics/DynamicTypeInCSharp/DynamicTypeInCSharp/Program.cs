using DynamicTypeInCSharp;
using Microsoft.CSharp.RuntimeBinder;

Run(Examples.ExampleDeclaration);
Run(Examples.ExampleDynamicWithException);
Run(Examples.ExampleMissingMethodDefinitionException);
Run(() => Examples.ExampleReflection());
Run(() => Examples.ExampleDynamic());
Run(Examples.ExampleVarObjectDynamic);
Run(() => Examples.ExamplePrintCount(new int[20]));

static void Run(Action example)
{
    try
    {
        example();
    }
    catch (RuntimeBinderException ex)
    {
        Console.WriteLine($"{ex.GetType().FullName}: {ex.Message}");
    }

    Console.WriteLine();
}

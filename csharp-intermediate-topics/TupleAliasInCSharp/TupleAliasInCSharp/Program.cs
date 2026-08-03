using TupleAliasInCSharp.GlobalAliasUsing;
using TupleAliasInCSharp;

Console.Title = "Alias for Tuples in C#";

Console.WriteLine("Alias for tuple usage in same namespace");
TupleAlias.PrintTupleValues();

Console.WriteLine("\nAlias for tuple usage in different namespace");
GlobalAliasUsing.PrintTupleWithGlobalUsing();

Console.ReadKey();

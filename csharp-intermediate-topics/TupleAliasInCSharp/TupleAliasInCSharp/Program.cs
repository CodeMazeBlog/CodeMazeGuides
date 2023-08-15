using TupleAliasInCSharp.GlobalAlias;
using TupleAliasInCSharp;

Console.WriteLine("Alias for Tuples in C# \n");

Console.WriteLine("Alias for tuple usage in same namespace");
TupleAlias.PrintTupleValues();

Console.WriteLine("Alias for tuple usage in different namespace");
GlobalAlias.PrintTupleWithGlobalUsing();

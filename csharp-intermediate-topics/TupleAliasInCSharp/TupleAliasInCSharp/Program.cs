global using tupleAliasGlobalUsing = (int num1, string str, int num2);
global using System;
using TupleAliasInCSharp;
using TupleAliasInCSharp.GlobalAlias;

Console.WriteLine("Alias for Tuples in C# \n");

Console.WriteLine("Alias for tuple usage in same namespace");
TupleAlias.PrintTupleValues();

Console.WriteLine("Alias for tuple usage in different namespace");
GlobalAlias.PrintTupleWithGlobalUsing();


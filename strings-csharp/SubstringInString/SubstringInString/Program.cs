using BenchmarkDotNet.Running;
using System.Text.RegularExpressions;

var str = "Lorem ipsum dolor sit amet, consectetur adipiscing elip. Duis quis nisip eget sem vehipula accumsan";
var toFind = "ip";
var regex = new Regex(toFind, RegexOptions.Compiled); 

var searchResults = SubstringSearchMethods.FindAllIndexesWithSubstring(str, toFind);
SubstringSearchMethods.PrintResult(searchResults);

SubstringSearchMethods.FindAllIndexesWithSpan(str, toFind);

SubstringSearchMethods.FindAllIndexesWithIndexOf(str, toFind);

SubstringSearchMethods.FindAllIndexesWithRegex(str, regex);

SubstringSearchMethods.FindAllIndexesWithLINQ(str, toFind);

SubstringSearchMethods.FindAllIndexesWithSplit(str, toFind);

BenchmarkRunner.Run<Benchmarking>();



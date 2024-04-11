using BenchmarkDotNet.Running;
using System.Text.RegularExpressions;

var str = "Lorem ipsum dolor sit amet, consectetur adipiscing elip. Duis quis nisip eget sem vehipula accumsan";
var toFind = "ip";
var pattern = @"ip";
var regex = new Regex(pattern); 

var searchResults = SubstringSearchMethods.FindAllIndexesWithSubstring(str, toFind);
SubstringSearchMethods.PrintResult(searchResults);

SubstringSearchMethods.FindAllIndexesWithSpan(str, toFind);
SubstringSearchMethods.PrintResult(searchResults);

SubstringSearchMethods.FindAllIndexesWithIndexOf(str, toFind);
SubstringSearchMethods.PrintResult(searchResults);

SubstringSearchMethods.FindAllIndexesWithRegex(str, regex);
SubstringSearchMethods.PrintResult(searchResults);

SubstringSearchMethods.FindAllIndexesWithLINQ(str, toFind);
SubstringSearchMethods.PrintResult(searchResults);

SubstringSearchMethods.FindAllIndexesWithSplit(str, toFind);
SubstringSearchMethods.PrintResult(searchResults);

BenchmarkRunner.Run<Benchmarking>();



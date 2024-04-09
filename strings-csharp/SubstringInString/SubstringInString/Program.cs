using BenchmarkDotNet.Running;

var str = "Lorem ipsum dolor sit amet, consectetur adipiscing elip. Duis quis nisip eget sem vehipula accumsan";
var toFind = "ip";

var searchResults = SubstringSearchMethods.FindAllIndexesWithSubstring(str, toFind);
SubstringSearchMethods.PrintResult(searchResults);

SubstringSearchMethods.FindAllIndexesWithSpan(str, toFind);

SubstringSearchMethods.FindAllIndexesWithIndexOf(str, toFind);

SubstringSearchMethods.FindAllIndexesWithRegex(str, toFind);

SubstringSearchMethods.FindAllIndexesWithLINQ(str, toFind);

SubstringSearchMethods.FindAllIndexesWithSplit(str, toFind);

BenchmarkRunner.Run<Benchmarking>();



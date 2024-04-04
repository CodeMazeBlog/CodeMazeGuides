using BenchmarkDotNet.Running;

var str = "Lorem ipsum dolor sit amet, consectetur adipiscing elip. Duis quis nisip eget sem vehipula accumsan";
var toFind = "ip";

var searchResults = SubstringSearchMethods.FindAllIndexesWithSubstring(str, toFind);
SubstringSearchMethods.PrintResult(searchResults);

var spanResults = SubstringSearchMethods.FindAllIndexesWithSpan(str, toFind);
SubstringSearchMethods.PrintResult(spanResults);

var indexOfResults = SubstringSearchMethods.FindAllIndexesWithIndexOf(str, toFind);
SubstringSearchMethods.PrintResult(indexOfResults);

var regexResults = SubstringSearchMethods.FindAllIndexesWithRegex(str, toFind);
SubstringSearchMethods.PrintResult(regexResults);

var linqResults = SubstringSearchMethods.FindAllIndexesWithLINQ(str, toFind);
SubstringSearchMethods.PrintResult(linqResults);

var splitResults = SubstringSearchMethods.FindAllIndexesWithSplit(str, toFind);
SubstringSearchMethods.PrintResult(splitResults);

var summary = BenchmarkRunner.Run<Benchmark>();

// Output summary
Console.WriteLine(summary);


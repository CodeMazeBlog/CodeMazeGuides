using SortedSetInCSharp;

var sortedSet = new SortedSetMethods();
var programmingLanguages = sortedSet.ProgrammingLanguages();

Console.WriteLine("The SortedSet Contains these elements:");

foreach (var language in programmingLanguages) 
{
    Console.WriteLine(language);
}
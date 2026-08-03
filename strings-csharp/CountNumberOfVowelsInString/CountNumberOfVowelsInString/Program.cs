using System.Buffers;
using BenchmarkDotNet.Running;
using CountNumberOfVowelsInString;

const string vowels = "AEIOUaeiou";
var vowelsAsSpan = vowels.AsSpan();
var vowelsHash = new HashSet<char>(vowels);
SearchValues<char> vowelsSearchValues = SearchValues.Create(vowelsAsSpan);

const string sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.";
var sentenceAsSpan = sentence.AsSpan();

Console.WriteLine(sentence);

Console.WriteLine($"The number of vowels counted using For loop is: {VowelCounters.CountVowelsUsingForLoop(sentenceAsSpan, vowelsAsSpan)}");
Console.WriteLine($"The number of vowels counted using ForEach loop is: {VowelCounters.CountVowelsUsingForEachLoop(sentenceAsSpan, vowelsAsSpan)}");
Console.WriteLine($"The number of vowels counted using SearchValues is: {VowelCounters.CountVowelsUsingSearchValues(sentenceAsSpan, vowelsSearchValues)}");
Console.WriteLine($"The number of vowels counted using Switch statement is: {VowelCounters.CountVowelsUsingSwitchStatement(sentenceAsSpan)}");
Console.WriteLine($"The number of vowels counted using RegexCount is: {VowelCounters.CountVowelsUsingRegexCount(sentence)}");
Console.WriteLine($"The number of vowels counted using Regex Replace and Length is: {VowelCounters.CountVowelsUsingRegexReplaceAndLength(sentence)}");
Console.WriteLine($"The number of vowels counted using LINQ is: {VowelCounters.CountVowelsUsingLinq(sentence, vowelsHash)}");

BenchmarkRunner.Run<VowelCountersBenchmarks>();
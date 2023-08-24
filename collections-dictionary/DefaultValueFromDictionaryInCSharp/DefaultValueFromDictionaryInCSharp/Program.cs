using DefaultValueFromDictionaryInCSharp.MethodContainsKey;
using DefaultValueFromDictionaryInCSharp.MethodGetValueOrDefault;
using DefaultValueFromDictionaryInCSharp.MethodTryGetValue;

var myDictionary = new Dictionary<string, int>
{
    { "alice", 1 },
    { "bob", 2 },
    { "mike", 3 }
};
var key = "tom";

Console.WriteLine($"{MethodContainsKey.GetValueFromDictionary(myDictionary, key)}");

Console.WriteLine($"{MethodTryGetValue.GetValueFromDictionary(myDictionary, key)}");

Console.WriteLine($"{MethodGetValueOrDefault.GetValueFromDictionary(myDictionary, key)}");

Console.ReadKey();
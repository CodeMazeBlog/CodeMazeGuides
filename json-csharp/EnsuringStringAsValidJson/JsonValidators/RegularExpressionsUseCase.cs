using System.Text.RegularExpressions;
using JsonValidators.Abstracts;

namespace JsonValidators;

public class RegularExpressionsUseCase : IJsonValidator
{
    private const string JsonPattern = "(?<json>{(?:[^{}]|(?<Nested>{)|(?<-Nested>}))*(?(Nested)(?!))})";
    
    public bool IsValid(string jsonString)
    {
        return Regex.IsMatch(jsonString, JsonPattern);
    }
}
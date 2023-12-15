using System.Text.RegularExpressions;
using JsonValidators.Abstracts;

namespace JsonValidators;

public class RegularExpressionsUseCase : IJsonValidator
{
    public bool IsValid(string jsonString)
    {
        var jsonPattern = "(?<json>{(?:[^{}]|(?<Nested>{)|(?<-Nested>}))*(?(Nested)(?!))})";
        return Regex.IsMatch(jsonString, jsonPattern);
    }
}
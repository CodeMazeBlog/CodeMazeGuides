namespace JsonValidators.Abstracts;

public interface IJsonValidator
{
    bool IsValid(string jsonString);
}
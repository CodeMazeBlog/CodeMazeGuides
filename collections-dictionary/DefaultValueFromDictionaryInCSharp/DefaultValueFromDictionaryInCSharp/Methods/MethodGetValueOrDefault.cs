namespace DefaultValueFromDictionaryInCSharp.MethodGetValueOrDefault
{
    public static class MethodGetValueOrDefault
    {
        public static T? GetValueFromDictionary<T>(Dictionary<string, T> dictionary, string key)
        {
            return dictionary.GetValueOrDefault(key);
        }
    }
}

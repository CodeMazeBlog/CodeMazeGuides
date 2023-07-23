namespace DefaultValueFromDictionaryInCSharp.MethodTryGetValue
{
    public static class MethodTryGetValue
    {
        public static dynamic? GetValueFromDictionary<T>(Dictionary<string, T> dictionary, string key)
        {
            return dictionary.TryGetValue(key, out var value) ? value : default;
        }
    }
}

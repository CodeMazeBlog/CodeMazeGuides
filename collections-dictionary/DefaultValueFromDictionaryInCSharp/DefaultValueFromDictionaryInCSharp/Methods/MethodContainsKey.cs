namespace DefaultValueFromDictionaryInCSharp.MethodContainsKey
{
    public static class MethodContainsKey
    {
        public static dynamic GetValueFromDictionary<T>(Dictionary<string, T> dictionary, string key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : default;
        }
    }
}

namespace DefaultValueFromDictionaryInCSharp.MethodGetValueOrDefaultWithFallback
{
    public static class MethodGetValueOrDefaultWithFallback
    {
        public static T GetValueFromDictionary<T>(Dictionary<string, T> dictionary, string key, T fallback)
        {
            return dictionary.GetValueOrDefault(key, fallback);
        }
    }
}


namespace HowtoUseLazyInCSharp
{
    public class Cache
    {
        private Dictionary<string, object> cacheDictionary;

        public Cache()
        {
            cacheDictionary = new Dictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            cacheDictionary[key] = value;
        }

        public object Get(string key)
        {
            if (cacheDictionary.ContainsKey(key))
            {
                return cacheDictionary[key];
            }

            return null;
        }
    }
}

using System.Collections;

namespace DictionaryVsHashTables
{
    public class Utility
    {
        private const int ONE_HUNDRED_THOUSAND = 100000;
        private const int TEN_MILLION = 10000000;

        public static Dictionary<int, string> CreateAnEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

        public static Dictionary<int, Order> CreateAnOrderDictionary()
        {
            return new Dictionary<int, Order>
            {
                {
                    1, new Order
                    {
                        OrderId = Guid.NewGuid(),
                        Quantity = 25
                    }
                },
                {
                    2, new Order
                    {
                        OrderId = Guid.NewGuid(),
                        Quantity = 35
                    }
                },
                {
                    3, new Order
                    {
                        OrderId = Guid.NewGuid(),
                        Quantity = 45
                    }
                }
            };
        }

        public static Dictionary<int, string> CreateASmallNumbersDictionary()
        {
            var dictionary = new Dictionary<int, string>();

            for (var i = 0; i < ONE_HUNDRED_THOUSAND; i++)
            {
                dictionary.Add(i, $"Data{i}");
            }

            return dictionary;
        }

        public static Dictionary<int, string> CreateALargeDictionary()
        {
            var dictionary = new Dictionary<int, string>();

            for (var i = 0; i < TEN_MILLION; i++)
            {
                dictionary.Add(i, $"Data{i}");
            }

            return dictionary;
        }

        public static Hashtable CreateAnEmptyHashTable()
        {
            return new Hashtable();
        }

        public static Hashtable CreateAHashTable()
        {
            return new Hashtable
            {
                { 1,100},
                { 2,"Chicago"},
                { 3,true}
            };
        }

        public static Hashtable CreateASmallNumbersHashTable()
        {
            var hashTable = new Hashtable();

            for (var i = 0; i < ONE_HUNDRED_THOUSAND; i++)
            {
                hashTable.Add(i, $"Data{i}");
            }

            return hashTable;
        }

        public static Hashtable CreateALargeHashTable()
        {
            var hashTable = new Hashtable();

            for (var i = 0; i < TEN_MILLION; i++)
            {
                hashTable.Add(i, $"Data{i}");
            }

            return hashTable;
        }

        public static void ReadADictionary(Dictionary<int, string> dictionary)
        {
            for (var i = 0; i < dictionary.Count; i++)
            {
                var value = dictionary[i];
            }
        }

        public static void ReadAHashTable(Hashtable hashTable)
        {
            for (var i = 0; i < hashTable.Count; i++)
            {
                var value = hashTable[i];
            }
        }
    }
}
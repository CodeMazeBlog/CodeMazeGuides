using System.Collections;

namespace DictionaryVsHashTables
{
    public class Utility
    {
        private const int ONE_HUNDRED_THOUSAND = 100000;
        private const int TEN_MILLION = 10000000;

        public static Dictionary<int, string> CreateEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

        public static Dictionary<int, Order> CreateOrderDictionary()
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

        public static Dictionary<int, string> CreateSmallNumbersDictionary()
        {
            var dictionary = new Dictionary<int, string>();

            for (var i = 0; i < ONE_HUNDRED_THOUSAND; i++)
            {
                dictionary.Add(i, $"Data{i}");
            }

            return dictionary;
        }

        public static Dictionary<int, string> CreateLargeDictionary()
        {
            var dictionary = new Dictionary<int, string>();

            for (var i = 0; i < TEN_MILLION; i++)
            {
                dictionary.Add(i, $"Data{i}");
            }

            return dictionary;
        }

        public static Hashtable CreateEmptyHashTable()
        {
            return new Hashtable();
        }

        public static Hashtable CreateHashTable()
        {
            return new Hashtable
            {
                { 1,100},
                { 2,"Chicago"},
                { 3,true}
            };
        }

        public static Hashtable CreateSmallNumbersHashTable()
        {
            var hashTable = new Hashtable();

            for (var i = 0; i < ONE_HUNDRED_THOUSAND; i++)
            {
                hashTable.Add(i, $"Data{i}");
            }

            return hashTable;
        }

        public static Hashtable CreateLargeHashTable()
        {
            var hashTable = new Hashtable();

            for (var i = 0; i < TEN_MILLION; i++)
            {
                hashTable.Add(i, $"Data{i}");
            }

            return hashTable;
        }

        public static void ReadDictionary(Dictionary<int, string> dictionary)
        {
            for (var i = 0; i < dictionary.Count; i++)
            {
                var value = dictionary[i];
            }
        }

        public static void ReadHashTable(Hashtable hashTable)
        {
            for (var i = 0; i < hashTable.Count; i++)
            {
                var value = hashTable[i];
            }
        }
    }
}
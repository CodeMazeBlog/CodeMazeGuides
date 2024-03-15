using System.Collections;

namespace HashtableInCSharp
{
    public static class HashtableDemo
    {
        public static Hashtable CreateEmptyHashTable() => new();

        public static Hashtable CreateHashTableWithInitialCapacity(int initialCapacity)
            => new(initialCapacity);

        public static Hashtable CreateHashTableFromDictionary(Dictionary<int, User> dictionary) 
            => new(dictionary);

        public static Hashtable AddSampleDataToHashTable(Hashtable userHashTable, List<User> userList)
        {
            foreach (var user in userList)
            {
                userHashTable.Add(user.Id, user);
            }

            return userHashTable;
        }

        public static User RetrieveElementFromHashTable(Hashtable userHashTable, int id)
        {
            if (userHashTable.ContainsKey(id))
            {
                return (User)userHashTable[id];
            }

            return default;
        }

        public static IList<User> RetrieveAllElementsFromHashTable(Hashtable userHashTable)
        {
            var userList = new List<User>(userHashTable.Count);

            foreach (DictionaryEntry entry in userHashTable)
            {
                userList.Add((User)entry.Value);
            }

            return userList;
        }

        public static Hashtable UpdateElementInHashTable(Hashtable userHashTable, int id)
        {
            if (userHashTable.ContainsKey(id))
            {
                userHashTable[id] = new User() { FirstName = "Henry", LastName = "Stafford" };
               
                return userHashTable;
            }

            return userHashTable;
        }

        public static Hashtable RemoveElementFromHashTable(Hashtable userHashTable, int id)
        {
            userHashTable.Remove(id);

            return userHashTable;
        }

        public static Hashtable RemoveAllElementsFromHashTable(Hashtable userHashTable)
        {
            userHashTable.Clear();

            return userHashTable;
        }

        public static Hashtable CloneHashTable(Hashtable userHashTable)
        {
            return (Hashtable)userHashTable.Clone();
        }

        public static Hashtable SynchronizeHashtable(Hashtable userHashTable)
        {
            return Hashtable.Synchronized(userHashTable);
        }
    }
}
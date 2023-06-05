using System.Collections;

namespace HashtableInCSharp
{
    public class HashtableDemo
    {
        public static Hashtable CreateEmptyHashTable()
        {
            var firstHashTable = new Hashtable();

            return firstHashTable;
        }

        public static Hashtable CreateHashTableWithInitialCapacity()
        {
            var secondHashTable = new Hashtable(100);

            return secondHashTable;
        }

        public static Hashtable CreateHashTableFromDictionary()
        {
            var dictionary = new Dictionary<int, User>()
            {
                { 1, new User() { Id = 1, FirstName = "Rafa", LastName = "Lopez" } },
                { 2, new User() { Id = 2, FirstName = "Michael", LastName = "Sam" } },
                { 3, new User() { Id = 3, FirstName = "Sam", LastName = "Manalt"} },
                { 4, new User() { Id = 4, FirstName = "Lone", LastName = "Costa"} },
                { 5, new User() { Id = 5, FirstName = "Alberto", LastName = "Daci"} },
            };
            
            var userHashTable = new Hashtable(dictionary);

            return userHashTable;
        }

        public static Hashtable AddSampleDataToHashTable(Hashtable userHashTable, List<User> userList)
        {
            foreach(var user in userList)
            {
                userHashTable.Add(user.Id, user);
            }

            return userHashTable;
        }

        public static User RetrieveElementFromHashTable(Hashtable userHashTable, int id)
        {
            if (userHashTable.ContainsKey(id))
            {
                User user = (User)userHashTable[id];

                return user;
            }

            return default;
        }

        public static IList<User> RetrieveAllElementsFromHashTable(Hashtable userHashTable)
        {
            var userList = new List<User>();

            foreach(DictionaryEntry entry in userHashTable)
            {
                userList.Add((User)entry.Value);
            }

            return userList;
        }

        public static Hashtable UpdateElementInHashTable(Hashtable userHashTable, int id)
        {
            userHashTable[id] = new User() { FirstName = "Henry", LastName = "Stafford" };

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

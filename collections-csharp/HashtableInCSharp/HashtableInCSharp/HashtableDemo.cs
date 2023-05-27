using System.Collections;

namespace HashtableInCSharp
{
    public class HashtableDemo
    {
        public Hashtable CreateHashTable()
        {
            var firstHashTable = new Hashtable();

            var secondHashTable = new Hashtable(100);

            var dictionary = new Dictionary<int, User>()
            {
                { 1, new User() { FirstName = "Sam", LastName = "Manalt"} },
                { 2, new User() { FirstName = "Lone", LastName = "Costa"}},
                { 3, new User() { FirstName = "Alberto", LastName = "Daci"} },
            };
            
            var thirdHashTable = new Hashtable(dictionary);

            return secondHashTable;
        }

        public Hashtable AddToHashTable(Hashtable hashTable)
        {
            hashTable.Add(1, new User() { FirstName = "Goddy", LastName = "Opara"});
            hashTable.Add(2, new User() { FirstName = "Rafa", LastName = "Lopez" });
            hashTable.Add(3, new User() { FirstName = "Michael", LastName = "Sam" });
            hashTable.Add(4, new User() { FirstName = "Judit", LastName = "Peter" });

            hashTable[5] = new User() { FirstName = "Steve", LastName = "Billing" };

            return hashTable;
        }

        public User RetrieveAnElementFromHashTable(Hashtable hashTable)
        {
            if (hashTable.ContainsKey(1))
            {
                User firstUser = (User)hashTable[1];

                return firstUser;
            }

            return default;
        }

        public void RetrieveAllElementsFromHashTable(Hashtable hashTable)
        {
            foreach(DictionaryEntry entry in hashTable)
            {
                Console.WriteLine($"User ID - {entry.Key}, User Name - {entry.Value}");
            }
        }

        public Hashtable UpdateAnElementInHashTable(Hashtable hashTable)
        {
            hashTable[1] = new User() { FirstName = "Henry", LastName = "Stafford" };

            return hashTable;
        }

        public Hashtable RemoveAnElementFromHashTable(Hashtable hashTable)
        {
            hashTable.Remove(2);

            return hashTable;
        }

        public Hashtable RemoveAllElementsFromHashTable(Hashtable hashTable)
        {
            hashTable.Clear();

            return hashTable;
        }

        public Hashtable CloneHashTable(Hashtable hashTable)
        {
            return (Hashtable)hashTable.Clone();
        }

        public Hashtable SynchronizeHashtable(Hashtable hashTable)
        {
            return Hashtable.Synchronized(hashTable);
        }
    }
}
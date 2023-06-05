using HashtableInCSharp;
using System.Collections;

namespace HashtableInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userHashTable = HashtableDemo.CreateHashTableFromDictionary();

            // Hashtable content before adding data to it
            PrintHashTableContent(userHashTable);

            // List of users to add to the Hashtable
            List<User> userList = new()
            {
                new User() { Id = 6, FirstName = "Judit", LastName = "Peter" },
                new User() { Id = 7, FirstName = "Steve", LastName = "Billing" },
                new User() { Id = 8, FirstName = "Goddy", LastName = "Opara" },
            };

            // Adding data to the Hashtable
            HashtableDemo.AddSampleDataToHashTable(userHashTable, userList);
            
            // Hashtable content after adding data to it
            PrintHashTableContent(userHashTable);

            // Updating data in the Hashtable
            HashtableDemo.UpdateElementInHashTable(userHashTable, 2);

            // Hashtable content after updating data in the Hashtable
            PrintHashTableContent(userHashTable);

            // Removing data from the Hashtable
            HashtableDemo.RemoveElementFromHashTable(userHashTable, 5);

            // Hashtable content after removing a user data from the Hashtable
            PrintHashTableContent(userHashTable);
        }

        public static void PrintHashTableContent(Hashtable userHashTable)
        {
            foreach (DictionaryEntry entry in userHashTable)
            {
                Console.WriteLine($"UserId:{entry.Key} UserName:{entry.Value}");
            }
        }
    }
}

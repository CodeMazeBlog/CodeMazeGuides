using System.Collections;

namespace HashtableInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userHashTable = HashtableDemo.CreateHashTableFromDictionary(SharedData.UserDictionary);

            // Hashtable content before adding data to it
            PrintHashTableContent(userHashTable);               

            // Adding data to the Hashtable
            HashtableDemo.AddSampleDataToHashTable(userHashTable, SharedData.UserList);
            
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
using System.Collections;

namespace HashtableInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hashTableDemo = new HashtableDemo();
            var hashTable = hashTableDemo.AddToHashTable(new Hashtable());
            hashTableDemo.RetrieveAllElementsFromHashTable(hashTable);
        }
    }
}
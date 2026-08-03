using System.Collections;
namespace CollectionsInCSharp
{
    public class NonGenericCollections
    {
        public static ArrayList CreateDetailsList()
        {
            ArrayList detailsList = new();
            detailsList.Add(null);
            detailsList.Add(1);
            detailsList.Add('a');
            detailsList.Add(true);

            return detailsList;
        }

        public static ArrayList ReadFromDetailsList(ArrayList detailsList)
        {
            var details = new ArrayList
            {
                detailsList[1],
                detailsList[0],
            };

            return details;
        }

        public static Hashtable CreateDetailsHashTable()
        {
            Hashtable detailsHashTable = new();
            detailsHashTable.Add("name", "John");
            detailsHashTable.Add("language", 'C');
            detailsHashTable.Add("isEligible", "No");
            detailsHashTable["age"] = 17;

            return detailsHashTable;
        }

        public static ArrayList ReadFromDetailsHashTable(Hashtable detailsHashTable)
        {
            var myList = new ArrayList
            {
                detailsHashTable["name"],
                detailsHashTable["age"]
            };

            return myList;
        }

        public static SortedList CreateNumbersSortedList()
        {
            SortedList numbersSortedList = new SortedList();
            numbersSortedList.Add("first", 1);
            numbersSortedList.Add("second", 2);
            numbersSortedList.Add("third", 3);

            return numbersSortedList;
        }

        public static ArrayList ReadFromNumbersSortedList(SortedList numbersSortedList)
        {
            var numList = new ArrayList
            {
                numbersSortedList["first"],
                numbersSortedList["second"],
                numbersSortedList.GetByIndex(2)
            };

            return numList;
        }

        public static Stack CreateDetailsStack()
        {
            Stack detailsStack = new Stack();
            detailsStack.Push("one");
            detailsStack.Push(1);
            detailsStack.Push(true);

            return detailsStack;
        }

        public static ArrayList ReadFromDetailsStack(Stack detailsStack)
        {
            var detailList = new ArrayList
            {
                detailsStack.Pop()
            };

            return detailList;
        }

        public static Queue CreateDetailsQueue()
        {
            Queue detailsQueue = new Queue();
            detailsQueue.Enqueue("First");
            detailsQueue.Enqueue(2);
            detailsQueue.Enqueue(false);

            return detailsQueue;
        }

        public static ArrayList ReadFromDetailsQueue(Queue detailsQueue)
        {
            var detailList = new ArrayList
            {
                detailsQueue.Dequeue()
            };

            return detailList;
        }
    }
}
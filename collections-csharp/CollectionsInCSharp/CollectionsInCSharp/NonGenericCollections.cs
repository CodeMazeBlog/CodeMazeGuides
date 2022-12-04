using System.Collections;
namespace CollectionsInCSharp
{
    public class NonGenericCollections
    {
        private static ArrayList DetailsList = new ArrayList();
        private static Hashtable DetailsHashTable = new Hashtable();
        private static SortedList NumbersSortedList = new SortedList();
        private static Stack DetailsStack = new Stack();
        private static Queue DetailsQueue = new Queue();
        public static ArrayList AddToDetailsList()
        {
            DetailsList.Add(null);
            DetailsList.Add(1);
            DetailsList.Add('a');
            DetailsList.Add(true);

            return DetailsList;
        }

        public static ArrayList ReadFromDetailsList()
        {
            var myList = new ArrayList();
            myList.Add(DetailsList[1]);

            return myList;
        }

        public static Hashtable AddToDetailsHashTable()
        {
            DetailsHashTable.Add("name", "John");
            DetailsHashTable.Add("language", 'C');
            DetailsHashTable.Add("isEligible", "No");
            DetailsHashTable["age"] = 17;

            return DetailsHashTable;
        }

        public static ArrayList ReadFromDetailsHashTable()
        {
            var myList = new ArrayList();
            myList.Add(DetailsHashTable["name"]);
            myList.Add(DetailsHashTable["age"]);
            
            return myList;
        }

        public static SortedList AddToNumbersSortedList()
        {
            NumbersSortedList.Add("first", 1);
            NumbersSortedList.Add("second", 2);
            NumbersSortedList.Add("third", 3);

            return NumbersSortedList;
        }

        public static ArrayList ReadFromNumbersSortedList()
        {
            var numList = new ArrayList();
            numList.Add(NumbersSortedList["first"]);
            numList.Add(NumbersSortedList["second"]);
            numList.Add(NumbersSortedList.GetByIndex(2));

            return numList;
        }

        public static Stack AddToDetailsStack()
        {
            DetailsStack.Push("one");
            DetailsStack.Push(1);
            DetailsStack.Push(true);

            return DetailsStack;
        }

        public static ArrayList ReadFromDetailsStack()
        {
            var detailList = new ArrayList();
            detailList.Add(DetailsStack.Pop());

            return detailList;
        }

        public static Queue AddToDetailsQueue()
        {
            DetailsQueue.Enqueue("First");
            DetailsQueue.Enqueue(2);
            DetailsQueue.Enqueue(false);

            return DetailsQueue;
        }

        public static ArrayList ReadFromDetailsQueue()
        {
            var detailList = new ArrayList();
            detailList.Add(DetailsQueue.Dequeue());
            
            return detailList;
        }

    }

}
using System;
using System.Collections;

namespace SortedListInCSharp
{
    public class NonGenericLists
    {
        public static SortedList NonGenericSortedList()
        {
            var myNonGenericList = new SortedList();
            myNonGenericList.Add(1, "This is my first string element");
            myNonGenericList.Add(2, "This is my second string element");
            // These next lines will give us runtime exceptions...
            /*
                myNonGenericList.Add("three", "This is my third string element");     // System.ArgumentException: 'Item has already been added. Key in dictionary: '1' Key being added: 'three''
                myNonGenericList.Add(null, "There is nothing to see here");     // System.ArgumentNullException: 'Key cannot be null. (Parameter 'key')'
            */

            myNonGenericList.Add(5, 5);

            myNonGenericList.Add(8, null);
            myNonGenericList.Add(6, "a separate thing");
            myNonGenericList.Add(7, new { name = "John", surname = "Wick" });
            myNonGenericList.Add(9, "another thing");

            return myNonGenericList;
        }

        public static bool CheckContentsOfNonGenericList(SortedList myNonGenericList, int myKey)
        {
            return myNonGenericList.ContainsKey(myKey);
        }

        public static bool CheckContentsOfNonGenericList(SortedList myNonGenericList, string myValue)
        {
            return myNonGenericList.ContainsValue(myValue);
        }
    }
}

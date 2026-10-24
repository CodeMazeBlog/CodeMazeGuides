using System;
using System.Collections.Generic;

namespace SortedListInCSharp
{
    public class GenericLists
    {
        public static SortedList<int, string> GenericSortedList()
        {
            var myList = new SortedList<int, string>();

            return myList;
        }

        public static SortedList<int, string> GenericSortedListFromDictionary()
        {
            var myDictionary = new Dictionary<int, string> {
                { 1, "first things first" },
                { 2, "second things second" }
            };

            var myListFromDictionary = new SortedList<int, string>(myDictionary);

            return myListFromDictionary;
        }

        public static SortedList<int, string> AddElementsToSortedList(SortedList<int, string> myGenericList)
        {
            myGenericList.Add(1, "This is my first string element");
            myGenericList.Add(2, "This is my second string element");

            // These next lines will give us syntax errors...
            /*
                myList.Add("three", "This is my third string element");     // CS1503: Argument 1: cannot convert from 'string' to 'int'
                myList.Add(null, "There is nothing to see here");     // CS1503: Argument 1: cannot convert from '<null>' to 'int'
                myList.Add(5, 5);    // CS1503: Argument 2: cannot convert from 'int' to 'string'
            */

            if (!myGenericList.ContainsKey(3))
            {
                myGenericList.Add(3, "This is my third value");
            }

            if (!myGenericList.ContainsValue("This is my fourth value"))
            {
                myGenericList.Add(4, "This is my fourth value");
            }

            return myGenericList;
        }

        public static SortedList<int, string> RemoveElementsFromSortedList(SortedList<int, string> myGenericList)
        {
            myGenericList.RemoveAt(1); // removes the element with key 2, which sits at index 1
            myGenericList.Remove(4); // removes the element with key 4

            myGenericList.Clear(); // removes all the elements, Count is now 0

            return myGenericList;
        }

        public static (string Third, string Fifth, int FirstKey) ReadElementsFromSortedList(SortedList<int, string> myGenericList)
        {
            var third = myGenericList[3]; // "This is my third value"
            myGenericList.TryGetValue(5, out var fifth); // false, fifth is null
            var firstKey = myGenericList.GetKeyAtIndex(0); // 1

            return (third, fifth, firstKey);
        }

        public static bool CheckContentsOfGenericList(SortedList<int, string> myGenericList, int myKey)
        {
            return myGenericList.ContainsKey(myKey);
        }

        public static bool CheckContentsOfGenericList(SortedList<int, string> myGenericList, string myValue)
        {
            return myGenericList.ContainsValue(myValue);
        }

        public static SortedList<string, string> ListWithCapacity(int capacity)
        {
            var listWithCapacity = new SortedList<string, string>(capacity);

            return listWithCapacity;
        }
    }
}

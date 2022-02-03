using System;
using System.Collections;
using System.Collections.Generic;

namespace SortedListInCSharp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        #region GenericSortedList
        public static SortedList<int, string> GenericSortedList()
        { 
            // Creating an empty SortedList
            SortedList<int, string> myList = new SortedList<int, string>();
            return myList;
        }
    
        public static SortedList<int, string> GenericSortedListFromDictionary()
        {
            // Creating a SortedList filled from a Dictionary
            Dictionary<int, string> myDictionary = new Dictionary<int, string> {
                { 1, "first things first" },
                { 2, "second things second" }
            };
            SortedList<int, string> myListFromDictionary = new SortedList<int, string>(myDictionary);
            return myListFromDictionary;
        }

        /// <summary>
        /// Adds 4 unique elements to the SortedList
        /// </summary>
        public static SortedList<int, string> AddElementsToSortedList(SortedList<int, string> myGenericList)
        {
            // Adding elements to the SortedList
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

        /// <summary>
        /// Empties the sorted list
        /// </summary>
        public static SortedList<int, string> RemoveElementsFromSortedList(SortedList<int, string> myGenericList)
        {
            myGenericList.RemoveAt(3); // removes (2, "") which is the item at position 3
            myGenericList.Remove(4); // removes (4, "")

            myGenericList.Clear(); // removes all the elements and returns an empty collection
            return myGenericList;
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
            SortedList<string, string> listWithCapacity = new SortedList<string, string>(capacity);
            return listWithCapacity;
        }
        #endregion


        #region NonGenericSortedList
        public static SortedList NonGenericSortedList()
        {
            // Create a non-generic SortedList
            SortedList myNonGenericList = new SortedList();
            myNonGenericList.Add(1, "This is my first string element");
            myNonGenericList.Add(2, "This is my second string element");
            // These next lines will give us runtime exceptions...
            /*
                myNonGenericList.Add("three", "This is my third string element");     // System.ArgumentException: 'Item has already been added. Key in dictionary: '1' Key being added: 'three''
                myNonGenericList.Add(null, "There is nothing to see here");     // System.ArgumentNullException: 'Key cannot be null. (Parameter 'key')'
            */

            // This line does not give us any errors!
            myNonGenericList.Add(5, 5);

            // The order of input doesn't matter
            myNonGenericList.Add(8, null);
            myNonGenericList.Add(6, "a separate thing");
            myNonGenericList.Add(7, new { name = "John", surname = "Wick" });
            myNonGenericList.Add(9, "another thing");
            return myNonGenericList;
        }

        public static SortedList SortedListWithComparer()
        {
            Comparer cmp = new Comparer();
            SortedList listWithComparer = new SortedList(cmp);
            listWithComparer.Add(2, "Second");
            listWithComparer.Add(4, "Fourth");
            listWithComparer.Add(1, "First");
            listWithComparer.Add(3, "Third");
            return listWithComparer;
        }

        public static bool CheckContentsOfNonGenericList(SortedList myNonGenericList, int myKey)
        {
            return myNonGenericList.ContainsKey(myKey);
        }
        public static bool CheckContentsOfNonGenericList(SortedList myNonGenericList, string myValue)
        {
            return myNonGenericList.ContainsValue(myValue);
        }
        #endregion
    }

    public class Comparer : IComparer
    {
        // To understand why this compare method works successfully, 
        // we need to understand boxing and unboxing of variables,
        // and why a float would throw an exception in Line 54
        public int Compare(object x, object y) 
        {
            try
            {
                return compareIntegers((int)x, (int)y);
            } catch (InvalidCastException) { }
            try
            {
                return compareStrings((string)x, (string)y);
            } catch (InvalidCastException) { }
            return 0;
        }

        private int compareIntegers(int x, int y) => x > y ? 1 : -1;
        private int compareStrings(string x, string y) => x[0] > y[0] ? 1 : -1;
    }
}

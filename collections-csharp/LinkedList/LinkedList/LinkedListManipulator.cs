using System.Collections.Generic;
using System.Data;

namespace LinkedList
{
    public class LinkedListManipulator
    {
        public void ManipulateLinkedList()
        {
            var linkedList = new LinkedList<int>();

            AddFirst(linkedList);
            Find(linkedList);
            AddAfter(linkedList);
            AddBefore(linkedList);
            AddLast(linkedList);
            Remove(linkedList);
            Clear(linkedList);

            PrintLinkedList(linkedList);
        }

        public void AddFirst(LinkedList<int> linkedList)
        {
            linkedList.AddFirst(1);
            linkedList.AddFirst(new LinkedListNode<int>(2));
        }

        public void Find(LinkedList<int> linkedList)
        {
            var node = linkedList.Find(2);
        }

        public static void AddAfter(LinkedList<int> linkedList)
        {
            var node = linkedList.Find(2);
            if (node is not null)
                linkedList.AddAfter(node, 3);
        }

        public static void AddBefore(LinkedList<int> linkedList)
        {
            var node = linkedList.Find(1);
            if (node is not null)
                linkedList.AddBefore(node, 4);
        }

        public void AddLast(LinkedList<int> linkedList)
        {
            linkedList.AddLast(5);
        }

        public void Remove(LinkedList<int> linkedList)
        {
            linkedList.Remove(1);
        }

        public void Clear(LinkedList<int> linkedList)
        {
            linkedList.Clear();
        }

        public void PrintLinkedList(LinkedList<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($" ==> {item}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
        }
    }
}

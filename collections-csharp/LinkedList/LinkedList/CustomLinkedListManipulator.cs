using LinkedList.CustomImplementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class CustomLinkedListManipulator
    {
        public void ManipulateLinkedList()
        {
            var customLinkedList = new CustomLinkedList<int>();

            AddFirst(customLinkedList);
            Find(customLinkedList);
            AddAfter(customLinkedList);
            AddBefore(customLinkedList);
            AddLast(customLinkedList);
            Remove(customLinkedList);
            Clear(customLinkedList);

            PrintLinkedList(customLinkedList);
        }

        private void AddFirst(CustomLinkedList<int> customLinkedList)
        {
            customLinkedList.AddFirst(1);
            customLinkedList.AddFirst(new Node<int>(2));
        }

        private void Find(CustomLinkedList<int> customLinkedList)
        {
            var node = customLinkedList.Find(2);
        }

        public static void AddAfter(CustomLinkedList<int> customLinkedList)
        {
            customLinkedList.AddAfter(3, 2);
        }

        public void AddBefore(CustomLinkedList<int> customLinkedList)
        {
            customLinkedList.AddBefore(4, 1);
        }

        public void AddLast(CustomLinkedList<int> customLinkedList)
        {
            customLinkedList.AddLast(5);
        }

        public void Remove(CustomLinkedList<int> customLinkedList)
        {
            customLinkedList.Remove(1);
        }

        public void Clear(CustomLinkedList<int> customLinkedList)
        {
            customLinkedList.Clear();
        }

        public void PrintLinkedList(CustomLinkedList<int> customLinkedList)
        {
            customLinkedList.PrintElements();
        }
    }
}

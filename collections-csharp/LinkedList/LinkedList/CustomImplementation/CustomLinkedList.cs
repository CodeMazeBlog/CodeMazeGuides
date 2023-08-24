using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.CustomImplementation
{
    public class CustomLinkedList<T> : IEnumerable<Node<T>>
    {
        public Node<T>? First { get; set; }
        public int Count { get; set; }

        public void AddFirst(Node<T> nodeToAdd)
        {
            if (First is null)
            {
                First = nodeToAdd;
            }
            else
            {
                nodeToAdd.Next = First;
                First.Prev = nodeToAdd;

                First = nodeToAdd;
            }

            Count++;
        }

        public void AddFirst(T valueToAdd)
        {
            var node = new Node<T>(valueToAdd);
            AddFirst(node);
        }

        public void AddAfter(T valueToAdd, T valueToFind)
        {
            var nodeToAdd = new Node<T>(valueToAdd);
            AddAfter(nodeToAdd, valueToFind);
        }

        public void AddAfter(Node<T> nodeToAdd, T valueToFind)
        {
            var find = Find(valueToFind);

            if(find is not null)
            {
                var next = find.Next;

                nodeToAdd.Next = next;
                find.Next = nodeToAdd;

                if (next?.Prev is not null)
                {
                    next.Prev = nodeToAdd;
                }
                
                nodeToAdd.Prev = find;

                Count++;

                return;
            }

            AddLast(nodeToAdd);
        }

        public void AddLast(Node<T> nodeToAdd)
        {
            var lastNode = GetLastNode();

            if (lastNode is not null)
            {
                lastNode.Next = nodeToAdd;
                nodeToAdd.Prev = lastNode;

                Count++;

                return;
            }

            AddFirst(nodeToAdd);
        }

        public void AddLast(T valueToAdd)
        {
            var node = new Node<T>(valueToAdd);
            AddLast(node);
        }

        public Node<T>? GetLastNode()
        {
            if (First is null)
            {
                return default;
            }

            var aux = First;

            while (aux is not null)
            {
                if (aux.Next is null)
                {
                    return aux;
                }

                aux = aux.Next;
            }

            return default;
        }

        public void AddBefore(Node<T> nodeToAdd, T valueToFind)
        {
            var find = Find(valueToFind);

            if (find is not null)
            {
                nodeToAdd.Prev = find.Prev;

                if (find.Prev?.Next is not null)
                {
                    find.Prev.Next = nodeToAdd;
                }

                nodeToAdd.Next = find;
                find.Prev = nodeToAdd;

                Count++;

                return;
            }

            AddLast(nodeToAdd);
        }

        public void AddBefore(T valueToAdd, T valueToFind)
        {
            var node = new Node<T>(valueToAdd);
            AddBefore(node, valueToFind);
        }

        public Node<T>? Find(T valueToFind)
        {
            var aux = First;

            while (aux is not null)
            {
                if (EqualityComparer<T>.Default.Equals(aux.Value, valueToFind))
                {
                    return aux;
                }

                aux = aux.Next;
            }

            return default;
        }

        public void Remove(T valueToRemove)
        {
            var find = Find(valueToRemove);

            if (find is null)
            {
                return;
            }

            var next = find.Next;
            var prev = find.Prev;

            if (prev is not null)
            {
                prev.Next = next;
            }

            if (next is not null)
            {
                next.Prev = prev;
            }

            Count--;
        }

        public void RemoveFirst()
        {
            if (First is null)
            {
                return;
            }

            var next = First.Next;

            if(next is not null)
            {
                next.Prev = null;
                First = next;

                return;
            }

            First = null;
        }

        public void RemoveLast()
        {
            var lastNode = GetLastNode();

            if(lastNode is not null)
            {
                var prev = lastNode.Prev;

                if (prev is not null)
                {
                    prev.Next = null;
                }

                lastNode.Prev = null;

                Count--;
            }

            RemoveFirst();
        }

        public void Clear()
        {
            First = null;
            Count = 0;
        }

        public void PrintElements()
        {
            foreach (var item in this)
            {
                Console.WriteLine($" ==> {item.Value}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T>? currentNode = First;

            while (currentNode is not null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

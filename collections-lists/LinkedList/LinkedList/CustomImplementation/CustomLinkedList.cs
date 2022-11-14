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

        public void AddFirst(Node<T> node)
        {
            if (First is null)
                First = node;
            else
            {
                node.Next = First;
                First.Prev = node;

                First = node;
            }

            Count++;
        }

        public void AddFirst(T value)
        {
            var node = new Node<T>(value);
            AddFirst(node);
        }

        public void AddAfter(T addingValue, T findValue)
        {
            var addingNode = new Node<T>(addingValue);
            AddAfter(addingNode, findValue);
        }

        public void AddAfter(Node<T> addingNode, T findValue)
        {
            var find = Find(findValue);

            if(find is not null)
            {
                var next = find.Next;

                addingNode.Next = next;
                find.Next = addingNode;

                if(next?.Prev is not null)
                    next.Prev = addingNode;
                
                addingNode.Prev = find;

                Count++;

                return;
            }

            AddLast(addingNode);
        }

        public void AddLast(Node<T> node)
        {
            var lastNode = GetLastNode();

            if (lastNode is not null)
            {
                lastNode.Next = node;
                node.Prev = lastNode;

                Count++;

                return;
            }

            AddFirst(node);
        }

        public void AddLast(T value)
        {
            var node = new Node<T>(value);
            AddLast(node);
        }

        public Node<T>? GetLastNode()
        {
            if (First is null)
                return default;

            var aux = First;

            while (aux is not null)
            {
                if (aux.Next is null)
                    return aux;

                aux = aux.Next;
            }

            return default;
        }

        public void AddBefore(Node<T> addingNode, T findValue)
        {
            var find = Find(findValue);

            if (find is not null)
            {
                addingNode.Prev = find.Prev;

                if (find.Prev?.Next is not null)
                    find.Prev.Next = addingNode;

                addingNode.Next = find;
                find.Prev = addingNode;

                Count++;

                return;
            }

            AddLast(addingNode);
        }

        public void AddBefore(T addingValue, T findValue)
        {
            var node = new Node<T>(addingValue);
            AddBefore(node, findValue);
        }

        public Node<T>? Find(T value)
        {
            var aux = First;

            while (aux is not null)
            {
                if (EqualityComparer<T>.Default.Equals(aux.Value, value))
                    return aux;

                aux = aux.Next;
            }

            return default;
        }

        public void Remove(T value)
        {
            var find = Find(value);

            if (find is null)
                return;

            var next = find.Next;
            var prev = find.Prev;

            if (prev is not null)
                prev.Next = next;

            if (next is not null)
                next.Prev = prev;

            Count--;
        }

        public void RemoveFirst()
        {
            if (First is null)
                return;

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

                if(prev is not null)
                    prev.Next = null;

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

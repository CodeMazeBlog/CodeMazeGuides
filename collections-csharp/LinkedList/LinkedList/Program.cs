using LinkedList;
using LinkedList.CustomImplementation;
using System.Runtime.Serialization;

public class Program
{
    public static void Main()
    {
        LinkedListManipulator linkedListManipulator = new();
        linkedListManipulator.ManipulateLinkedList();

        CustomLinkedListManipulator customLinkedListManipulator = new();
        customLinkedListManipulator.ManipulateLinkedList();
    }
}

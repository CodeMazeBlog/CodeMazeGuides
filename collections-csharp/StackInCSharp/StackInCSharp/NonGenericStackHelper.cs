using System.Collections;

namespace StackInCSharp;

public class NonGenericStackHelper
{
    public NonGenericStackHelper()
    {
        List<string> letters = new List<string>() { "a", "b", "c" };
        NonGenericStack = new Stack(letters);
    }

    public Stack NonGenericStack { get; private set; }

    public int GetCount()
    {
        if (NonGenericStack == null)
        {
            throw new ArgumentNullException();
        }
        return NonGenericStack.Count;
    }

    public void PushItem(object o)
    {
        if (NonGenericStack == null)
        {
            throw new ArgumentNullException();
        }

        NonGenericStack.Push(o);
    }

    public object PeekItem()
    {
        if (NonGenericStack == null)
        {
            throw new ArgumentNullException();
        }

        return NonGenericStack.Peek();
    }

    public object PopItem()
    {
        if (NonGenericStack == null)
        {
            throw new ArgumentNullException();
        }

        return NonGenericStack.Pop();
    }

    public void ClearStack()
    {
        if (NonGenericStack == null)
        {
            throw new ArgumentNullException();
        }

        NonGenericStack.Clear();
    }

    public Stack CreateSynchonizedStack()
    {
        return Stack.Synchronized(NonGenericStack);
    }

    public bool IsSynchronizedStack(Stack stack)
    {
        return stack.IsSynchronized;
    }

    public void PrintCount()
    {
        Console.WriteLine($"{nameof(NonGenericStack)} contains {NonGenericStack.Count} items");
    }
}

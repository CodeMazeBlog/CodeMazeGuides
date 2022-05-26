namespace StackInCSharp;

public class GenericStackHelper<T>
{
    public GenericStackHelper()
    {
        GenericStack = new Stack<T>();
    }

    public Stack<T> GenericStack { get; private set; }

    public int GetCount()
    {
        if (GenericStack == null)
        {
            throw new ArgumentNullException();
        }
        return GenericStack.Count;
    }

    public void PushItem(T o)
    {
        if (GenericStack == null)
        {
            throw new ArgumentNullException();
        }

        GenericStack.Push(o);
    }

    public T PeekItem()
    {
        if (GenericStack == null)
        {
            throw new ArgumentNullException();
        }

        return GenericStack.Peek();
    }

    public T PopItem()
    {
        if (GenericStack == null)
        {
            throw new ArgumentNullException();
        }

        return GenericStack.Pop();
    }

    public bool TryPeekItem(out T result)
    {
        if (GenericStack == null)
        {
            throw new ArgumentNullException();
        }

        return GenericStack.TryPeek(out result);
    }

    public bool TryPopItem(out T result)
    {
        if (GenericStack == null)
        {
            throw new ArgumentNullException();
        }

        return GenericStack.TryPop(out result);
    }

    public void ClearStack()
    {
        if (GenericStack == null)
        {
            throw new ArgumentNullException();
        }

        GenericStack.Clear();
    }

    public void PrintCount()
    {
        if (GenericStack == null)
        {
            throw new ArgumentNullException();
        }

        Console.WriteLine($"{nameof(GenericStack)} contains {GenericStack.Count} items");
    }
}

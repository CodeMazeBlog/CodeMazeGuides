/*
The presented article snippets have been compiled into the SampleClass class below to include them in a context where 
the C# compiler would accept them.
*/
public class SampleClass
{
    public delegate void MyDelegateType(int param1, string param2);
    // Now use it, for example, to declare a class field or method variable.
    private MyDelegateType _d1;

    public SampleClass()
    {
        // Null can be used to initialize.
        Func<int> randIntFn = null;
        // Using a named method:
        randIntFn = new Random().Next;
        // Using an anonymous method:
        randIntFn = delegate ()
        {
            return new Random().Next(0, 10);
        };
        // Using a lambda expression, that is implicitly built into a delegate:
        // (this is the most common way of doing anonymous methods)
        randIntFn = () => new Random().Next(200, 300);
        // ---
        // Once initialized, we can invoke the method through the Func delegate.
        int randInt = randIntFn();
    }
}
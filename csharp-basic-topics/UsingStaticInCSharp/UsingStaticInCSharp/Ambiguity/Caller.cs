namespace UsingStaticInCSharp.Ambiguity;
public class Caller
{
    public virtual void Invoke()
    {
        ClassA.Method();
        ClassB.Method();

        // Error CS0121 The call is ambiguous
        // between the following methods or properties:
        // 'ClassA.Method()' and 'ClassB.Method()'
        // Method(); 
    }
}

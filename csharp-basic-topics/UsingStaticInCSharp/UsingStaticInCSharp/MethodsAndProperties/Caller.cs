using static UsingStaticInCSharp.MethodsAndProperties.ClassA;

namespace UsingStaticInCSharp.MethodsAndProperties;
public class Caller
{
    public virtual void Invoke()
    {
        MethodA();
        MethodB();
    }
}
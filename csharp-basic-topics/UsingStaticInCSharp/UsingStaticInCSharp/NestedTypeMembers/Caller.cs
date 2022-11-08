using static UsingStaticInCSharp.NestedTypeMembers.ClassA.ClassB;

namespace UsingStaticInCSharp.NestedTypeMembers;
public class Caller
{
    public virtual void Invoke()
    {
        MethodB();
    }
}

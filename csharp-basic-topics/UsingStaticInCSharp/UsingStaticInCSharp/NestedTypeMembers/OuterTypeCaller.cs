using static UsingStaticInCSharp.NestedTypeMembers.ClassA;

namespace UsingStaticInCSharp.NestedTypeMembers;
public class OuterTypeCaller
{
    public virtual void Invoke()
    {
        ClassB.MethodA();
        ClassB.MethodB();
    }
}

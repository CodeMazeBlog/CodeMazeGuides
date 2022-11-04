using static UsingStaticInCSharp.NestedTypeMembers.ClassA.ClassB;

namespace UsingStaticInCSharp.NestedTypeMembers;
public class Caller
{
    public static void Invoke()
    {
        MethodB();
    }
}

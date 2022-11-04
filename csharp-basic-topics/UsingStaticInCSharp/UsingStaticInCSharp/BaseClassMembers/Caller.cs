using static UsingStaticInCSharp.BaseClassMembers.ClassB;

namespace UsingStaticInCSharp.BaseClassMembers;
public static class Caller
{
    public static void Invoke()
    {
        MethodB();
    }
}

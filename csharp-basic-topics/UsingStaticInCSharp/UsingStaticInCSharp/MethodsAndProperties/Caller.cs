using static UsingStaticInCSharp.MethodsAndProperties.ClassA;

namespace UsingStaticInCSharp.MethodsAndProperties;
public static class Caller
{
    public static void Invoke()
    {
        MethodA();
        MethodB();
    }
}
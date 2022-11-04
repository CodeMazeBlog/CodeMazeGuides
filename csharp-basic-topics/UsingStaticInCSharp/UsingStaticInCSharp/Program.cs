namespace UsingStaticInCSharp;
internal class Program
{
    static void Main(string[] args)
    {
        MethodsAndProperties.Caller.Invoke();
        Enums.Caller.Invoke();
        Constants.Caller.Invoke();
        NestedTypeMembers.Caller.Invoke();
        ExtensionMethods.Caller.Invoke();
        BaseClassMembers.Caller.Invoke();
        Ambiguity.Caller.Invoke();
    }
}
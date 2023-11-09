namespace UsingStaticInCSharp;
internal class Program
{
    static void Main(string[] args)
    {
        new MethodsAndProperties.Caller().Invoke();
        new Enums.Caller().Invoke();
        new Constants.Caller().Invoke();
        new NestedTypeMembers.Caller().Invoke();
        new ExtensionMethods.Caller().Invoke();
        new BaseClassMembers.Caller().Invoke();
        new Ambiguity.Caller().Invoke();
    }
}
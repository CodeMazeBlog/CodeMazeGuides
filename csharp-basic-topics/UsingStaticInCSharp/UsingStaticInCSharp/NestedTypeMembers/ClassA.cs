namespace UsingStaticInCSharp.NestedTypeMembers;
public static class ClassA
{
    public static class ClassB
    {
        public static void MethodB()
        {
            Console.WriteLine("NestedTypeMembers.ClassA.ClassB.MethodB() called");
        }
    }
}

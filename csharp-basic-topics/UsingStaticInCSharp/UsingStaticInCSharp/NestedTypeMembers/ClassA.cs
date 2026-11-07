namespace UsingStaticInCSharp.NestedTypeMembers;
public class ClassA
{
    public class ClassB
    {
        public static void MethodA()
        {
            Console.WriteLine("NestedTypeMembers.ClassA.ClassB.MethodA() called");
        }

        public static void MethodB()
        {
            Console.WriteLine("NestedTypeMembers.ClassA.ClassB.MethodB() called");
        }
    }
}

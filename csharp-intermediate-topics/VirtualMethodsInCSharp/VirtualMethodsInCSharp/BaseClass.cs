namespace VirtualMethodsInCSharp
{
    public class BaseClass
    {
        public virtual string VirtualMethodA()
        {
            return "This is a virtual method";
        }

        public virtual string VirtualMethodB()
        {
            return "This is another virtual method";
        }

        public string NonVirtualMethod()
        {
            return "This is non-virtual method";
        }
    }
}
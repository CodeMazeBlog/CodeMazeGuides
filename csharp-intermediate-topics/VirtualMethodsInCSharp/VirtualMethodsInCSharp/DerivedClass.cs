namespace VirtualMethodsInCSharp
{
    public class DerivedClass : BaseClass
    {
        public override string VirtualMethodA()
        {
            return "This method overrides a virtual method";
        }

        public new string NonVirtualMethod()
        {
            return "This method hides the inherited non virtual method";
        }
    }
}
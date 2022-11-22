namespace ActionFuncInCSharp
{
    public class Child : Parent
    {
        public new string Name => GetType().Name;
    }
}
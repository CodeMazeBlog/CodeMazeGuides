namespace GenericsInCSharp
{
    public class GenericMethods<T>
    {
        public void SwapElements(ref T left, ref T right)
        {
            T tempVar;
            tempVar = left;
            left = right;
            right = tempVar;
        }
    }
}

namespace ManagedVsUnmanagedCodeInCSharp
{
    public static class GenerationInspector
    {
        public static int GetArrayGeneration(int sizeInBytes)
        {
            var array = new byte[sizeInBytes];

            return GC.GetGeneration(array);
        }
    }
}

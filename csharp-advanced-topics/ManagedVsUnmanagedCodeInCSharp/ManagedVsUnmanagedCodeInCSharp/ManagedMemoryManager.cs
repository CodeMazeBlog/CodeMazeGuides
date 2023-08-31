namespace ManagedVsUnmanagedCodeInCSharp
{
    public class ManagedMemoryManager
    {
        private readonly List<int> _numbers;

        public ManagedMemoryManager()
        {
            _numbers = new List<int>();
        }

        public void AllocateMemory()
        {
            for (var i = 0; i < 1000000; i++)
            {
                _numbers.Add(i);
            }
        }
    }
}

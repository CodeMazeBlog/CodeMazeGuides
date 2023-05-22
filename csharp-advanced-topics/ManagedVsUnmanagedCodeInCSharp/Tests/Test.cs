using ManagedVsUnmanagedCodeInCSharp;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void GivenManagedResource_WhenAllocatingMemory_ThenSucceed()
        {
            var memoryManager = new ManagedMemoryManager();

            memoryManager.AllocateMemory();
            var memoryAfterAllocation = GC.GetTotalMemory(false);

            Assert.NotEqual(0, memoryAfterAllocation);
        }

        [Fact]
        public void GivenUnmangedResource_WhenAllocatingMemory_ThenSucceed()
        {
            var size = 1024;
            var ptr = UnmanagedMemoryManager.AllocateUnmanagedMemory(size);

            Assert.NotEqual(IntPtr.Zero, ptr);

            UnmanagedMemoryManager.FreeUnmanagedMemory(ptr);
        }
    }
}
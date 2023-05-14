using ManagedVsUnmanagedCodeInCSharp;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void WhenAllocateMemoryCalled_ThenAllocateMemory()
        {
            var memoryManager = new ManagedMemoryManager();

            var memoryBeforeAllocation = GC.GetTotalMemory(false);
            memoryManager.AllocateMemory();
            var memoryAfterAllocation = GC.GetTotalMemory(false);

            Assert.True(memoryBeforeAllocation < memoryAfterAllocation);
        }
    }
}
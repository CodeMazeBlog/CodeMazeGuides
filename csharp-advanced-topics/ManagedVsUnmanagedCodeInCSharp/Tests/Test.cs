using System.Runtime.InteropServices;
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
        public void GivenUnmanagedResource_WhenAllocatingMemory_ThenSucceed()
        {
            var size = 1024;
            var ptr = UnmanagedMemoryManager.AllocateUnmanagedMemory(size);

            try
            {
                Assert.NotEqual(IntPtr.Zero, ptr);
            }
            finally
            {
                UnmanagedMemoryManager.FreeUnmanagedMemory(ptr);
            }
        }

        [Fact]
        public void GivenLargeArray_WhenAllocated_ThenItIsInTheOldestGeneration()
        {
            var generation = GenerationInspector.GetArrayGeneration(100_000);

            Assert.Equal(GC.MaxGeneration, generation);
        }

        [Fact]
        public void GivenSmallArray_WhenAllocated_ThenItIsInAYoungerGeneration()
        {
            var generation = GenerationInspector.GetArrayGeneration(1_000);

            Assert.True(generation < GC.MaxGeneration);
        }

        [Fact]
        public void GivenUnmanagedBuffer_WhenDisposed_ThenHandleIsClosed()
        {
            var buffer = new UnmanagedBuffer(1024);
            Marshal.WriteByte(buffer.DangerousGetHandle(), 42);

            Assert.Equal(42, Marshal.ReadByte(buffer.DangerousGetHandle()));

            buffer.Dispose();

            Assert.True(buffer.IsClosed);
        }

        [Fact]
        public void GivenStringBuilding_WhenMeasured_ThenConcatenationAllocatesMore()
        {
            var concatenation = StringBuildingAllocations.MeasureConcatenation(10_000);
            var stringBuilder = StringBuildingAllocations.MeasureStringBuilder(10_000);

            Assert.True(concatenation > stringBuilder * 10);
        }

        [Fact]
        public void GivenToyCarInfo_WhenPackedToOneByte_ThenItHasNoPadding()
        {
            Assert.Equal(9, Marshal.SizeOf<ToyCarInfo>());
        }

        [Fact]
        public void GivenFileWriter_WhenDataIsWritten_ThenFileHoldsIt()
        {
            var fileName = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.txt");

            try
            {
                FileWriter.WriteDataToFile(fileName, "Purple Jackets");

                Assert.Equal("Purple Jackets", File.ReadAllText(fileName));
            }
            finally
            {
                File.Delete(fileName);
            }
        }
    }
}

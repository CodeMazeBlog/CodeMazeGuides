using System.Text;

namespace ManagedVsUnmanagedCodeInCSharp
{
    public static class StringBuildingAllocations
    {
        public static long MeasureConcatenation(int count)
        {
            var allocatedBefore = GC.GetAllocatedBytesForCurrentThread();

            var str = string.Empty;
            for (var i = 0; i < count; i++)
            {
                str += i.ToString();
            }

            return GC.GetAllocatedBytesForCurrentThread() - allocatedBefore;
        }

        public static long MeasureStringBuilder(int count)
        {
            var allocatedBefore = GC.GetAllocatedBytesForCurrentThread();

            var sb = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                sb.Append(i);
            }
            var result = sb.ToString();

            return GC.GetAllocatedBytesForCurrentThread() - allocatedBefore;
        }
    }
}

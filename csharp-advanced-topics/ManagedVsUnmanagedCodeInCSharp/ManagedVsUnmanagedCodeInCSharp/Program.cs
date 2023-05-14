using System.Text;

namespace ManagedVsUnmanagedCodeInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var memoryManager = new ManagedMemoryManager();

            var memoryBeforeAllocation = GC.GetTotalMemory(false);
            memoryManager.AllocateMemory();
            var memoryAfterAllocation = GC.GetTotalMemory(false);

            Console.WriteLine($"Memory Allocated to the list: {memoryAfterAllocation - memoryBeforeAllocation} bytes");

            //Showcasing Best Practices

            // Bad practice: creating unnecessary objects
            var memoryBeforeConcat = GC.GetTotalMemory(false);
            var str = string.Empty;

            for (var i = 0; i < 10000; i++)
            {
                str += i.ToString();
            }

            var memoryAfterConcat = GC.GetTotalMemory(false);

            Console.WriteLine($"Memory used by string concatenation: {memoryAfterConcat - memoryBeforeConcat} bytes");


            // Good practice: avoiding unnecessary objects
            var memoryBeforeStringBuilder = GC.GetTotalMemory(false);
            var sb = new StringBuilder();

            for (var i = 0; i < 10000; i++)
            {
                sb.Append(i);
            }

            var result = sb.ToString();
            var memoryAfterStringBuilder = GC.GetTotalMemory(false);

            Console.WriteLine($"Memory used by StringBuilder: {memoryAfterStringBuilder - memoryBeforeStringBuilder} bytes");

            Console.WriteLine($"Result: {result}");
        }
    }
}
using System.Collections.Concurrent;

namespace ConcurrentBagInCSharp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var myConcurrentBagCount = myConcurrentBag.Count;
            var isMyConcurrentBagEmpty = myConcurrentBag.IsEmpty;
        }
    }
}
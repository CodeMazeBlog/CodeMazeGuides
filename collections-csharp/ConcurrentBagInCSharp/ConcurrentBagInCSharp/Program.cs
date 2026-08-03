namespace ConcurrentBagInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myConcurrentBag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var myConcurrentBagCount = myConcurrentBag.Count;
            var isMyConcurrentBagEmpty = myConcurrentBag.IsEmpty;
            
        }
    }
}
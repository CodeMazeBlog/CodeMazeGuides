namespace IEnumerableVsICollectionVsIListVsList
{
    public class DeferredExecutionDemo
    {
        public void ShowDeferredVsMaterialised(IEnumerable<int> numbers)
        {
            IEnumerable<int> query = numbers.Where(n => n > 10);

            Console.WriteLine(query.Count());   // runs the filter
            Console.WriteLine(query.Count());   // runs the filter again

            ICollection<int> materialised = query.ToList();

            Console.WriteLine(materialised.Count);   // reads a stored value
        }
    }
}

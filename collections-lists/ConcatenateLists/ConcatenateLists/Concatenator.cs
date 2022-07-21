namespace ConcatenateLists
{
    public class Concatenator
    {
        public List<string> UsingLoop(List<string> firstList, List<string> secondList)
        {
            var result = new List<string>(firstList.Count() + secondList.Count());

            foreach (var item in firstList)
            {
                result.Add(item);
            }

            foreach (var item in secondList)
            {
                result.Add(item);
            }

            return result;
        }

        public List<string> UsingEnumerableConcat(List<string> firstList, List<string> secondList)
        {
            return Enumerable.Concat(firstList, secondList).ToList();
        }

        public List<string> UsingEnumerableUnion(List<string> firstList, List<string> secondList)
        {
            return Enumerable.Union(firstList, secondList).ToList();
        }

        public List<string> UsingAddRange(List<string> firstList, List<string> secondList)
        {
            var result = new List<string>(firstList.Count() + secondList.Count());

            result.AddRange(firstList);
            result.AddRange(secondList);

            return result;
        }
    }
}

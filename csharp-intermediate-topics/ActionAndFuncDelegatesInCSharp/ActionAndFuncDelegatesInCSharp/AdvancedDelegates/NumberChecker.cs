namespace ActionAndFuncDelegatesInCSharp.AdvancedDelegates
{
    public class NumberChecker
    {
        public List<int> EvenNumbers { get; }

        public NumberChecker()
        {
            EvenNumbers = new List<int>();
        }

        public void Add(int number)
        {
            if (IsEvenNumber(number))
                EvenNumbers.Add(number);
        }

        public void Add(List<int> numbers, Predicate<int> evenNumberPredicate)
        {
            if (EvenNumbers.Any())
                EvenNumbers.Clear();

            foreach (var num in numbers)
            {
                if (evenNumberPredicate(num))
                    EvenNumbers.Add(num);
            }
        }

        public bool IsEvenNumber(int num) => (num % 2 == 0);
    }
}

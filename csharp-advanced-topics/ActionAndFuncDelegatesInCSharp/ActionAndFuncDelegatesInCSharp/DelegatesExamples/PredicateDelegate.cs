namespace ActionAndFuncDelegatesInCSharp.DelegatesExamples
{
    public class PredicateDelegate
    {
        public void Execute()
        {
            Predicate<int> PredicateCheck = CheckIfAdult;

            bool result = PredicateCheck(12);

            if (result)
            {
                Console.WriteLine("I am not an Adult");
            }
            else
            {
                Console.WriteLine("I am an Adult");
            }

            //Anonymous Function Implementation
            Predicate<int> AnonPredicateCheck = delegate (int a)
            {
                return a > 18;
            };

            bool anonResult = AnonPredicateCheck(19);

            if (anonResult)
            {
                Console.WriteLine("I am an Adult");
            }

            //Lambda Implementation
            Predicate<int> LamdaPredicateCheck = a =>
            {
                return a < 18;
            };

            bool lamdaResult = LamdaPredicateCheck(10);

            if (lamdaResult)
            {
                Console.WriteLine("I am not an Adult");
            }
        }

        public bool CheckIfAdult(int age)
        {
            return age > 18 ? true : false;
        }
    }
}
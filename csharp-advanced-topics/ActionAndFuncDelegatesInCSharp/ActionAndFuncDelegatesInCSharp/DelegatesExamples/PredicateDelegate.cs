using System;
namespace ActionAndFuncDelegatesInCSharp.DelegatesExamples
{
	public class PredicateDelegate
	{
		public void Execute()
		{
            //Predicate Examples
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

            //Predicate Anonymous Implementation
            Predicate<int> AnonPredicateCheck = delegate (int a)
            {
                return a > 18;
            };

            bool anonResult = AnonPredicateCheck(19);

            if (anonResult)
            {
                Console.WriteLine("I am an Adult");
            }

            //Predicate Lamda Implementation
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
            if (age > 18)
            {
                return true;
            }

            return false;
        }
    }
}


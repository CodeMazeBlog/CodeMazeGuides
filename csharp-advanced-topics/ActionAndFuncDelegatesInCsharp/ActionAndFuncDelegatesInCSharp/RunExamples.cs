namespace ActionAndFuncDelegatesInCSharp
{
    public class RunExamples
    {

        /// <summary>
        /// Can be used to encapsulate
        /// void returning methods
        /// with no input arguments.
        /// </summary>
 
        private Action delegateA;


        /// <summary>
        /// Can be used to encapsulate
        /// void returning methods
        /// with four input arguments.
        /// </summary>
        
        private Action<string, string, string, int> delegateB;


        /// <summary>
        /// Can be used to encapsulate
        /// string returning methods
        /// with no input arguments.
        /// </summary>
        
        private Func<string> delegateC;


        /// <summary>
        /// Can be used to encapsulate
        /// string returning methods
        /// with four input arguments.
        /// </summary>

        private Func<string, string, string, int, string> delegateD;


        #region public methods

        public void RunFirstMethodExample()
        {
            // Assignation
            delegateA = FirstMethod;
            // Exécution
            delegateA();
        }


        public void RunSecondMethodExample()
        {
            // Assignation
            delegateB = SecondMethod;
            // Exécution
            delegateB("Henry", "Johnson", "NY", 32);
        }


        public string RunThirdMethodExample()
        {
            // Assignation
            delegateC = ThirdMethod;
            // Exécution
            var msgC = delegateC();

            Console.WriteLine(msgC);

            return msgC;
        }


        public string RunFourthMethodExample()
        {

            // Assignation
            delegateD = FourthMethod;
            // Exécution
            var msgD = delegateD("Henry", "Johnson", "NY", 32);

            Console.WriteLine(msgD);

            return msgD;
        }

        #endregion



        #region private methods

        private void FirstMethod()
        {
            Console.WriteLine("hello from first method !");
        }



        private void SecondMethod(string firstName, string lastName, string city, int age)
        {
            Console.WriteLine($"Second Method says: Hello {firstName} {lastName}. You live in {city}. You are {age} old.");
        }



        private string ThirdMethod()
        {
            return "hello from third method!";
        }



        private string FourthMethod(string firstName, string lastName, string city, int age)
        {
            return $"Fourth Method says: Hello {firstName} {lastName}. You live in {city}. You are {age} old.";
        }

        #endregion

    }
}

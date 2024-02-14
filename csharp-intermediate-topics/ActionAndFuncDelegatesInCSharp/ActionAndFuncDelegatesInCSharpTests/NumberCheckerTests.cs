using ActionAndFuncDelegatesInCSharp.AdvancedDelegates;

namespace ActionAndFuncDelegatesInCSharpTests
{
    public class NumberCheckerTests
    {
        private NumberChecker numberChecker;

        [SetUp]
        public void Setup()
        {
            numberChecker = new NumberChecker();
        }

        [TestCase(8)]
        public void GivenAnEvenNumber_WhenIsEvenNumberRun_ThenReturnTrue(int number)
        {
            var result = numberChecker.IsEvenNumber(number);

            Assert.IsTrue(result);
        }

        [TestCase(5)]
        public void GivenAnOddNumber_WhenIsEvenNumberRun_ThenReturnFalse(int number)
        {
            var result = numberChecker.IsEvenNumber(number);

            Assert.IsFalse(result);
        }

        [TestCase(6)]
        public void GivenANumber_WhenCheckAddNumber_ThenEveNumbersCountIsEqualToOne(int number)
        {
            numberChecker.Add(number);

            Assert.IsTrue(numberChecker.EvenNumbers.Count() == 1);
        }


        [TestCase(5)]
        public void GivenANumber_WhenCheckAddNumber_ThenEvenNumbersCountIsEqualToZero(int number)
        {
            numberChecker.Add(number);

            Assert.IsTrue(numberChecker.EvenNumbers.Count() == 0);
        }


        [TestCase(new int[] { 1, 2, 3, 4 })]
        public void GivenAListOfNumbers_WhenAddNumber_ThenEvenNumbersCountIsEqualToTwo(int[] numbers)
        {
            numberChecker.Add(numbers.ToList(), numberChecker.IsEvenNumber);

            Assert.IsTrue(numberChecker.EvenNumbers.Count() == 2);
        }

        [TestCase(new int[] { 7, 11, 3, 43 })]
        public void GivenAListOfNumbers_WhenAddNumber_ThenEvenNumbersCountIsEqualToZero(int[] numbers)
        {
            numberChecker.Add(numbers.ToList(), numberChecker.IsEvenNumber);

            Assert.IsTrue(numberChecker.EvenNumbers.Count() == 0);
        }
    }
}

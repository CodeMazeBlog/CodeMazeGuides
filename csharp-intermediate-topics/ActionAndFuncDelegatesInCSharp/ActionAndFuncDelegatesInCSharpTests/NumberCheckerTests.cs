using ActionAndFuncDelegatesInCSharp;
using ActionAndFuncDelegatesInCSharp.AdvancedDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Given_An_Even_Number_When_Is_Even_Number_Run_Then_Return_True(int number)
        {
            var result = numberChecker.isEvenNumber(number);
            Assert.IsTrue(result);
        }

        [TestCase(5)]
        public void Given_An_Odd_Number_When_Is_Even_Number_Run_Then_Return_False(int number)
        {
            var result = numberChecker.isEvenNumber(number);
            Assert.IsFalse(result);
        }

        [TestCase(6)]
        public void Given_A_Number_When_Check_Add_Number_Then_EveNumbers_Count_Is_Equal_To_One(int number)
        {
            numberChecker.Add(number);

            Assert.IsTrue(numberChecker.EvenNumbers.Count() == 1);
        }


        [TestCase(5)]
        public void Given_A_Number_When_Check_Add_Number_Then_EvenNumbers_Count_Is_Equal_To_Zero(int number)
        {
            numberChecker.Add(number);

            Assert.IsTrue(numberChecker.EvenNumbers.Count() == 0);
        }


        [TestCase(new int[] { 1, 2, 3, 4 })]
        public void Given_A_List_Of_Numbers_When_Add_Number_Then_EvenNumbers_Count_Is_Equal_To_Two(int[] numbers)
        {
            numberChecker.Add(numbers.ToList(), numberChecker.isEvenNumber);

            Assert.IsTrue(numberChecker.EvenNumbers.Count() == 2);
        }

        [TestCase(new int[] { 7, 11, 3, 43 })]
        public void Given_A_List_Of_Numbers_When_Add_Number_Then_EvenNumbers_Count_Is_Equal_To_Zero(int[] numbers)
        {
            numberChecker.Add(numbers.ToList(), numberChecker.isEvenNumber);

            Assert.IsTrue(numberChecker.EvenNumbers.Count() == 0);
        }
    }
}

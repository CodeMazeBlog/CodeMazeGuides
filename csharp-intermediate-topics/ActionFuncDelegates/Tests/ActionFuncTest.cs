using ActionFuncDelegates;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class ActionFuncTest
    {
        [Fact]
        public void CheckAddedNumberToListForAction()
        {
            var number = 7;
            var numberList = new NumberList();
            numberList.AddNumberUsingAction(7);
            Assert.Equal(numberList.NumberLists[0], number);
        }

        [Fact]
        public void CheckAddedNumberToListForFunc()
        {
            var number = new List<int>() { 7, 8 };
            var numberList = new NumberList();
            numberList.AddNumbersUsingFunc(5, 8);
            Assert.Equal(numberList.NumberLists[1], number[1]);
        }

        [Fact]
        public void CheckAddedNumberCountToListForFunc()
        {
            var number = new List<int>() { 7, 8 };
            var numberList = new NumberList();
            numberList.AddNumbersUsingFunc(5, 8);
            Assert.Equal(numberList.NumberLists.Count, number.Count);
        }
    }
}
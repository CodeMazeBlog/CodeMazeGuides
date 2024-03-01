namespace DelegateActionFuncTest
{
    using ActionFunc;
    public class DelegateActionFuncUnitTest
    {
        [Fact]
        public void GivenNoInputs_WhenSumNumbers_ThenPrintResults()
        {
            // Act
            var result = ActionFuncs.SumFunc();

            //Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void GivenNoInputs_WhenAdditionTwoNumbers_ThenPrintResults()
        {
            // Act
            var result = ActionFuncs.AdditionAction();

            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void GivenNoInputs_WhenSubtractionTwoNumbers_ThenPrintResults()
        {
            // Act
            var result = ActionFuncs.SubtractionAction();

            //Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void GivenNoInputs_WhenMultiplicationTwoNumbers_ThenPrintResults()
        {
            // Act
            var result = ActionFuncs.MultiplicationAction();

            //Assert
            Assert.Equal(200, result);
        }

        [Fact]
        public void GivenNoInputs_WhenDivisionTwoNumbers_ThenPrintResults()
        {
            // Act
            var result = ActionFuncs.DivisionAction();

            //Assert
            Assert.Equal(2, result);
        }
    }
}
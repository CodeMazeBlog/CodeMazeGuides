namespace ActionFuncInCSharp.Tests
{
    public class DelegateUnitTest
    {
        [Fact]
        public void WhenAddingMethodsToDelegate_ThenInvocationListLengthShouldbeEqualToNumberOfMethods()
        {
            var intBasicCalculator = new IntBasicCalculator();

            BasicCalcPrintDelegate<int> basicCalcPrintGeneric = intBasicCalculator.AdditionPrint;
            basicCalcPrintGeneric += intBasicCalculator.SubtractionPrint;
            basicCalcPrintGeneric += intBasicCalculator.MultiplicationPrint;
            basicCalcPrintGeneric += intBasicCalculator.DivisionPrint;

            Assert.Equal(4, basicCalcPrintGeneric.GetInvocationList().Length);
        }

        [Fact]
        public void WhenAssignMethodToGenericDelegate_ThenDelegateCallSuccessfully()
        {
            var intBasicCalculator = new IntBasicCalculator();
            BasicCalcDelegate<int> basicCalcPrintGenericInt = intBasicCalculator.Addition;
            int additionResultInt = basicCalcPrintGenericInt(3, 3);

            var floatBasicCalculator = new FloatBasicCalculator();
            BasicCalcDelegate<float> basicCalcPrintGenericFloat = floatBasicCalculator.Addition;
            float additionResultFloat = basicCalcPrintGenericFloat(3.1f, 3.1f);

            Assert.Equal(6, additionResultInt);
            Assert.Equal(6.2, additionResultFloat, 2);
        }
    }
}
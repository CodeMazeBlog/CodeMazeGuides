using ActionAndFuncDelegatesInCSharp;

namespace ActionAndFuncDelegatesInCSharpUnitTests
{
    [TestClass]
    public class ActionAndFuncDelegatesInCSharpUnitTest
    {
        [TestMethod]
        public void WhenInputIsValid_ThenReturnValidResponse()
        {
            Func<int, string> calculateGrade;
            var grade = new Grade();

            calculateGrade = x => grade.CalculateGradeFromTotalMarks(x);
            var result = calculateGrade(200);

            Assert.AreEqual("A", result);
        }
    }
}
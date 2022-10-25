using ActionAndFuncDelegatesInCSharp;

namespace ActionAndFuncDelegatesInCSharpUnitTests
{
    [TestClass]
    public class ActionAndFuncDelegatesInCSharpUnitTest
    {
        public double Average { get; set; }

        [DataTestMethod]
        [DataRow(50, "D")]
        [DataRow(120, "C")]
        [DataRow(190, "B")]
        [DataRow(220, "A")]
        public void WhenInputIsValid_ThenReturnValidResponse(int marks, string expected)
        {
            var grade = new Grade();

            Func<int, string> calculateGrade = totalMarks => grade.CalculateGradeFromTotalMarks(totalMarks);
            var actual = calculateGrade(marks);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DynamicData(nameof(MarksList))]
        public void WhenMarksAreValid_ThenReturnValidAverage(List<int> marks, double expected)
        {
            var grade = new Grade();

            Action<List<int>> calculateAverageMarks = grade.CalculateAverageMarks;
            calculateAverageMarks(marks);

            Assert.AreEqual(expected, grade.AverageScore);
        }

        public static IEnumerable<object[]> MarksList =>
            new List<object[]>
            {
                new object[] { new List<int>() { 50, 50, 50 }, 50 },
                new object[] { new List<int>() { 50, 50 }, 50 },
                new object[] { new List<int>() { 50 }, 50 }
            };
    }
}
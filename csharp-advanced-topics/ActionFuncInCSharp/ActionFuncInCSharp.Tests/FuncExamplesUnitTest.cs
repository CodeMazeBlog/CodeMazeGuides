namespace ActionFuncInCSharp.Tests
{
    public class FuncExamplesUnitTest
    {
        [Fact]
        public void WhenAssignMethodToFuncDelegate_ThenFuncCallSuccessfully()
        {
            FloatBasicCalculator floatBasicCalculator = new();
            Func<float, float, float> calcFunc = floatBasicCalculator.Addition;

            Assert.Equal(5.2f, calcFunc(2.1f, 3.1f));
        }

        [Fact]
        public void WhenPassFuncDelegateAsArgument_ThenFuncCallSuccessfully()
        {
            List<string> progLang = new() { "C", "C++", "C#", "F#", "Rust", "Go" };
            Func<string, bool> whereFunc = (string s) => s.Contains('C');
            List<string> cLang = progLang.Where(whereFunc).ToList();

            Assert.All(cLang, item => Assert.Contains('C', item));
        }

        [Fact]
        public void WhenFuncAsMethodReturnType_ThenFuncCallSuccessfully() 
        {
            Func<int, int, int>? func = FuncExamples.GetCalcFunc(BasicCalculationEnum.Addition);
            var actual = func?.Invoke(5, 5);
            var expected = 10;
    
            Assert.Equal(expected, actual);
        }
    }
}

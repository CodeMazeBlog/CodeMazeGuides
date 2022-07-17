using ActionAndFuncSample;
using Xunit;

namespace ActionFuncSampleTest
{
    public class UnitTest1
    {
        [Fact]
        public void CovarianceTest()
        {
            var res = Program.CovarianceMethod(s => s + "world", "hello");
            Assert.True(res is string);
            res = Program.CovarianceMethod(s => int.Parse(s), "1");
            Assert.True(res is int);
        }

        [Fact]
        public void ContraVarianceTest()
        {
            var res = Program.ContraVarianceMethod(SampleFunc, "hello");
            Assert.True(res == "hello-world");
        }

        private string SampleFunc(object s)
        {
            if(s.GetType() == typeof(string))
            {
                return $"{s}-world";
            }
            return null;
        }
    }
}
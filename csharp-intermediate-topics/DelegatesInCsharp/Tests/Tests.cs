namespace Tests
{
    public class Tests
    {
        private const string TEXT = "programming delegates in csharp";

        [Fact]
        public void IsTextInLowerCaseValid_ReturnTrue()
        {
            var myDelegate = new MyDelegate(ConvertToLower);
            var textInLowerCase = myDelegate("PROGRAMMING DELEGATES IN CSHARP");
            Assert.True(TEXT.ToLower().Equals(textInLowerCase), "Error converting text to lower case.");
        }

        [Fact]
        public void IsHraValid_ReturnTrue()
        {
            Func<double, double> func = new Func<double, double>(GetHra);
            var result = func(1000.00);
            Assert.True(result == 400.00, "Error in hra calculation.");
        }

        private void Display(string str) => Console.WriteLine(str);
        private string ConvertToLower(string str) => str.ToLower();
        private static double GetHra(double basic) => (double)(basic * .4);

        private delegate string MyDelegate(string str);
    }
}
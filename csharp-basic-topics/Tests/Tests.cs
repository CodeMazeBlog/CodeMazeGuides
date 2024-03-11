namespace Tests
{
    public class Tests
    {
        const string TEXT = "PROGRAMMING DELEGATES IN CSHARPa";

        [Fact]
        public void IsTextInLowerCaseValid_ReturnTrue()
        {
            var myDelegate = new MyDelegate(ConvertToLower);
            var textInLowerCase = myDelegate("programming delegates in csharp");
            Assert.True(TEXT.ToLower().Equals(textInLowerCase), "Error converting text to lower case.");
        }

        [Fact]
        public void IsHraValid_ReturnTrue()
        {
            Func<double, double> func = new Func<double, double>(GetHra);
            var result = func(1000.00);

            Assert.True(result == 400.00, "Error in hra calculation.");
        }
        void Display(string str) => Console.WriteLine(str);
        string ConvertToLower(string str) => str.ToLower();
        static double GetHra(double basic) => (double)(basic * .4);
        delegate string MyDelegate(string str);
    }
}
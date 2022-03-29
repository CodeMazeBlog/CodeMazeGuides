using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace StringToTitleCaseUnitTest
{
    [TestClass]
    public class StringToTitleCaseUnitTest
    {
        private readonly TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        [TestMethod]
        public void GivenToTitleCase_WhenStringIsPassed_CoversionToTitleCaseSuccessful()
        {
            Assert.AreEqual("A Tale Of Two Cities", textInfo.ToTitleCase("a tale oF tWo citIes"));

            Assert.AreEqual("Harry Potter And The Deathly Hallows", textInfo.ToTitleCase("harry potter and the Deathly hallows"));
        }

        [TestMethod]
        public void GivenToTitleCase_WhenWordWithAllUpperCaseIsPassed_ConversionToTitleCaseNotSuccessful()
        {
            Assert.AreNotEqual("Oliver Twist", textInfo.ToTitleCase("OLIVER TWIST"));
        }

        [TestMethod]
        public void GivenToTitleCase_WhenWordWithAllUpperCaseIsPassed_ConversionToTitleCaseSuccessful()
        {
            Assert.AreEqual("Oliver Twist", textInfo.ToTitleCase("OLIVER TWIST".ToLower()));
        }
    }
}

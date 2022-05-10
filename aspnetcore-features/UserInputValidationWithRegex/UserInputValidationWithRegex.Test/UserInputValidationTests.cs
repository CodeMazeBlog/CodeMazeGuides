using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace UserInputValidationWithRegex.Test
{
    [TestClass]
    public class UserInputValidationTests
    {
        [TestMethod]
        public void WhenEmployeeName_OnlyValidCharacters()
        {
            var regex = new Regex(@"^[a-zA-Z\s.\-']{2,}$");

            Assert.IsTrue(regex.IsMatch("John T. Potter"));
            Assert.IsTrue(regex.IsMatch("Beverly D'Angelo"));
            Assert.IsTrue(regex.IsMatch("Jean-Marie Collot"));

            Assert.IsFalse(regex.IsMatch("Hal9000"));
            Assert.IsFalse(regex.IsMatch("//**|"));
            Assert.IsFalse(regex.IsMatch("John (Smith)"));
        }

        [TestMethod]
        public void WhenAddress_OnlyValidFormat()
        {
            var regex = new Regex(@"^[0-9]+\s[a-zA-Z\s\-']{2,}.\s?[a-zA-Z\s\(\),]{2,}$");
            
            Assert.IsTrue(regex.IsMatch("23839 Arroyo Park Rd.Dayton, Minnesota(MN)"));
            Assert.IsTrue(regex.IsMatch("365 Payson St. San Dimas, California(CA)"));

            Assert.IsFalse(regex.IsMatch("Travis Park, Utah"));
            Assert.IsFalse(regex.IsMatch("//**|"));
        }

        [TestMethod]
        public void WhenZipCode_OnlyValidCodesAccepted()
        {
            var regex = new Regex(@"^[0-9]{5}$|^[0-9]{5}-?[0-9]{4}$");

            Assert.IsTrue(regex.IsMatch("12345"));
            Assert.IsTrue(regex.IsMatch("12345-6789"));
            Assert.IsTrue(regex.IsMatch("123456789"));

            Assert.IsFalse(regex.IsMatch("1234-5678"));
            Assert.IsFalse(regex.IsMatch("12345678"));
        }

        [TestMethod]
        public void WhenSocialSecurityNumber_OnlyValidNumbersAccepted()
        {
            var regex = new Regex(@"^(?!(000|666|9))\d{3}-(?!00)\d{2}-(?!0000)\d{4}$");

            Assert.IsTrue(regex.IsMatch("123-45-6789"));

            Assert.IsFalse(regex.IsMatch("000-45-6789"));
            Assert.IsFalse(regex.IsMatch("123-00-6789"));
            Assert.IsFalse(regex.IsMatch("123-45-0000"));
            Assert.IsFalse(regex.IsMatch("666-45-6789"));
            Assert.IsFalse(regex.IsMatch("900-45-6789"));
            Assert.IsFalse(regex.IsMatch("999-45-6789"));
            Assert.IsFalse(regex.IsMatch("123-45-678"));
        }

        [TestMethod]
        public void WhenUsername_OnlyValidUsername()
        {
            var regex = new Regex(@"^[\w.\-]{2,18}$");

            Assert.IsTrue(regex.IsMatch("john.smith.182"));
            Assert.IsTrue(regex.IsMatch("john-smith-182"));

            Assert.IsFalse(regex.IsMatch("a"));
            Assert.IsFalse(regex.IsMatch("john/smith/182"));
            Assert.IsFalse(regex.IsMatch("user.name.too.long.1234567890"));
        }

        [TestMethod]
        public void WhenPassword_RequiresCertainCharacters()
        {
            var regex = new Regex(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,32}$");

            Assert.IsTrue(regex.IsMatch("My.hors3.is.red!"));

            Assert.IsFalse(regex.IsMatch("my.hors3.is.red!"));
            Assert.IsFalse(regex.IsMatch("MY.HORS3.IS.RED!"));
            Assert.IsFalse(regex.IsMatch("My.horse.is.red!"));
            Assert.IsFalse(regex.IsMatch("Myhors3isred"));
        }

        [TestMethod]
        public void WhenEmail_OnlyValidEmails()
        {
            var regex = new Regex(@"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$");

            Assert.IsTrue(regex.IsMatch("john.smith@example.com"));
            Assert.IsTrue(regex.IsMatch("john@example.de"));

            Assert.IsFalse(regex.IsMatch("john.smith.example.com"));
            Assert.IsFalse(regex.IsMatch("john.smith@example"));
            Assert.IsFalse(regex.IsMatch("@example.com"));
        }

        [TestMethod]
        public void WhenPhoneNumber_OnlyValidEmails()
        {
            var regex = new Regex(@"^([+]?\d{1,2}[-\s]?|)\d{3}[-\s]?\d{3}[-\s]?\d{4}$");

            Assert.IsTrue(regex.IsMatch("+1 123 456 7890"));
            Assert.IsTrue(regex.IsMatch("123 456 7890"));
            Assert.IsTrue(regex.IsMatch("1234567890"));

            Assert.IsFalse(regex.IsMatch("123 456 7890 123"));
            Assert.IsFalse(regex.IsMatch("+1.123.456.7890"));
        }
    }
}
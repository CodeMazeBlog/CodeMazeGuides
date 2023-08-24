using StaticVsNonstaticMethods;

namespace Tests
{
    [TestClass]
    public class UserTest
    {
        private readonly User _user = new();

        [TestMethod]
        [DataRow("")]
        [DataRow("a")]
        [DataRow("A")]
        [DataRow("1")]
        [DataRow("aA")]
        [DataRow("A1")]
        [DataRow("1a")]
        [DataRow("aaaaAAAA")]
        [DataRow("AAAA1111")]
        [DataRow("1111aaaa")]
        public void GivenWrongPassword_WhenCheckingPasswords_ThenReturnShouldBeFalse(
            string wrongPassword)
        {
            Assert.IsFalse(User.CheckPassword(wrongPassword));
        }

        [TestMethod]
        [DataRow("aA1")]
        [DataRow("1aA")]
        [DataRow("tEsT123")]
        [DataRow("TESTtest1234")]
        [DataRow("Tt1Ee2Ss3Tt4")]
        public void GivenCorrectPassword_WhenCheckingPasswords_ThenReturnShouldBeTrue(
            string correctPassword)
        {
            Assert.IsTrue(User.CheckPassword(correctPassword));
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("abc")]
        [DataRow("abc@")]
        [DataRow("@abc")]
        [DataRow(".abc@efg.")]
        public void GivenWrongEmail_WhenCheckingEmails_ThenReturnShouldBeFalse(
            string wrongEmail)
        {
            _user.Email = wrongEmail;
            Assert.IsFalse(_user.CheckEmail());
        }

        [TestMethod]
        [DataRow("abc@efg.com")]
        [DataRow("abc.efg@abc.efg")]
        [DataRow("abc-efg@abc.efg")]
        [DataRow("abc_efg@abc.efg.jdk")]
        public void GivenCorrectEmail_WhenCheckingEmails_ThenReturnShouldBeTrue(
            string correctEmail)
        {
            _user.Email = correctEmail;
            Assert.IsTrue(_user.CheckEmail());
        }
    }
}
using Bunit;
using UserInputValidationWithRegex.Pages;
using Xunit;

namespace UserInputValidationWithRegex.Test
{
    public class EmployeeFormTests : TestContext
    {
        [Theory]
        [InlineData("Harry T. Potter", true)]
        [InlineData("HAL9000", false)]
        [InlineData("///*!", false)]
        public void WhenEnterEmployeeName_ThenOnlyValidDataAccepted(string value, bool shouldPassValidation)
        {
            var cut = RenderComponent<EmployeeRegistration>();
            cut.Find("input#name").Change(value);
            cut.Find("button").Click();

            var messages = cut.FindAll("li.validation-message");
            var errorMessage = "Employee name contains invalid characters.";
            if (shouldPassValidation)
                Assert.DoesNotContain(messages, x => x.TextContent == errorMessage);
            else
                Assert.Contains(messages, x => x.TextContent == errorMessage);
        }

        [Theory]
        [InlineData("23839 Arroyo Park Rd.Dayton, Minnesota(MN)", true)]
        [InlineData("Travis Park, Utah", false)]
        [InlineData("///*!", false)]
        public void WhenEnterAddress_ThenOnlyValidDataAccepted(string value, bool shouldPassValidation)
        {
            var cut = RenderComponent<EmployeeRegistration>();
            cut.Find("input#address").Change(value);
            cut.Find("button").Click();

            var messages = cut.FindAll("li.validation-message");
            var errorMessage = "Wrong address format.";
            if (shouldPassValidation)
                Assert.DoesNotContain(messages, x => x.TextContent == errorMessage);
            else
                Assert.Contains(messages, x => x.TextContent == errorMessage);
        }

        [Theory]
        [InlineData("12345", true)]
        [InlineData("123456789", true)]
        [InlineData("12345-6789", true)]
        [InlineData("12345678", false)]
        public void WhenEnterZipCode_ThenOnlyValidDataAccepted(string value, bool shouldPassValidation)
        {
            var cut = RenderComponent<EmployeeRegistration>();
            cut.Find("input#zipCode").Change(value);
            cut.Find("button").Click();

            var messages = cut.FindAll("li.validation-message");
            var errorMessage = "Invalid zip code format.";
            if (shouldPassValidation)
                Assert.DoesNotContain(messages, x => x.TextContent == errorMessage);
            else
                Assert.Contains(messages, x => x.TextContent == errorMessage);
        }

        [Theory]
        [InlineData("123-45-6789", true)]
        [InlineData("123-45-678", false)]
        [InlineData("000-45-6789", false)]
        [InlineData("123-00-6789", false)]
        [InlineData("123-45-0000", false)]
        [InlineData("666-45-6789", false)]
        [InlineData("923-45-6789", false)]
        public void WhenEnterSocialSecurityNumber_ThenOnlyValidDataAccepted(string value, bool shouldPassValidation)
        {
            var cut = RenderComponent<EmployeeRegistration>();
            cut.Find("input#socialSecurityNumber").Change(value);
            cut.Find("button").Click();

            var messages = cut.FindAll("li.validation-message");
            var errorMessage = "Invalid SSN.";
            if (shouldPassValidation)
                Assert.DoesNotContain(messages, x => x.TextContent == errorMessage);
            else
                Assert.Contains(messages, x => x.TextContent == errorMessage);
        }

        [Theory]
        [InlineData("john.smith.182", true)]
        [InlineData("john/smith/182", false)]
        [InlineData("a", false)]
        [InlineData("user.name.too.long.1234567890", false)]
        public void WhenEnterUsername_ThenOnlyValidDataAccepted(string value, bool shouldPassValidation)
        {
            var cut = RenderComponent<EmployeeRegistration>();
            cut.Find("input#username").Change(value);
            cut.Find("button").Click();

            var messages = cut.FindAll("li.validation-message");
            var errorMessage = "Invalid username.";
            if (shouldPassValidation)
                Assert.DoesNotContain(messages, x => x.TextContent == errorMessage);
            else
                Assert.Contains(messages, x => x.TextContent == errorMessage);
        }

        [Theory]
        [InlineData("Admin1234!", true)]
        [InlineData("admin1234!", false)]
        [InlineData("ADMIN1234!", false)]
        [InlineData("Adminxxxx!", false)]
        [InlineData("Admin12345", false)]
        [InlineData("Ad1!", false)]
        public void WhenEnterPassword_ThenOnlyValidDataAccepted(string value, bool shouldPassValidation)
        {
            var cut = RenderComponent<EmployeeRegistration>();
            cut.Find("input#password").Change(value);
            cut.Find("button").Click();

            var messages = cut.FindAll("li.validation-message");
            var errorMessage = "Password doesn't meet security rules.";
            if (shouldPassValidation)
                Assert.DoesNotContain(messages, x => x.TextContent == errorMessage);
            else
                Assert.Contains(messages, x => x.TextContent == errorMessage);
        }

        [Theory]
        [InlineData("john.smith@example.com", true)]
        [InlineData("john.smith.example.com", false)]
        [InlineData("john.smith@example", false)]
        public void WhenEnterEmail_ThenOnlyValidDataAccepted(string value, bool shouldPassValidation)
        {
            var cut = RenderComponent<EmployeeRegistration>();
            cut.Find("input#email").Change(value);
            cut.Find("button").Click();

            var messages = cut.FindAll("li.validation-message");
            var errorMessage = "Invalid email address.";
            if (shouldPassValidation)
                Assert.DoesNotContain(messages, x => x.TextContent == errorMessage);
            else
                Assert.Contains(messages, x => x.TextContent == errorMessage);
        }

        [Theory]
        [InlineData("123 456 7890", true)]
        [InlineData("+1 123 456 7890", true)]
        [InlineData("+1 123 456 78901", false)]
        [InlineData("+1.123.456.7890", false)]
        public void WhenEnterPhoneNumber_ThenOnlyValidDataAccepted(string value, bool shouldPassValidation)
        {
            var cut = RenderComponent<EmployeeRegistration>();
            cut.Find("input#phone").Change(value);
            cut.Find("button").Click();

            var messages = cut.FindAll("li.validation-message");
            var errorMessage = "Invalid phone number.";
            if (shouldPassValidation)
                Assert.DoesNotContain(messages, x => x.TextContent == errorMessage);
            else
                Assert.Contains(messages, x => x.TextContent == errorMessage);
        }
    }
}
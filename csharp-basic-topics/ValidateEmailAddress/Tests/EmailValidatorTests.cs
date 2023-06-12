using ValidateEmailAddress;

namespace Tests
{
    public class EmailValidatorTests
    {
        [Theory]
        [InlineData("code@maze.com")]
        [InlineData("code.maze@code.com")]
        public void GivenAListOfValidEmail_WhenUsingTheMailAddressClass_ThenReturnTrue(string email)
        {
            var emailValidator = new EmailValidator();
            var result = emailValidator.ValidateUsingMailAddress(email);

            Assert.True(result);
        }

        [Theory]
        [InlineData("@maze.com")]
        [InlineData("@")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData("code.maze@")]
        [InlineData("code.maze.com")]
        public void GivenAListOfInvalidEmail_WhenUsingTheMailAddressClass_ThenReturnFalse(string email)
        {
            var emailValidator = new EmailValidator();
            var result = emailValidator.ValidateUsingMailAddress(email);

            Assert.False(result);
        }

        [Theory]
        [InlineData("code@maze.com")]
        [InlineData("code.maze@code.com")]
        public void GivenAListOfValidEmail_WhenUsingTheEmailMailAddressAttributeClass_ThenReturnTrue(string email)
        {
            var emailValidator = new EmailValidator();
            var result = emailValidator.ValidateUsingEmailAddressAttribute(email);

            Assert.True(result);
        }

        [Theory]
        [InlineData("@maze.com")]
        [InlineData("@")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData("code.maze@")]
        [InlineData("code.maze.com")]
        public void GivenAListOfInvalidEmail_WhenUsingTheEmailMailAddressAttributeClass_ThenReturnFalse(string email)
        {
            var emailValidator = new EmailValidator();
            var result = emailValidator.ValidateUsingEmailAddressAttribute(email);

            Assert.False(result);
        }

        [Theory]
        [InlineData("code@maze.com")]
        [InlineData("code.maze@code.com")]
        public void GivenAListOfValidEmail_WhenUsingRegex_ThenReturnTrue(string email)
        {
            var emailValidator = new EmailValidator();
            var result = emailValidator.ValidateUsingRegex(email);

            Assert.True(result);
        }

        [Theory]
        [InlineData("@maze.com")]
        [InlineData("@")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData("code.maze@")]
        [InlineData("code.maze.com")]
        public void GivenAListOfInvalidEmail_WhenUsingRegex_ThenReturnFalse(string email)
        {
            var emailValidator = new EmailValidator();
            var result = emailValidator.ValidateUsingRegex(email);

            Assert.False(result);
        }

        [Theory]
        [InlineData("code@maze.com")]
        [InlineData("code.maze@code.com")]
        public void GivenAListOfValidEmail_WhenUsingFluentValidation_ThenReturnTrue(string email)
        {
            var emailValidator = new EmailValidator();
            var result = emailValidator.ValidateUsingFluentValidator(email);

            Assert.True(result);
        }

        [Theory]
        [InlineData("@maze.com")]
        [InlineData("@")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData("code.maze@")]
        [InlineData("code.maze.com")]
        public void GivenAListOfInvalidEmail_WhenUsingFluentValidation_ThenReturnFalse(string email)
        {
            var emailValidator = new EmailValidator();
            var result = emailValidator.ValidateUsingFluentValidator(email);

            Assert.False(result);
        }
    }
}
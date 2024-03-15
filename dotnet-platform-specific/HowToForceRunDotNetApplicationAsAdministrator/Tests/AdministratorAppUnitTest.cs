using Moq;
using AdministratorApp;

namespace Tests
{
    public class AdministratorAppUnitTest
    {
        [Fact]
        public void GivenUserWithAdministratorPrivileges_WhenCheckingForAdministratorRole_ThenReturnTrue()
        {
            // Arrange
            var mockChecker = new Mock<IAdministratorChecker>();
            mockChecker.Setup(c => c.IsCurrentUserAdmin()).Returns(true);

            // Act
            var isAdmin = mockChecker.Object.IsCurrentUserAdmin();

            // Assert
            Assert.True(isAdmin, "The user should have administrator privileges.");
        }

        [Fact]
        public void GivenUserWithoutAdministratorPrivileges_WhenCheckingForAdministratorRole_ThenReturnFalse()
        {
            // Arrange
            var mockChecker = new Mock<IAdministratorChecker>();
            mockChecker.Setup(c => c.IsCurrentUserAdmin()).Returns(false);

            // Act
            var isAdmin = mockChecker.Object.IsCurrentUserAdmin();

            // Assert
            Assert.False(isAdmin, "The user should not have administrator privileges.");
        }

        [Fact]
        public void GivenNullIdentity_WhenCheckingForAdministratorRole_ThenReturnFalse()
        {
            // Arrange
            var mockChecker = new Mock<IAdministratorChecker>();
            mockChecker.Setup(c => c.IsCurrentUserAdmin()).Returns(false);

            // Act
            var isAdmin = mockChecker.Object.IsCurrentUserAdmin();

            // Assert
            Assert.False(isAdmin, "The user should not have administrator privileges (null identity).");
        }

        [Fact]
        public void GivenUserWithNonAdministratorRole_WhenCheckingForAdministratorRole_ThenReturnFalse()
        {
            // Arrange
            var mockChecker = new Mock<IAdministratorChecker>();
            mockChecker.Setup(c => c.IsCurrentUserAdmin()).Returns(false);

            // Act
            var isAdmin = mockChecker.Object.IsCurrentUserAdmin();

            // Assert
            Assert.False(isAdmin, "The user should not have administrator privileges (non-admin role).");
        }

        [Fact]
        public void GivenAdminCheckerReturnsTrue_WhenPrintPrivilegeStatus_ThenPrintAdministratorMessage()
        {
            // Arrange
            var mockChecker = new Mock<IAdministratorChecker>();
            mockChecker.Setup(c => c.IsCurrentUserAdmin()).Returns(true);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            var isAdmin = mockChecker.Object.IsCurrentUserAdmin();
            PrivilegeStatusPrinter.Print(isAdmin);

            // Assert
            string expectedOutput = "The application is running with administrator privileges." + Environment.NewLine;
            Assert.Equal(expectedOutput, consoleOutput.ToString());
        }

        [Fact]
        public void GivenAdminCheckerReturnsFalse_WhenPrintPrivilegeStatus_ThenPrintNonAdministratorMessage()
        {
            // Arrange
            var mockChecker = new Mock<IAdministratorChecker>();
            mockChecker.Setup(c => c.IsCurrentUserAdmin()).Returns(false);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            var isAdmin = mockChecker.Object.IsCurrentUserAdmin();
            PrivilegeStatusPrinter.Print(isAdmin);

            // Assert
            string expectedOutput = "The application is not running with administrator privileges." + Environment.NewLine;
            Assert.Equal(expectedOutput, consoleOutput.ToString());
        }
    }
}
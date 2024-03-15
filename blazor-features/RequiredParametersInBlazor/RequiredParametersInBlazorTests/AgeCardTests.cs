using RequiredParametersInBlazor;
using RequiredParametersInBlazor.Components;

namespace RequiredParametersInBlazor.Tests
{
    public class AgeCardTests : TestContext
    {
        [Fact]
        public void GivenTheYearOfBirth_WhenNumericYearOfBirthIsPassedToComponent_ThenAgeIsReturned()
        {
            // Arrange
            var yearOfBirthInput = 1993;
            var ageCard = RenderComponent<AgeCard>(parameters => parameters
                .Add(p => p.YearOfBirthInput, yearOfBirthInput)
            );

            // Act
            var age = ageCard.Instance.GetAge();

            // Assert
            var expectedAge = GetCurrentYear() - yearOfBirthInput;
            Assert.Equal(expectedAge, age);
        }

        private int GetCurrentYear()
        {
            return DateTime.UtcNow.Year;
        }
    }
}

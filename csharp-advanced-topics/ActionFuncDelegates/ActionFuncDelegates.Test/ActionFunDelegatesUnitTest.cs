namespace ActionFuncDelegates.Test
{
    public class ActionFunDelegatesUnitTest
    {
        [Fact]
        public void When_RunIsInvoked_Then_ShouldBePrintedDiscountForAllCustomers()
        {            
                    // Arrange
                using (var sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    // Act
                    ActionDelegate.Run();

                    // Assert
                    var expectedOutput = "Action Delegate" + Environment.NewLine + 
                                         "Customers Platinum get 28% Discount" + Environment.NewLine +
                                         "Customers Gold get 18% Discount" + Environment.NewLine +
                                         "Customers Silver get 8% Discount" + Environment.NewLine;

                    Assert.Equal(expectedOutput, sw.ToString());
                }
            
        }

        [Theory]
        [InlineData(25, "Platinum", "Customers Platinum get 28% Discount")]
        [InlineData(15, "Gold", "Customers Gold get 18% Discount")]
        [InlineData(5, "Silver", "Customers Silver get 8% Discount")]
        public void When_GetBenefitIsInvoked_DiscountShouldBePrintedCorrectly(int amount, string customer, string expectedOutput)
        {
                // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                ActionDelegate.GetBenefit(ActionDelegate.PrintDiscount, amount, customer);

                // Assert
                Assert.Equal(expectedOutput + Environment.NewLine, sw.ToString());
            }
        }

        [Fact]
        public void WhenRunIsInvoked_ThenAddedDiscountShouldBePrintedForAllCustomers()
        {
                // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                FuncDelegate.Run();

                // Assert
                var expectedOutput = "Func Delegate" + Environment.NewLine +
                                     "Customers Platinum get 50% Discount" + Environment.NewLine +
                                     "Customers Gold get 30% Discount" + Environment.NewLine +
                                     "Customers Silver get 10% Discount" + Environment.NewLine;

                Assert.Equal(expectedOutput, sw.ToString());
            }
        }

        [Theory]
        [InlineData(25, "Platinum", "Customers Platinum get 50% Discount")]
        [InlineData(15, "Gold", "Customers Gold get 30% Discount")]
        [InlineData(5, "Silver", "Customers Silver get 10% Discount")]
        public void WhenGetBenefitIsInvoked_ThenDiscountShouldBeAddedCorrectly(int amount, string customer, string expectedOutput)
        {
                // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                FuncDelegate.GetBenefit(FuncDelegate.AddDiscount, amount, customer);

                // Assert
                Assert.Equal(expectedOutput + Environment.NewLine, sw.ToString());
            }
        }

        [Theory]
        [InlineData(25, 50)]
        [InlineData(15, 30)]
        [InlineData(5, 10)]
        public void WhenAddDiscountIsInvoked_ThenDiscountShouldBeReturnedCorrectly(int amount, int expectedDiscount)
        {
            // Act
            var result = FuncDelegate.AddDiscount(amount);

            // Assert
            Assert.Equal(expectedDiscount, result);
        }
    }
}
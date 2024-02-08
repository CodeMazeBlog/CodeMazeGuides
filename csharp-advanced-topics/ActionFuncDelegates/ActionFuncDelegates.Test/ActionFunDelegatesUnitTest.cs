using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates.Test
{
    public class ActionFunDelegatesUnitTest
    {
        [Fact]
        public void Run_ShouldPrintDiscountsForAllCustomers()
        {
            
                // Arrange
                using (var sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    // Act
                    ActionDelegate.Run();

                    // Assert
                    string expectedOutput = "Action Delegate" + Environment.NewLine + 
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
        public void GetBenefit_ShouldPrintCorrectDiscount(int amount, string customer, string expectedOutput)
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
        public void Run_ShouldPrintAddedDiscountsForAllCustomers()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                FuncDelegate.Run();

                // Assert
                string expectedOutput = "Func Delegate" + Environment.NewLine +
                                        "Customers Platinum get 50% Discount" + Environment.NewLine +
                                        "Customers Gold get 30% Discount" + Environment.NewLine +
                                        "Customers Silver get 10% Discount" + Environment.NewLine;

                Assert.Equal(expectedOutput, sw.ToString());
            }
        }

        [Theory]
        [InlineData(25, "Platinum", 50, "Customers Platinum get 50% Discount")]
        [InlineData(15, "Gold", 30, "Customers Gold get 30% Discount")]
        [InlineData(5, "Silver", 10, "Customers Silver get 10% Discount")]
        public void GetBenefit_ShouldAddCorrectDiscount(int amount, string customer, int expectedDiscount, string expectedOutput)
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
        public void AddDiscount_ShouldReturnCorrectDiscount(int amount, int expectedDiscount)
        {
            // Act
            int result = FuncDelegate.AddDiscount(amount);

            // Assert
            Assert.Equal(expectedDiscount, result);
        }
    }
}


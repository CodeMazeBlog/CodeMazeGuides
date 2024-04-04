using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PassingByValueVsPassingByReference.Test
{
    [TestClass]
    public class PassingByReferenceVsPassByValueUnitTest
    {
        [TestMethod]
        public void GivenDoubleNumber_WhenPassedToUpdatePriceByPercentMethod_ThenNoChangeWillAffectTheNumber()
        {
            // Given
            double number = 30;
            int discountRate = 50;

            // When
            Program.UpdatePriceByPercent(number, discountRate);

            //Assert
            Assert.AreEqual(number, 30);
        }

        [TestMethod]
        public void GivenDoubleNumber_WhenPassedToUpdatePriceByPercentByRefMethod_ThenWillChangeTheNumberValue()
        {
            // Given
            double number = 30;
            int discountRate = 50;

            // When
            Program.UpdatePriceByPercentByRef(ref number, discountRate);

            //Assert
            Assert.AreEqual(number, 15);
        }

        [TestMethod]
        public void GivenProductObject_WhenPassedToApplyDiscountMethod_ThenWillChangeThePrice()
        {
            // Given
            var product = new Product
            {
                ProductId = 1,
                Price = 60,
                Cost = 10
            };

            int discountRate = 50;

            // When
            Program.ApplyDiscount(product, discountRate);

            //Assert
            Assert.AreEqual(product.Price, 30);
        }

        [TestMethod]
        public void GivenArrayOfDoubleNumbers_WhenPassedToUpdatePricesByPercentMethod_ThenWillChangeEveryItemInIt()
        {
            // Given
            double[] originalPrices = [30, 15, 21.5, 50];
            double[] prices = [.. originalPrices];

            int discountRate = -50;

            // When
            Program.UpdatePricesByPercent(prices, discountRate);

            //Assert
            for (int i = 0; i < originalPrices.Length; i++)
            {
                Assert.AreEqual(prices[i], originalPrices[i] * 50 / 100);
            }
        }

        [TestMethod]
        public void GivenAnUnassignedDoubleVariable_WhenPassedToMakeItZeroMethod_ThenWillHaveZero()
        {
            // Given
            double zero;

            // When
            Program.MakeItZero(out zero);

            //Assert
            Assert.AreEqual(zero, 0);
        }
    }
}

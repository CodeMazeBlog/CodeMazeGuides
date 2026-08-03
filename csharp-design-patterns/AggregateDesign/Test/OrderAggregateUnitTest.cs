using AggregateDesign.Domain;

namespace Test
{
    public class OrderAggregateUnitTest
    {
        [Fact]
        public void WhenOrderContainsItems_ThenOrderTotalReturnsPrice()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 2, 59.99M);

            Assert.Equal(119.98M, order.OrderTotal);
        }

        [Fact]
        public void WhenAddingOrderPayment_ThenPaidAmountIncreases()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 2, 59.99M);
            order.AddPayment(30.0M);

            Assert.Equal(30.0M, order.PaidAmount);
        }

        [Fact]
        public void WhenAddingOrderPayment_ThenCantAddNegativePayments()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 2, 59.99M);
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                order.AddPayment(-30.0M);
            });

            Assert.Equal("Amount must be positive.", exception.Message);
        }

        [Fact]
        public void WhenAddingOrderPayment_ThenPaymentCantExceedOrderTotal()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 1, 59.99M);
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                order.AddPayment(200.0M);
            });

            Assert.Equal("Payment can't exceed order total", exception.Message);
        }

        [Fact]
        public void WhenAddingOrderItem_ThenCantAddItemAfterPaymentMade()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 1, 50.00M);
            order.AddPayment(50.0M);

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                order.AddItem("Gildone Men's Crew T-Shirt", 1, 10.00M);
            });

            Assert.Equal("Can't modify order once payment has been done.", exception.Message);
        }

        [Fact]
        public void WhenRemovingOrderItem_ThenCantRemoveItemAfterPaymentMade()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 1, 50.00M);
            order.AddPayment(50.0M);

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                order.RemoveItem("Cloudsoft Women's Running Shoes");
            });

            Assert.Equal("Can't modify order once payment has been done.", exception.Message);
        }

        [Fact]
        public void WhenShippingOrder_ThenCantShipEmptyOrder()
        {
            Order order = new();
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                order.ShipOrder();                
            });

            Assert.Equal("Can´t ship an order with no items.", exception.Message);
        }

        [Fact]
        public void WhenShippingOrder_ThenCantShipUnpaidOrder()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 1, 59.99M);
            order.AddItem("Gildone Men's Crew T-Shirt", 3, 18.99M);
            order.AddPayment(20.0M);

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                order.ShipOrder();
            });

            Assert.Equal("Can´t ship order unpaid order.", exception.Message);
        }

        [Fact]
        public void WhenShippingOrder_ThenCantShipAlreadyShippedOrder()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 1, 59.99M);
            order.AddItem("Gildone Men's Crew T-Shirt", 3, 18.99M);
            order.AddPayment(order.OrderTotal);
            order.ShipOrder();

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                order.ShipOrder();
            });

            Assert.Equal("Order already shipped to customer.", exception.Message);
        }

        [Fact]
        public void WhenAddingItems_ThenCantAddItemWithoutName()
        {
            Order order = new();
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                order.AddItem("", 1, 59.99M);
            });

            Assert.Equal("'itemName' cannot be null or empty. (Parameter 'itemName')", exception.Message);
        }

        [Fact]
        public void WhenAddingItems_ThenCantAddItemWithZeroQuantity()
        {
            Order order = new();
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                order.AddItem("Cloudsoft Women's Running Shoes", 0, 59.99M);
            });

            Assert.Equal("Quantity must be at least one. (Parameter 'quantity')", exception.Message);
        }

        [Fact]
        public void WhenAddingItems_ThenCantAddItemWithZeroUnitPrice()
        {
            Order order = new();
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                order.AddItem("Cloudsoft Women's Running Shoes", 1, .0M);
            });

            Assert.Equal("Unit price must be above zero. (Parameter 'unitPrice')", exception.Message);
        }

        [Fact]
        public void WhenAddingItemQuantity_ThenQuantityIsAdded()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 1, 19.99M);
            order.AddQuantity("Cloudsoft Women's Running Shoes", 10);

            Assert.Equal((int?)11, (int?)order.Items.FirstOrDefault(x => x.ItemName.Equals("Cloudsoft Women's Running Shoes"))?.Quantity);
        }

        [Fact]
        public void WhenWithdrawingItemQuantity_ThenQuantityIsWithdrawn()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 10, 19.99M);
            order.WithdrawQuantity("Cloudsoft Women's Running Shoes", 5);

            Assert.Equal((int?)5, (int?)order.Items.FirstOrDefault(x => x.ItemName.Equals("Cloudsoft Women's Running Shoes"))?.Quantity);
        }

        [Fact]
        public void WhenWithdrawingItemQuantity_ThenCantWithdrawAllUnits()
        {
            Order order = new();
            order.AddItem("Cloudsoft Women's Running Shoes", 10, 19.99M);
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                order.WithdrawQuantity("Cloudsoft Women's Running Shoes", 10);
            });

            Assert.Equal("Can't remove all units from an order item. Remove the entire order item instead.", exception.Message);
        }
    }
}

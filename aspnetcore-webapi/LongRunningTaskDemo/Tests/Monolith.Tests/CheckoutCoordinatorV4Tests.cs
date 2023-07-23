using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Models;
using Monolith.ShoppingCartApi;
using Monolith.ShoppingCartApi.Coordinators;
using Monolith.ShoppingCartApi.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests.Monolith.Tests
{
    [TestFixture]
    public class CheckoutCoordinatorV4Tests
    {
        private Mock<ICheckoutProcessingChannel> _checkoutProcessingChannel;
        private CheckoutCoordinatorV4 _sut;
        private CheckoutRequest _request;

        [SetUp]
        public void Setup()
        {
            _checkoutProcessingChannel = new Mock<ICheckoutProcessingChannel>();

            _sut = new CheckoutCoordinatorV4(_checkoutProcessingChannel.Object);

            _request = new CheckoutRequest
            {
                CustomerId = Guid.NewGuid(),
                LineItems = new List<OrderLineItem>(),
                PaymentInfo = new PaymentInfo()
            };
        }

        [Test]
        public async Task WhenInvoked_ProcessCheckoutAsyncReturnsInProgressOrder()
        {
            var response = await _sut.ProcessCheckoutAsync(_request);

            Assert.AreEqual(OrderStatus.Inprogress, response.OrderStatus);
            Assert.AreEqual("Your order is in progress and you will receive an email with all details once the processing completes.", response.Message);
        }

        [Test]
        public async Task WhenInvoked_ProcessCheckoutAsyncSendsDataChannel()
        {
            await _sut.ProcessCheckoutAsync(_request);

            _checkoutProcessingChannel.Verify(x => x.AddQueueItemAsync(It.IsAny<QueueItem>(),It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

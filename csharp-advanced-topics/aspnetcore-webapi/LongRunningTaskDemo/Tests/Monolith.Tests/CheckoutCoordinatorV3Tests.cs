using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;
using Monolith.ShoppingCartApi;
using Monolith.ShoppingCartApi.Coordinators;
using Moq;
using NUnit.Framework;

namespace Tests.Monolith.Tests
{
    [TestFixture]
    public class CheckoutCoordinatorV3Tests
    {
        private Mock<IObserver<QueueItem>> _checkoutStream;
        private CheckoutCoordinatorV3 _sut;
        private CheckoutRequest _request;

        [SetUp]
        public void Setup()
        {
            _checkoutStream = new Mock<IObserver<QueueItem>>();           
            
            _sut = new CheckoutCoordinatorV3(_checkoutStream.Object);

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
        public async Task WhenInvoked_ProcessCheckoutAsyncSendsDataToObservableStream()
        {
            await _sut.ProcessCheckoutAsync(_request);

            _checkoutStream.Verify(x=>x.OnNext(It.IsAny<QueueItem>()), Times.Once);         
        }
    }
}

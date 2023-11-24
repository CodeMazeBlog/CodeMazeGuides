using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;
using Microservice.ShoppingCartApi;
using NUnit.Framework;

namespace Tests.Microservices.Tests
{
    [TestFixture]
    public class CheckoutProcessorTests
    {
        private CheckoutProcessor _sut;
        private CheckoutRequest _request;        

        [SetUp]
        public void Setup()
        {         
            _sut = new CheckoutProcessor();

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
        public async Task WhenInvoked_ProcessCheckoutAddsDataToCheckoutQueue()
        {
            var response = await _sut.ProcessCheckoutAsync(_request);
            
            Task.Factory.StartNew(() =>
            {
                foreach (var item in _sut.CheckoutQueue.GetConsumingEnumerable())
                {
                    Assert.AreEqual(response.OrderId, item.OrderId);
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
}

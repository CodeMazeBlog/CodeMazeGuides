using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;
using Monolith.ShoppingCartApi.Coordinators;
using Monolith.ShoppingCartApi.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests.Monolith.Tests
{
    [TestFixture]
    public class CheckoutCoordinatorV2Tests
    {
        private Mock<IStockValidator> _stockValidator;
        private Mock<ITaxCalculator> _taxCalculator;
        private Mock<IPaymentProcessor> _paymentProcessor;
        private Mock<IReceiptGenerator> _receiptGenerator;
        private CheckoutCoordinatorV2 _sut;
        private CheckoutRequest _request;
        private readonly TimeSpan _asyncOpWaitTime = TimeSpan.FromMilliseconds(500);

        [SetUp]
        public void Setup()
        {
            _stockValidator = new Mock<IStockValidator>();
            _taxCalculator = new Mock<ITaxCalculator>();
            _paymentProcessor = new Mock<IPaymentProcessor>();
            _receiptGenerator = new Mock<IReceiptGenerator>();

            _stockValidator.Setup(m => m.ValidateAsync(It.IsAny<IEnumerable<OrderLineItem>>())).ReturnsAsync(true);
            _taxCalculator.Setup(m => m.CalculateTaxAsync(It.IsAny<Guid>(), It.IsAny<IEnumerable<OrderLineItem>>())).ReturnsAsync(20);
            _paymentProcessor.Setup(m => m.ProcessAsync(It.IsAny<Guid>(), It.IsAny<PaymentInfo>(), It.IsAny<int>())).ReturnsAsync(true);

            _sut = new CheckoutCoordinatorV2(_stockValidator.Object,
                                             _taxCalculator.Object,
                                             _paymentProcessor.Object,
                                             _receiptGenerator.Object);

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
        public async Task WhenStockValidationAndPaymentIsSuccessful_ProcessCheckoutAsyncCallsAllCheckoutProcessMethods()
        {
            await _sut.ProcessCheckoutAsync(_request);
            await Task.Delay(_asyncOpWaitTime);

            _stockValidator.Verify(x => x.ValidateAsync(It.IsAny<IEnumerable<OrderLineItem>>()), Times.Once);
            _taxCalculator.Verify(x => x.CalculateTaxAsync(It.IsAny<Guid>(), It.IsAny<IEnumerable<OrderLineItem>>()), Times.Once);
            _paymentProcessor.Verify(x => x.ProcessAsync(It.IsAny<Guid>(), It.IsAny<PaymentInfo>(), It.IsAny<int>()), Times.Once);
            _receiptGenerator.Verify(x => x.GenerateAsync(It.IsAny<Guid>(), It.IsAny<CheckoutResponse>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task WhenStockValidationFails_ProcessCheckoutAsyncCallsProcessFailuresAsync()
        {
            _stockValidator.Setup(m => m.ValidateAsync(It.IsAny<IEnumerable<OrderLineItem>>())).ReturnsAsync(false);

            await _sut.ProcessCheckoutAsync(_request);
            await Task.Delay(_asyncOpWaitTime);

            _receiptGenerator.Verify(x => x.ProcessFailuresAsync(It.IsAny<Guid>(), It.IsAny<CheckoutResponse>()), Times.Once);
        }

        [Test]
        public async Task WhenPaymentFails_ProcessCheckoutAsyncCallsProcessFailuresAsync()
        {
            _paymentProcessor.Setup(m => m.ProcessAsync(It.IsAny<Guid>(), It.IsAny<PaymentInfo>(), It.IsAny<int>())).ReturnsAsync(false);

            await _sut.ProcessCheckoutAsync(_request);
            await Task.Delay(_asyncOpWaitTime);
            
            _receiptGenerator.Verify(x => x.ProcessFailuresAsync(It.IsAny<Guid>(), It.IsAny<CheckoutResponse>()), Times.Once);
        }
    }
}

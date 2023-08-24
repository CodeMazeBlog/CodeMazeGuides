using Microsoft.Extensions.Logging;
using Moq;
using SwashbuckleVsNSwag.Models.Customers;
using SwashbuckleVsNSwag.Repositories.CustomerRepository;
using SwashbuckleVsNSwag.Swashbuckle.Controllers;

namespace SwashbuckleVsNSwag.NSwag.Tests
{
    public class CustomerConsollerTest
    {
        private Mock<ILogger<CustomerController>> _logger;
        private Mock<ICustomerRepository> _customerRepository;
        private CustomerController _controller;

        [SetUp]
        public void Setup()
        {
            _logger= new Mock<ILogger<CustomerController>>();
            _customerRepository= new Mock<ICustomerRepository>();

            _controller = new CustomerController(_logger.Object, _customerRepository.Object);
        }

        [Test]
        public void WhenGettingCustomerById_ThenReturnCorrectCustomer()
        {
            var customer = new Customer
            {
                CustomerId = new Guid("59d37b43-01c4-4bc7-8ccf-7d67bb10229c"),
                Name = "John Smith"
            };
            _customerRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(customer);

            var result = _controller.Get(customer.CustomerId).Value;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CustomerId, Is.EqualTo(customer.CustomerId));
            Assert.That(result.Name, Is.EqualTo(customer.Name));
        }

        [Test]
        public void WhenAddingCustomer_ThenCustomerIsStored()
        {
            var customer = new Customer
            {
                CustomerId = new Guid("59d37b43-01c4-4bc7-8ccf-7d67bb10229c"),
                Name = "John Smith"
            };

            _controller.Post(customer);

            _customerRepository.Verify(r => r.Add(It.IsAny<Customer>()), Times.Once);
        }
    }
}
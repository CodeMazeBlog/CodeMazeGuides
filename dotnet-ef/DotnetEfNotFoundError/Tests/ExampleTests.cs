using CodeFirstMigration;
using System;
using Xunit;

namespace Tests
{
    public class ExampleTests
    {
        [Fact]
        public void GivenCustomer_WhenInstansiate_ThenReturnsNoError()
        {
            //arrange
            var customer = new Customer(
                Guid.NewGuid(),
                "Jhon",
                "Doe",
                30,
                "336 Front St.Levittown, NY 11756",
                "370447746026553");

            //act & assert
            Assert.IsType<Customer>(customer);
        }
    }
}
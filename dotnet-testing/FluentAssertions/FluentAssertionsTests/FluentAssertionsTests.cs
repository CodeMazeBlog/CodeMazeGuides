using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using FluentAssertions.Execution;

namespace FluentAssertionsTests
{
    [TestClass]
    public class FluentAssertionsTests
    {
        [TestMethod]
        public void WhenTestingAString_ThenAssertStartEndAndLength()
        {
            var myTestString = "Hello, this is a test string";

            myTestString.Should().StartWith("He").And.EndWith("g").And.HaveLength(28);
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertBe()
        {
            var myTestString = "Hello, this is a test string";

            myTestString.Should().Be("Hello, this is a test string");
            myTestString.Should().NotBe("Hello, this is the wrong string");
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertBeEquivalentTo()
        {
            var myTestString = "Hello, this is a test string";

            myTestString.Should().BeEquivalentTo(myTestString);
            myTestString.Should().NotBeEquivalentTo("Helo, this is a test string");
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertBeEmpty()
        {
            var myTestString = "";
            var myOtherTestString = "Hello, this is a test string";

            myTestString.Should().BeEmpty();
            myOtherTestString.Should().NotBeEmpty();
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertBeNull()
        {
            string? myTestString = null;
            var myOtherTestString = "Hello, this is a test string";

            myTestString.Should().BeNull();
            myOtherTestString.Should().NotBeNull();
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertBeNullOrEmpty()
        {
            string? myTestString = null;
            var myOtherTestString = "Hello, this is a test string";

            myTestString.Should().BeNullOrEmpty();
            myOtherTestString.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertBeLowerCased()
        {
            // be careful of special characters as they will fail this assertion, even whitespace characters
            var myTestString = "hello";
            var myOtherTestString = "HEllo";

            myTestString.Should().BeLowerCased();
            myOtherTestString.Should().NotBeLowerCased();
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertBeUpperCased()
        {
            // be careful of special characters as they will fail this assertion, even whitespace characters
            var myTestString = "HELLO";
            var myOtherTestString = "HELlo";

            myTestString.Should().BeUpperCased();
            myOtherTestString.Should().NotBeUpperCased();
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertMatch()
        {
            var myTestString = "Hello, this is a test string";
            var myOtherTestString = "Hello, this is a test string";

            myTestString.Should().Match("Hello, this is a * string");
            myOtherTestString.Should().NotMatch("Hello, this is a ? string");
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertMatchEquivalentOf()
        {
            var myTestString = "Hello, this is a test string";
            var myOtherTestString = "Hello, this is a test string";

            myTestString.Should().MatchEquivalentOf("HElLo, this is a * string");
            myOtherTestString.Should().NotMatchEquivalentOf("HeLLo, this is a ? string");
        }

        [TestMethod]
        public void WhenTestingAString_ThenAssertMatchRegex()
        {
            var myTestString = "05/30/2022";
            var myOtherTestString = "32A-45/2022";

            myTestString.Should().MatchRegex("\\d{1,2}\\/\\d{1,2}\\/\\d{4}");
            myOtherTestString.Should().NotMatchRegex("\\d{1,2}\\/\\d{1,2}\\/\\d{4}");
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertHaveElementAt()
        {
            var customers = new List<Customer>();
            var customer = new Customer()
            {
                Id = 1,
            };
            customers.Add(customer);

            customers.Should().HaveElementAt(0, customer);
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertElementPreceding()
        {
            var customers = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer);
            customers.Add(customer2);
            customers.Add(customer3);

            customers.Should().HaveElementPreceding(customer2, customer);
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertElementSucceeding()
        {
            var customers = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer);
            customers.Add(customer2);
            customers.Add(customer3);

            customers.Should().HaveElementSucceeding(customer, customer2);
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertElementsInAscendingOrder()
        {
            var customers = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer);
            customers.Add(customer2);
            customers.Add(customer3);

            customers.Should().BeInAscendingOrder(customer => customer.Id);
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertElementsInDescendingOrder()
        {
            var customers = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);
            
            customers.Should().BeInDescendingOrder(customer => customer.Id);
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertContains()
        {
            var customers = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers.Should().Contain(customer);
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertIntersectsWith()
        {
            var customers = new List<Customer>();
            var customers2 = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers2.Add(customer3);
            customers2.Add(customer);

            customers.Should().IntersectWith(customers2);
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertOnlyHasUniqueItems()
        {
            var customers = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers.Should().OnlyHaveUniqueItems();
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertAllSatisfy()
        {
            var customers = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers.Should().AllSatisfy(customer => customer.Id.Should().BeGreaterThan(0));
        }

        [TestMethod]
        public void WhenTestingACollection_ThenAssertOfType()
        {
            var customer = new Customer(1);

            customer.Should().BeOfType<Customer>();
            customer.Should().BeSameAs(customer);
        }

        [TestMethod]
        public void WhenTestingASpecialCustomer_ThenAssertBeAssignableToCustomer()
        {
            var customer = new SpecialCustomer();

            customer.Should().BeAssignableTo<Customer>();
        }

        [TestMethod]
        public async Task WhenTestingACustomer_ThenAssertGetNullIdThrowsException()
        {
            // Customer Object with null Id property
            var customer = new Customer();
            
            // Asserts that calling GetId() will throw
            customer.Invoking(c => c.GetId()).Should().Throw<NullReferenceException>();

            // Asserts that calling GetId() will throw
            Action action = () => customer.GetId(); 

            action.Should().Throw<NullReferenceException>(); 
            
            // Asserts that calling GetId() will throw
            FluentActions.Invoking(() => customer.GetId()).Should().Throw<NullReferenceException>();

            // same assertion only async
            Func<Task> act = () => customer.GetIdAsync(); 

            await act.Should().ThrowAsync<NullReferenceException>();
        }

        [TestMethod]
        public void WhenTestingAnAssertionScope_ThenAllAssertionsAreEvaluated()
        {
            var customers = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            using (new AssertionScope()) 
            {
                customers.Should().NotBeNull();
                customers.Should().HaveCountGreaterThan(0);
                customers.Should().OnlyHaveUniqueItems();
                customers.Should().AllBeOfType<Customer>(); 
            }
        }

        [TestMethod]
        public void WhenTestingChainedAssertions_ThenAllAssertionsAreEvaluated()
        {
            var customers = new List<Customer>();
            var customer = new Customer(1);
            var customer2 = new Customer(2);
            var customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers.Should().NotBeNull().And.HaveCountGreaterThan(0); 
        }

        [TestMethod]
        public void WhenTestingACollection_ThenWhichEvaluatesElementsInCollection()
        {
            var customers = new List<Customer>();
            var customer = new Customer(99);

            customers.Add(customer);

            customers.Should().ContainSingle().Which.Should().BeEquivalentTo(new Customer { Id = 99 });
        }

        [TestMethod]
        public void WhenTestingAnAction_ThenWhichEvaluatesResultingObject()
        {
            var customer = new Customer();
            var action = () => customer.GetId();

            action.Should().Throw<NullReferenceException>().Where(ex => ex.Message != null).Where(ex => ex.Data.Count == 0);
        }
    }
}
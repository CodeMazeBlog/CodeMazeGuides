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
        public async Task GivenAString_ThenAssertStartEndAndLength()
        {
            string myTestString = "Hello, this is a test string";
            myTestString.Should().StartWith("He").And.EndWith("g").And.HaveLength(28);
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertBe()
        {
            string myTestString = "Hello, this is a test string";
            myTestString.Should().Be("Hello, this is a test string");
            myTestString.Should().NotBe("Hello, this is the wrong string");
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertBeEquivalentTo()
        {
            string myTestString = "Hello, this is a test string";
            myTestString.Should().BeEquivalentTo(myTestString);
            myTestString.Should().NotBeEquivalentTo("Helo, this is a test string");
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertBeEmpty()
        {
            string myTestString = "";
            string myOtherTestString = "Hello, this is a test string";
            myTestString.Should().BeEmpty();
            myOtherTestString.Should().NotBeEmpty();
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertBeNull()
        {
            string? myTestString = null;
            string myOtherTestString = "Hello, this is a test string";
            myTestString.Should().BeNull();
            myOtherTestString.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertBeNullOrEmpty()
        {
            string? myTestString = null;
            string myOtherTestString = "Hello, this is a test string";
            myTestString.Should().BeNullOrEmpty();
            myOtherTestString.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertBeLowerCased()
        {
            // be careful of special characters as they will fail this assertion, even whitespace characters
            string myTestString = "hello";
            string myOtherTestString = "HEllo";
            myTestString.Should().BeLowerCased();
            myOtherTestString.Should().NotBeLowerCased();
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertBeUpperCased()
        {
            // be careful of special characters as they will fail this assertion, even whitespace characters
            string myTestString = "HELLO";
            string myOtherTestString = "HELlo";
            myTestString.Should().BeUpperCased();
            myOtherTestString.Should().NotBeUpperCased();
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertMatch()
        {
            string myTestString = "Hello, this is a test string";
            string myOtherTestString = "Hello, this is a test string";
            myTestString.Should().Match("Hello, this is a * string");
            myOtherTestString.Should().NotMatch("Hello, this is a ? string");
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertMatchEquivalentOf()
        {
            string myTestString = "Hello, this is a test string";
            string myOtherTestString = "Hello, this is a test string";
            myTestString.Should().MatchEquivalentOf("HElLo, this is a * string");
            myOtherTestString.Should().NotMatchEquivalentOf("HeLLo, this is a ? string");
        }

        [TestMethod]
        public async Task GivenAString_ThenAssertMatchRegex()
        {
            string myTestString = "05/30/2022";
            string myOtherTestString = "32A-45/2022";
            myTestString.Should().MatchRegex("\\d{1,2}\\/\\d{1,2}\\/\\d{4}");
            myOtherTestString.Should().NotMatchRegex("\\d{1,2}\\/\\d{1,2}\\/\\d{4}");
        }

        [TestMethod]
        public async Task GivenACollection_ThenAssertHaveElementAt()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer()
            {
                Id = 1,
            };
            customers.Add(customer);

            customers.Should().HaveElementAt(0, customer);
        }

        [TestMethod]
        public async Task GivenACollection_ThenAssertElementPreceding()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

            customers.Add(customer);
            customers.Add(customer2);
            customers.Add(customer3);

            customers.Should().HaveElementPreceding(customer2, customer);
        }

        [TestMethod]
        public async Task GivenACollection_ThenAssertElementSucceeding()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

            customers.Add(customer);
            customers.Add(customer2);
            customers.Add(customer3);

            customers.Should().HaveElementSucceeding(customer, customer2);
        }

        [TestMethod]
        public async Task GivenACollection_ThenAssertElementsInAscendingOrder()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

            customers.Add(customer);
            customers.Add(customer2);
            customers.Add(customer3);

            customers.Should().BeInAscendingOrder(customer => customer.Id);
        }

        [TestMethod]
        public async Task GivenACollection_ThenAssertElementsInDescendingOrder()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);
            
            customers.Should().BeInDescendingOrder(customer => customer.Id);
        }

        [TestMethod]
        public async Task GivenACollection_ThenAssertContains()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers.Should().Contain(customer);
        }

        [TestMethod]
        public async Task GivenACollection_ThenAssertIntersectsWith()
        {
            List<Customer> customers = new List<Customer>();
            List<Customer> customers2 = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers2.Add(customer3);
            customers2.Add(customer);

            customers.Should().IntersectWith(customers2);
        }

        [TestMethod]
        public async Task GivenACollection_ThenAssertOnlyHasUniqueItems()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers.Should().OnlyHaveUniqueItems();
        }

        [TestMethod]
        public async Task GivenACollection_ThenAssertAllSatisfy()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers.Should().AllSatisfy(customer => customer.Id.Should().BeGreaterThan(0));
        }

        [TestMethod]
        public async Task GivenACustomer_ThenAssertOfType()
        {
            Customer customer = new Customer(1);

            customer.Should().BeOfType<Customer>();
        }

        [TestMethod]
        public async Task GivenASpecialCustomer_ThenAssertBeAssignableToCustomer()
        {
            SpecialCustomer customer = new SpecialCustomer();

            customer.Should().BeAssignableTo<Customer>();
        }

        [TestMethod]
        public async Task GivenACustomer_ThenAssertGetNullIdThrowsException()
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

        public async Task GivenAnAssertionScope_ThenAllAssertionsAreEvaluated()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

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

        public async Task GivenAssertionsChained_ThenAllAssertionsAreEvaluated()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(1);
            Customer customer2 = new Customer(2);
            Customer customer3 = new Customer(3);

            customers.Add(customer3);
            customers.Add(customer2);
            customers.Add(customer);

            customers.Should().NotBeNull().And.HaveCountGreaterThan(0); 
            Execute.Assertion.FailWith("customers list is empty").Then.ForCondition(customers.Count > 0);
        }

        public async Task GivenACollection_ThenWhichEvaluatesElementsInCollection()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer(99);

            customers.Add(customer);

            customers.Should().ContainSingle().Which.Should().BeEquivalentTo(new Customer { Id = 99 });
        }

        public async Task GivenAnAction_ThenWhichEvaluatesResultingObject()
        {
            Customer customer = new Customer();
            Action action = () => customer.GetId();

            action.Should().Throw<NullReferenceException>().Where(ex => ex.Message != null).Where(ex => ex.Data.Count > 0);
        }
    }

    public class Customer 
    {
        public Customer(int id)
        {
            Id = id;
        }

        public Customer() { }

        public int? Id { get; set; }

        public int GetId()
        {
            if (Id is null)
            {
                throw new NullReferenceException();
            }

            return Id ?? -1;
        }

        public async Task<int> GetIdAsync()
        {
            return await Task.Run(() =>
            {
                return GetId();
            });
        }
    }
    public class SpecialCustomer : Customer
    {
        public SpecialCustomer() { }
    }
}
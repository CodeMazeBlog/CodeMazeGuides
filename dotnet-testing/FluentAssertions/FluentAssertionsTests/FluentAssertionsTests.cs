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
        public async Task TestMethod1()
        {
            string thing = "";
            Customer thing2 = new Customer();
            List<Customer> myList = new List<Customer>();

            if (thing.StartsWith("He") && thing.EndsWith("g") && thing.Length == 28)
            {
                myList.Should().AllSatisfy(c => c.Id.Should().BeGreaterThan(0));

                myList.Should().NotBeNull().And.HaveCountGreaterThan(0);
                
                thing2.Invoking(c => c.GetId()).Should().Throw<NullReferenceException>();

                Action action = () => thing2.GetId();
                action.Should().Throw<NullReferenceException>().Where(e => e.Message != null).Where(e => e.Data.Count > 0);

                FluentActions.Invoking(() => thing2.GetId()).Should().Throw<ArgumentNullException>();

                Func<Task> act = () => thing2.GetIdAsync();
                await act.Should().ThrowAsync<ArgumentNullException>();

                using (new AssertionScope())
                {
                    myList.Should().NotBeNull();
                    myList.Should().HaveCountGreaterThan(0);
                    myList.Should().OnlyHaveUniqueItems();
                    myList.Should().AllBeOfType<Customer>();
                    Execute.Assertion.FailWith("The list is empty").Then.ForCondition(myList.Count > 0);
                }


                return; // this is a pass
            }
            else 
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            int num = -5;
            num.Should().BeGreaterThan(5, "because Ids under five are reserved");
        }
    }

    public class Customer 
    {
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
}
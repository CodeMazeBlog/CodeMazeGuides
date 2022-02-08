using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomCollectionTests
{
    // These tests are used to evaluate/confirm the infrastructure code.
    // They are in another file to keep things better organized.
    public class OtherTests
    {
        [Fact]
        public void ConfirmMyIntegerComparison()
        {
            var instanceOne = new MyInteger(1);
            var instanceTwo = new MyInteger(1);

            int compare = instanceOne.CompareTo(instanceTwo);

            Assert.Equal(0, compare);
        }

        [Fact]
        public void ConfirmReferenceComparison()
        {
            var instanceOne = new MyInteger(1);

            Assert.Equal(instanceOne, instanceOne);
        }
    }
}

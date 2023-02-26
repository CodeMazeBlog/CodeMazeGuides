using ActionFuncDelegatesCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesCSharpTests
{
    [TestClass]
    public class PubSubUnitTest
    {
        Publisher pub;
        List<Subscriber> subs;
        Dictionary<string, int> membershipSummary;
        [TestInitialize]
        public void Init()
        {
            pub = new Publisher();
            subs = new List<Subscriber>();
            registerMember("Fred", 1001);
            registerMember("Barny", 2002);
            registerMember("Wilma", 3003);
        }

        [TestMethod]
        public void Given_DefaultMulticastDelegate_When_MembersAreFredBarnyAndWilma_Then_PublisherRetrievesOnlyTheLastMemberAdded()
        {
            membershipSummary = pub.GetMembershipReport(false);

            Assert.IsTrue(membershipSummary.Count == 1);
            Assert.IsTrue(membershipSummary.ContainsKey("Wilma"));
            Assert.IsTrue(membershipSummary.First().Value == 3003);
        }
        [TestMethod]
        public void Given_DefaultMulticastDelegate_When_MembersAreFredBarnyAndWilma_Then_PublisherRetrievesAllMemberDetails()
        {
            membershipSummary = pub.GetMembershipReport(true);

            Assert.IsTrue(membershipSummary.ContainsKey("Fred"));
            Assert.IsTrue(membershipSummary.ContainsKey("Barny"));
            Assert.IsTrue(membershipSummary.ContainsKey("Wilma"));
            Assert.IsTrue(membershipSummary["Fred"] == 1001);
            Assert.IsTrue(membershipSummary["Barny"] == 2002);
            Assert.IsTrue(membershipSummary["Wilma"] == 3003);
        }

        private void registerMember(string name, int id)
        {
            subs.Add(new Subscriber(pub, name, id));
        }

    }
}

using static GuidClassInCSharp.GuidClassInCSharpMethods;

namespace GuidClassInCSharpTests
{
    public class Tests
    {
        [TestCase("B5724FB4-2FA0-4E68-B108-93C24A1EA6DF")]
        public void GivenCheckGuidEqualityMethod_WhenEqualGuids_ThenTrue(string guidValue)
        {
            var guidA = new Guid(guidValue);
            var guidB = new Guid("B5724FB4-2FA0-4E68-B108-93C24A1EA6DF");
            var checkEquality = CheckGuidEquality(guidA, guidB);

            Assert.That(checkEquality, Is.True);
        }

        [Test]
        public void GivenCheckGuidEqualityMethod_WhenNotEqualGuids_ThenFalse()
        {
            var guidA = Guid.NewGuid();
            var guidB = Guid.NewGuid();
            var checkEquality = CheckGuidEquality(guidA, guidB);

            Assert.That(checkEquality, Is.False);
        }

        [Test]
        public void GivenCreateEmptyGuidMethod_WhenCalled_ThenGuidEmpty()
        {
            var emptyGuid = new Guid("00000000-0000-0000-0000-000000000000");
            var createdGuid = CreateEmptyGuid();

            Assert.That(emptyGuid, Is.EqualTo(createdGuid));
        }

        [Test]
        public void GivenCreateRandomGuidMethod_WhenCalled_ThenValidGuid()
        {
            var createdGuid = CreateRandomGuid();
            var isValidGuid = Guid.TryParse(createdGuid.ToString(), out _);

            Assert.That(createdGuid, Is.Not.EqualTo(Guid.Empty));
            Assert.That(isValidGuid, Is.True);
        }

        [TestCase("e2f24f93-5f43-405f-8109-c41eff03025a")]
        public void GivenGuidToByteStringMethod_WhenGivenGuid_ThenByteArray(string guidValue)
        {
            var createdGuid = GuidToByteString(new Guid(guidValue));
            var expectedByteString = "93-4F-F2-E2-43-5F-5F-40-81-09-C4-1E-FF-03-02-5A";

            Assert.That(createdGuid, Is.EqualTo(expectedByteString));
        }

        [TestCase("e2f24f93-5f43-405f-8109-c41eff03025a")]
        public void GivenGuidToByteStringStackAllocationMethod_WhenGivenGuid_ThenByteArray(string guidValue)
        {
            var createdGuid = GuidToByteStringStackAllocation(new Guid(guidValue));
            var expectedByteString = "93-4F-F2-E2-43-5F-5F-40-81-09-C4-1E-FF-03-02-5A";

            Assert.That(createdGuid, Is.EqualTo(expectedByteString));
        }
    }
}
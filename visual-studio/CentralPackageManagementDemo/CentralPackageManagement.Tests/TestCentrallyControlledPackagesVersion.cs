using CentrallyManagedProject;
using NUnit.Framework;

namespace CentralPackageManagement.Tests
{
    [TestFixture]
    public class TestCentrallyControlledPackagesVersion
    {
        [Test]
        public void WhenCheckingCentrallyManagedPackage_ThenCentrallySetVersionIsReturned()
        {
            Assert.AreEqual("13.0.1.25517", CentrallyManagedDependencyPresenter.GetJsonVersion());
        }

        [Test, Ignore("VersionOverride is not yet supported in Jenkins builds")]
        public void WhenCheckingManagedPackageWithOverride_ThenOverridenVersionIsReturned()
        {
            Assert.AreEqual("2.0.0.0", CentrallyManagedDependencyPresenter.GetSerilogVersion());
        }
    }
}
using NUnit.Framework;
using ProjectInSubfolder;

namespace CentralPackageManagement.Subfolder.Tests
{
    [TestFixture]
    public class TestSubfolderControlledPackagesVersion
    {
        [Test]
        public void WhenCheckingCentrallyManagedPackageInSubfolder_ThenSubfolderVersionIsReturned()
        {
            Assert.AreEqual("11.0.1.21818", SubfolderManagedDependencyPresenter.GetJsonVersion());
        }
    }
}
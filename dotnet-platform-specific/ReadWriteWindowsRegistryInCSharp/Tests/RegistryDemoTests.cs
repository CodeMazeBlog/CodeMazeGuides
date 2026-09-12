namespace Tests
{
    // Every test in this class reads and writes the registry of the machine that runs it,
    // so it can only pass on Windows. The names carry "Live" and CI excludes them with
    // --filter "FullyQualifiedName!~Live". Run them locally on Windows.
    [TestClass]
    public class RegistryDemoTests
    {
        [TestMethod]
        public void WhenGetCurrentUserRootKeyName_ResultIsRootKeyCurrentUserName_Live()
        {
            var currentUserRegistryName = RegistryDemo.GetCurrentUserRootKeyName();

            Assert.AreEqual(currentUserRegistryName, Registry.CurrentUser.Name);
        }

        [TestMethod]
        public void WhenGetCurrentUserRootKeyNameWithPlatformCheck_ResultIsRootKeyCurrentUserName_Live()
        {
            var currentUserRegistryName = RegistryDemo.GetCurrentUserRootKeyNameWithPlatformCheck();

            Assert.AreEqual(currentUserRegistryName, Registry.CurrentUser.Name);
        }

        [TestMethod]
        public void WhenGetCurrentUserRootKeySubkeyCount_ResultIsGreaterThanZero_Live()
        {
            var subKeyCount = RegistryDemo.GetCurrentUserRootKeySubkeyCount();

            Assert.IsTrue(subKeyCount > 0);
        }

        [TestMethod]
        public void WhenReadAndWriteRegistryValueUsingRegistryClass_ResultIsCodeMazeRegistryDemoValue_Live()
        {
            var writtenValue = RegistryDemo.ReadAndWriteRegistryValueUsingRegistryClass();

            Assert.AreEqual(writtenValue, RegistryDemo.CodeMazeRegistryDemoValue);
        }

        [TestMethod]
        public void WhenReadAndWriteRegistryValueUsingRegistryKeyClass_ResultIsCodeMazeRegistryDemoValue_Live()
        {
            var writtenValue = RegistryDemo.ReadAndWriteRegistryValueUsingRegistryKeyClass();

            Assert.AreEqual(writtenValue, RegistryDemo.CodeMazeRegistryDemoValue);
        }

        [TestMethod]
        public void WhenGetSubKeyNames_ResultAreTwoSpecificNames_Live()
        {
            var subKeyNames = RegistryDemo.GetSubKeyNames();

            Assert.IsTrue(subKeyNames.Length == 2);
            Assert.IsTrue(subKeyNames[0].Equals("SubKey1"));
            Assert.IsTrue(subKeyNames[1].Equals("SubKey2"));
        }

        [TestMethod]
        public void WhenGetValueNames_ResultAreTwoSpecificValues_Live()
        {
            var valueNames = RegistryDemo.GetValueNames();

            Assert.IsTrue(valueNames.Length == 2);
            Assert.IsTrue(valueNames[0].Equals("Name1"));
            Assert.IsTrue(valueNames[1].Equals("Name2"));
        }

        [TestMethod]
        public void WhenGetValueKind_ResultIsString_Live()
        {
            var valueKind = RegistryDemo.GetValueKind();

            Assert.IsTrue(valueKind.Equals("String"));
        }

        [TestMethod]
        public void WhenSetRegistryKeyAccessPermissions_ResultIsTrue_Live()
        {
            var setPermission = RegistryDemo.SetRegistryKeyAccessPermissions();

            Assert.IsTrue(setPermission);
        }

        [TestMethod]
        public void WhenOpenRemoteBaseKey_ResultIsFalse_Live()
        {
            var openRemote = RegistryDemo.OpenRemoteBaseKey("machineName");

            Assert.IsFalse(openRemote);
        }
    }
}

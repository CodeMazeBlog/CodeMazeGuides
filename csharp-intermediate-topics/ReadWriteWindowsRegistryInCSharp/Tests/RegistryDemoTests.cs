namespace Tests
{
    [TestClass]
    public class RegistryDemoTests
    {
        [TestMethod]
        public void WhenGetCurrentUserRootKeyName_ResultIsRootKeyCurrentUserName()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var currentUserRegistryName = RegistryDemo.GetCurrentUserRootKeyName();

            Assert.AreEqual(currentUserRegistryName, Registry.CurrentUser.Name);
        }

        [TestMethod]
        public void WhenGetCurrentUserRootKeyNameWithPlatformCheck_ResultIsRootKeyCurrentUserName()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var currentUserRegistryName = RegistryDemo.GetCurrentUserRootKeyNameWithPlatformCheck();

            Assert.AreEqual(currentUserRegistryName, Registry.CurrentUser.Name);
        }

        [TestMethod]
        public void WhenGetCurrentUserRootKeySubkeyCount_ResultIsGreaterThanZero()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var subKeyCount = RegistryDemo.GetCurrentUserRootKeySubkeyCount();

            Assert.IsTrue(subKeyCount > 0);
        }

        [TestMethod]
        public void WhenReadAndWriteRegistryValueUsingRegistryClass_ResultIsCodeMazeRegistryDemoValue()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var writtenValue = RegistryDemo.ReadAndWriteRegistryValueUsingRegistryClass();

            Assert.AreEqual(writtenValue, RegistryDemo.CodeMazeRegistryDemoValue);
        }

        [TestMethod]
        public void WhenReadAndWriteRegistryValueUsingRegistryKeyClass_ResultIsCodeMazeRegistryDemoValue()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var writtenValue = RegistryDemo.ReadAndWriteRegistryValueUsingRegistryKeyClass();

            Assert.AreEqual(writtenValue, RegistryDemo.CodeMazeRegistryDemoValue);
        }

        [TestMethod]
        public void WhenGetSubKeyNames_ResultAreTwoSpecificNames()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var subKeyNames = RegistryDemo.GetSubKeyNames();

            Assert.IsTrue(subKeyNames.Length == 2);
            Assert.IsTrue(subKeyNames[0].Equals("SubKey1"));
            Assert.IsTrue(subKeyNames[1].Equals("SubKey2"));
        }

        [TestMethod]
        public void WhenGetValueNames_ResultAreTwoSpecificValues()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var valueNames = RegistryDemo.GetValueNames();

            Assert.IsTrue(valueNames.Length == 2);
            Assert.IsTrue(valueNames[0].Equals("Name1"));
            Assert.IsTrue(valueNames[1].Equals("Name2"));
        }

        [TestMethod]
        public void WhenGetValueKind_ResultIsString()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var valueKind = RegistryDemo.GetValueKind();

            Assert.IsTrue(valueKind.Equals("String"));
        }

        [TestMethod]
        public void WhenSetRegistryKeyAccessPermissions_ResultIsTrue()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var setPermission = RegistryDemo.SetRegistryKeyAccessPermissions();

            Assert.IsTrue(setPermission);
        }

        [TestMethod]
        public void WhenOpenRemoteBaseKey_ResultIsFalse()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var openRemote = RegistryDemo.OpenRemoteBaseKey("machineName");

            Assert.IsFalse(openRemote);
        }
    }
}
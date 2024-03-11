namespace Tests
{
    [TestClass]
    public class RetrievalOfCpuCoresTests
    {
        [TestMethod]
        public void WhenGetProcessorCount_ResultIsGreaterThanZero()
        {
            var cpuInformation = new CpuInformation();
            var logicalProcessors = cpuInformation.GetProcessorsCount();

            Assert.IsTrue(logicalProcessors > 0);
        }

        [TestMethod]
        public void WhenGetLogicalProcessors_LogicalProcessorEqualToEnvironmentProcessorCount()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var cpuInformation = new CpuInformation();
            var logicalProcessors = cpuInformation.GetLogicalProcessors();
            var processorsCount = cpuInformation.GetProcessorsCount();

            Assert.AreEqual(logicalProcessors, processorsCount);
        }

        [TestMethod]
        public void WhenGetLogicalProcessors_ResultIsGreaterThanZero()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var cpuInformation = new CpuInformation();
            var logicalProcessors = cpuInformation.GetLogicalProcessors();

            Assert.IsTrue(logicalProcessors > 0);
        }


        [TestMethod]
        public void WhenGetPhysicalProcessors_ResultIsGreaterThanZero()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var cpuInformation = new CpuInformation();
            var physicalProcessors = cpuInformation.GetPhysicalProcessors();

            Assert.IsTrue(physicalProcessors > 0);
        }

        [TestMethod]
        public void WhenGetProcessorsCount_ResultIsGreaterThanZero()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var cpuInformation = new CpuInformation();
            var processorsCount = cpuInformation.GetProcessorsCount();

            Assert.IsTrue(processorsCount > 0);
        }

        [TestMethod]
        public void WhenGetProcessorsCountWithExcludedProcessors_ResultIsGreaterThanZero()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var cpuInformation = new CpuInformation();
            var processorsCount = cpuInformation.GetExcludedProcessors();

            Assert.IsTrue(processorsCount > 0);
        }
    }
}
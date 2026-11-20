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
        public void WhenGetLogicalProcessors_ResultIsAtLeastEnvironmentProcessorCount_Live()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var cpuInformation = new CpuInformation();
            var logicalProcessors = cpuInformation.GetLogicalProcessors();
            var processorsCount = cpuInformation.GetProcessorsCount();

            Assert.IsTrue(processorsCount <= logicalProcessors);
        }

        [TestMethod]
        public void WhenGetLogicalProcessors_ResultIsGreaterThanZero_Live()
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
        public void WhenGetPhysicalProcessors_ResultIsGreaterThanZero_Live()
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
        public void WhenGetProcessorsCount_ResultIsGreaterThanZero_Live()
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
        public void WhenGetProcessorsCountWithExcludedProcessors_ResultIsGreaterThanZero_Live()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var cpuInformation = new CpuInformation();
            var processorsCount = cpuInformation.GetLogicalProcessorsIncludingExcluded();

            Assert.IsTrue(processorsCount > 0);
        }

        [TestMethod]
        public void WhenGetExcludedProcessors_ResultIsNotNegative_Live()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var cpuInformation = new CpuInformation();
            var excludedProcessors = cpuInformation.GetExcludedProcessors();

            Assert.IsTrue(excludedProcessors >= 0);
        }
    }
}
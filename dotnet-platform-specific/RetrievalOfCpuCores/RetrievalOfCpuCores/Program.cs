using RetrievalOfCpuCores;

CpuInformation cpuInformation = new();

Console.WriteLine("Processors Count: {0}", cpuInformation.GetProcessorsCount());

Console.WriteLine("Logical Processors: {0}", cpuInformation.GetLogicalProcessors());

Console.WriteLine("Number Of Cores: {0}", cpuInformation.GetNumberOfCores());

Console.WriteLine("Physical Processors: {0}", cpuInformation.GetPhysicalProcessors());

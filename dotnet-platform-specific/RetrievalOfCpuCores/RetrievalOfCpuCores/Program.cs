using RetrievalOfCpuCores;

CpuInformation cpuInformation = new();

Console.WriteLine("Processors Count: {0}", Environment.ProcessorCount);

Console.WriteLine("Logical Processors: {0}", cpuInformation.GetLogicalProcessors());

Console.WriteLine("Number Of Cores: {0}", cpuInformation.GetNumberOfCores());

Console.WriteLine("Physical Processors: {0}", cpuInformation.GetPhysicalProcessors());

Console.WriteLine("Logical Processors (including excluded Processors): {0}", cpuInformation.GetLogicalProcessorsIncludingExcluded());

Console.WriteLine("Excluded Processors: {0}", cpuInformation.GetExcludedProcessors());

var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
Parallel.For(0, 4, options, i => Console.WriteLine("Work item {0} done", i));

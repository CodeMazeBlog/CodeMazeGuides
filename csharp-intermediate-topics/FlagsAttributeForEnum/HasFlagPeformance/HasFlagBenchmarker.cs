using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;

namespace HasFlagPeformance
{
    [SimpleJob(RuntimeMoniker.Net48)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class HasFlagBenchmarker
    {
        [Benchmark]
        public bool HasFlag()
        {
            var result = false;
            for (int i = 0; i < 100000; i++)
            {
                result = UserType.Employee.HasFlag(UserType.Driver);
            }

            return result;
        }

        [Benchmark]
        public bool BitOperator()
        {
            var result = false;
            for (int i = 0; i < 100000; i++)
            {
                result = (UserType.Employee & UserType.Driver) == UserType.Driver;
            }

            return result;
        }
    }

    [Flags]
    public enum UserType
    {
        None = 0, //0b_0000
        Customer = 1, //0b_0001
        Driver = 2, //0b_0010
        Admin = 4, //0b_0100

        Employee = Driver | Admin //0b_0110
    }
}

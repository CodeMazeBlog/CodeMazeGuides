using Newtonsoft.Json;
using System.Reflection;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.

namespace CentrallyManagedProject
{
    public static class CentrallyManagedDependencyPresenter
    {
        public static string GetJsonVersion()
        {
            return GetVersion(typeof(JsonConvert).Assembly);
        }

        public static string GetSerilogVersion()
        {
            return GetVersion(typeof(Serilog.ILogger).Assembly);
        }

        private static string GetVersion(Assembly ass)
        {
            return ass.CustomAttributes.Single(a => a.AttributeType == typeof(AssemblyFileVersionAttribute)).ConstructorArguments[0].Value.ToString();
        }
    }
}
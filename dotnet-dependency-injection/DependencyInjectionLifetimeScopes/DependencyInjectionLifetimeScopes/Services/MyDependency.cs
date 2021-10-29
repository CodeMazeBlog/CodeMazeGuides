using System;

namespace DependencyInjectionLifetimeScopes
{
    public class MyDependency : IMyDependency
    {
        string InstanceId { get; } = Guid.NewGuid().ToString();

        public string GetInstanceId()
        {
            return InstanceId;
        }
    }
}

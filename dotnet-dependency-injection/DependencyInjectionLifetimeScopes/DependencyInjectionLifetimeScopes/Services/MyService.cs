using System;

namespace DependencyInjectionLifetimeScopes
{
    public class MyService : IMyTransientService, IMyScopedService, IMySingletonService
    {
        public string InstanceId { get; } = Guid.NewGuid().ToString();
    }
}

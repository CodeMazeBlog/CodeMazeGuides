using System;

namespace DependencyInjectionLifetimeScopes
{
    public class MyService : IMyService
    {
        public readonly IMyDependency _dependency;

        public MyService(IMyDependency dependency)
        {
            _dependency = dependency ?? throw new ArgumentNullException(nameof(dependency));
        }

        public string GetInstanceId()
        {
            return _dependency.GetInstanceId();
        }
    }
}

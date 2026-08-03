using HealthChecksAspNetCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MyHealthCheckTest
    {
        private readonly MyHealthCheck _myHealthCheck;

        public MyHealthCheckTest()
        {
            _myHealthCheck = new MyHealthCheck();
        }

        [Fact]
        public async Task GivenAValidHealthCheckContext_WhenCheckingHealth_ReturnsAHealthCheckResultWithValidStatus()
        {
            // Arrange
            var healthCheckContext = new HealthCheckContext();
            IEnumerable<HealthStatus> healthStatuses = new[]
            {
                HealthStatus.Healthy,
                HealthStatus.Degraded,
                HealthStatus.Unhealthy
            };

            // Act
            var result = await _myHealthCheck.CheckHealthAsync(healthCheckContext);

            // Assert
            Assert.Contains(result.Status, healthStatuses);
        }
    }
}

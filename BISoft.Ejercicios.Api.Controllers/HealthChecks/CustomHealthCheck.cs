using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BISoft.Ejercicios.Api.Controllers.HealthChecks
{
    public class CustomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            // Implement your health check logic here
            return Task.FromResult(HealthCheckResult.Unhealthy("The check indicates a healthy result."));


        }
    }
}

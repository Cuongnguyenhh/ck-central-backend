using Microsoft.Extensions.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.HealthCheck.Extensions
{
    public class CustomHealthCheck : IHealthCheck
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomHealthCheck(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public ValueTask<IHealthCheckResult> CheckAsync(CancellationToken cancellationToken = default(CancellationToken))
            => new ValueTask<IHealthCheckResult>(HealthCheckResult.FromStatus(_serviceProvider == null ? CheckStatus.Unhealthy : CheckStatus.Healthy, "Health Check DI Support"));
    }
}

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace DiagnosticListener
{
    public class HostingDiagnosticHandler : IHostedService
    {
        private readonly ICalculator _calculator;

        public HostingDiagnosticHandler(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var correlationId = Guid.NewGuid().ToString();
            var activity = new Activity("Activity");

            Console.WriteLine($"Starting Activity {correlationId}");

            try
            {
                activity.Start();
                activity.AddBaggage("CorrelationId",
                    correlationId); //All new activities will have the correlation Id with them
                await _calculator.DoSth();
            }
            finally
            {
                activity.Stop();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
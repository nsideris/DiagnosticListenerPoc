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
        private readonly DiagnosticSourceSubscriber _diagnosticSourceSubscriber;

        public HostingDiagnosticHandler(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var correlationId = Guid.NewGuid().ToString();
            var activity = new Activity("Activity");
            activity.SetParentId(correlationId);
            Console.WriteLine($"Starting Activity {correlationId}");

            try
            {
                activity.Start();
                _calculator.DoSth();
                return Task.CompletedTask;
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
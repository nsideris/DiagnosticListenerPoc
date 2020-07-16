using System.Diagnostics;
using System.Threading.Tasks;

namespace DiagnosticListener
{
    public class CalculatorConnected
    {
        public Task DoSthElse()
        {
            DiagnosticSources.PoolPointsDiagnosticSource.Write(PoolPointsListener.Activity2,
                new PoolPointsListener.SourceContext() {A = "11", B = "22"});

            return Task.CompletedTask;
        }
    }
}
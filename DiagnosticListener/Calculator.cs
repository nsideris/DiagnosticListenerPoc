using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DiagnosticListener
{
    public interface ICalculator
    {
        Task DoSth();
    }

    public class Calculator : ICalculator
    {
        public async Task DoSth()
        {
            DiagnosticSources.PoolPointsDiagnosticSource.StartDiagnostic(PoolPointsListener.DiagnosticName);

            DiagnosticSources.PoolPointsDiagnosticSource.Write(PoolPointsListener.Activity1,
                new PoolPointsListener.SourceContext() {A = "aa", B = "b"});

            var a = new CalculatorConnected();
            await a.DoSthElse();

            await DoSthelseAsync1();

            DiagnosticSources.PoolPointsDiagnosticSource.StopDiagnostic(PoolPointsListener.DiagnosticName);
        }


        public async Task DoSthelseAsync1()
        {
            DiagnosticSources.SomeOtherDiagnosticSource.StartDiagnostic(SomeOtherListener.DiagnosticName);

            DiagnosticSources.SomeOtherDiagnosticSource.Write(SomeOtherListener.Activity1,
                new SomeOtherListener.SourceContext() {A = "nis", B = "bs"});


            DiagnosticSources.SomeOtherDiagnosticSource.StopDiagnostic(SomeOtherListener.DiagnosticName);
            await Task.Delay(500);
        }
    }
}
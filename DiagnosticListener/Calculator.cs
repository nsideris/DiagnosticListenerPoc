using System;
using System.Diagnostics;

namespace DiagnosticListener
{
    public interface ICalculator
    {
        void DoSth();
    }

    public class Calculator : ICalculator
    {
        private readonly DiagnosticSource _source =
            new System.Diagnostics.DiagnosticListener(PoolPointsListener.DiagnosticName);


        private DiagnosticSourceSubscriber _diagnosticSourceSubscriber;

        public void DoSth()
        {
            
            _diagnosticSourceSubscriber = new DiagnosticSourceSubscriber(
                name => new SomeOtherListener(name),
                x => x.Name == "gsdgdsgsdgsdgdsgsd", null);
            _diagnosticSourceSubscriber.Subscribe();

            _source.Write(PoolPointsListener.DiagnosticName,
                new PoolPointsListener.SourceContext() {A = "aa", B = "b"});
        }
    }
}
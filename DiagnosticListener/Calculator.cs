using System.Diagnostics;

namespace DiagnosticListener
{
    public interface ICalculator
    {
        void DoSth();
    }

    public class Calculator : ICalculator
    {
        private readonly DiagnosticSource _source = new System.Diagnostics.DiagnosticListener("DiagnosticListener.Calculator");

        public void DoSth()
        {
            if (_source.IsEnabled("DiagnosticListener.Calculator"))
            {

                _source.Write("DiagnosticListener.Calculator.SpecificEvent", new { a = "aa", b = "b" });
            }
        }
    }
}
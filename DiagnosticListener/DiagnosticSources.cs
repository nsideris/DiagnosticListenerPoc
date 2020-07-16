using System.Diagnostics;

namespace DiagnosticListener
{
    public static class DiagnosticSources
    {
        public static readonly DiagnosticSource PoolPointsDiagnosticSource =
            new System.Diagnostics.DiagnosticListener(PoolPointsListener.DiagnosticName);

        public static readonly DiagnosticSource SomeOtherDiagnosticSource =
            new System.Diagnostics.DiagnosticListener(SomeOtherListener.DiagnosticName);
    }
}
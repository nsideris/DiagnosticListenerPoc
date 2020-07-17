using System.Diagnostics;
using System.Globalization;
using DiagnosticListener.ListenerHandlers;

namespace DiagnosticListener
{
    public static class DiagnosticExtensions
    {
        public static void StartDiagnostic(this DiagnosticSource source, string diagnosticListenerName)
        {
            source.Write($"{PoolPointsListener.DiagnosticName}.Start", null);
        }

        public static void StopDiagnostic(this DiagnosticSource source, string diagnosticListenerName)
        {
            source.Write($"{PoolPointsListener.DiagnosticName}.Stop", null);
        }
    }
}
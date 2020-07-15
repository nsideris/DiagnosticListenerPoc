using System.Diagnostics;

namespace DiagnosticListener
{
    public static class DiagnosticSourceExtensions
    {
        public static void Write(this DiagnosticSource diagnosticSource, string name, object value)
        {
            if (diagnosticSource.IsEnabled(name))
                diagnosticSource.Write(name, value);
        }
    }
}
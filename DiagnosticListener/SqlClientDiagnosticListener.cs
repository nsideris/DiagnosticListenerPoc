using System.Diagnostics;

namespace DiagnosticListener
{
    public abstract class SqlClientDiagnosticListener : ListenerHandler
    {
        public SqlClientDiagnosticListener(string name) : base(name)
        {
        }

        public override void OnStartActivity(Activity activity, object payload)
        {
            Tracer.BeginScope();
        }

        public override void OnStopActivity(Activity activity, object payload)
        {
            ProcessEvent(activity, payload);
            Tracer.Dispose();
        }

        public override void OnCustom(string name, Activity activity, object payload)
        {
            Tracer.SetAttribute(name, payload);
        }

        public abstract void ProcessEvent(Activity activity, object payload);
    }
}
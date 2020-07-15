using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DiagnosticListener
{
    public abstract class SqlClientDiagnosticListener : ListenerHandler
    {
        public SqlClientDiagnosticListener(string name) : base(name)
        {
        }

        public override void OnStartActivity(Activity activity, object payload)
        {
            throw new NotImplementedException();
        }

        public override void OnStopActivity(Activity activity, object payload)
        {
            throw new NotImplementedException();
        }

        public override void OnCustom(string name, Activity activity, object payload)
        {
            Task.Run(async () => await ProcessEvent(activity, payload));
        }

        public abstract Task ProcessEvent(Activity activity, object payload);
    }
}
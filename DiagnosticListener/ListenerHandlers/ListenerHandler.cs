using System.Diagnostics;

namespace DiagnosticListener.ListenerHandlers
{
    public abstract class ListenerHandler
    {
        public string SourceName { get; }
        protected readonly SpanTracer Tracer;

        protected ListenerHandler(string sourceName)
        {
            SourceName = sourceName;
            var activity = new Activity("ThisIsANewActivity");

            Tracer = new SpanTracer(activity);
        }

        public virtual void OnStartActivity(Activity activity, object payload)
        {
        }

        public virtual void OnStopActivity(Activity activity, object payload)
        {
        }

        public virtual void OnException(Activity activity, object payload)
        {
        }

        public virtual void OnCustom(string name, Activity activity, object payload)
        {
        }
    }
}
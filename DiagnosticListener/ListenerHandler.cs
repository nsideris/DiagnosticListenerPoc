using System.Diagnostics;
using System.Threading.Tasks;

namespace DiagnosticListener
{
    public abstract class ListenerHandler
    {
        public string SourceName { get; }

        protected ListenerHandler(string sourceName)
        {
            SourceName = sourceName;
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
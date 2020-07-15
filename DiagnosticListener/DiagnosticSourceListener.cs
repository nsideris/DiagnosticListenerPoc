using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DiagnosticListener
{
    public class DiagnosticSourceListener : IObserver<KeyValuePair<string, object>>
    {
        private readonly ListenerHandler handler;

        public DiagnosticSourceListener(ListenerHandler handler)
        {
            ListenerHandler listenerHandler = handler;
            if (listenerHandler == null)
                throw new ArgumentNullException(nameof(handler));
            this.handler = listenerHandler;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(KeyValuePair<string, object> value)
        {
            if (Activity.Current == null)
            {
// AdapterEventSource.Log.NullActivity(value.Key);
            }
            else
            {
                try
                {
                    if (value.Key.EndsWith("Start"))
                        this.handler.OnStartActivity(Activity.Current, value.Value);
                    else if (value.Key.EndsWith("Stop"))
                        this.handler.OnStopActivity(Activity.Current, value.Value);
                    else if (value.Key.EndsWith("Exception"))
                        this.handler.OnException(Activity.Current, value.Value);
                    else
                        this.handler.OnCustom(value.Key, Activity.Current, value.Value);
                }
                catch (Exception ex)
                {
                    //  AdapterEventSource.Log.UnknownErrorProcessingEvent(this.handler?.SourceName, value.Key, ex);
                }
            }
        }
    }
}
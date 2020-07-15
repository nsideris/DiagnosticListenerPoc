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
            var listenerHandler = handler;
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
            if (Activity.Current != null)
                try
                {
                    if (value.Key.EndsWith("Start"))
                        handler.OnStartActivity(Activity.Current, value.Value);
                    else if (value.Key.EndsWith("Stop"))
                        handler.OnStopActivity(Activity.Current, value.Value);
                    else if (value.Key.EndsWith("Exception"))
                        handler.OnException(Activity.Current, value.Value);
                    else
                        handler.OnCustom(value.Key, Activity.Current, value.Value);
                }
                catch (Exception ex)
                {
                    //Just Log Should never fail the process
                }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DiagnosticListener.ListenerHandlers;

namespace DiagnosticListener
{
    public class DiagnosticSourceListener : IObserver<KeyValuePair<string, object>>
    {
        private readonly ListenerHandler _handler;

        public DiagnosticSourceListener(ListenerHandler handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(KeyValuePair<string, object> value)
        {
            if (Activity.Current != null
            ) //We always pass the activity as will contain useFull Data shared across multiple listeners
            {
                try
                {
                    if (value.Key.EndsWith("Start"))
                        _handler.OnStartActivity(Activity.Current, value.Value);
                    else if (value.Key.EndsWith("Stop"))
                        _handler.OnStopActivity(Activity.Current, value.Value);
                    else if (value.Key.EndsWith("Exception"))
                        _handler.OnException(Activity.Current, value.Value);
                    else
                        _handler.OnCustom(value.Key, Activity.Current, value.Value);
                }
                catch (Exception ex)
                {
                    //Just Log Should never fail the process
                }
            }
        }
    }
}
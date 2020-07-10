using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace DiagnosticListener
{
    public class DiagnosticSourceSubscriber : IDisposable, IObserver<System.Diagnostics.DiagnosticListener>
    {
        private IDisposable _allSourcesSubscription;


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(System.Diagnostics.DiagnosticListener listener)
        {
            switch (listener.Name)
            {
                case "DiagnosticListener.Calculator":
                {
                    listener.Subscribe(delegate(KeyValuePair<string, object> evnt)
                    {
                        var eventName = evnt.Key;
                        var payload = evnt.Value;
                        if (eventName == "DiagnosticListener.Calculator.SpecificEvent")
                        {
                            var a = Activity.Current; //Current activity
                            Console.WriteLine($"{evnt.Key} {evnt.Value} {a.ParentId}");
                        }
                    });
                }
                    break;
            }
        }

        public void Subscribe()
        {
            if (_allSourcesSubscription != null)
                return;
            _allSourcesSubscription =
                System.Diagnostics.DiagnosticListener.AllListeners.Subscribe(
                    (IObserver<System.Diagnostics.DiagnosticListener>) this);
        }
    }
}
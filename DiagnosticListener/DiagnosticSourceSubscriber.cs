using System;
using System.Collections.Generic;
using System.Threading;
using DiagnosticListener.ListenerHandlers;

namespace DiagnosticListener
{
    public class DiagnosticSourceSubscriber : IDisposable, IObserver<System.Diagnostics.DiagnosticListener>
    {
        private IDisposable _allSourcesSubscription;
        private readonly List<IDisposable> _listenerSubscriptions;
        private readonly Func<string, ListenerHandler> _handlerFactory;
        private readonly Func<System.Diagnostics.DiagnosticListener, bool> _diagnosticSourceFilter;
        private readonly Func<string, object, object, bool> _isEnabledFilter;

        public DiagnosticSourceSubscriber(Func<string, ListenerHandler> handlerFactory,
            Func<System.Diagnostics.DiagnosticListener, bool> diagnosticSourceFilter,
            Func<string, object, object, bool> isEnabledFilter)
        {
            _listenerSubscriptions = new List<IDisposable>();
            _handlerFactory = handlerFactory;
            _diagnosticSourceFilter = diagnosticSourceFilter;
            _isEnabledFilter = isEnabledFilter;
        }

        public void Dispose()
        {
            lock (_listenerSubscriptions)
            {
                foreach (var listenerSubscription in _listenerSubscriptions)
                {
                    listenerSubscription?.Dispose();
                }
                _listenerSubscriptions.Clear();
            }

            _allSourcesSubscription?.Dispose();
            _allSourcesSubscription = (IDisposable) null;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(System.Diagnostics.DiagnosticListener listener)

        {
            if (!_diagnosticSourceFilter(listener))
                return;


            var diagnosticSourceListener = new DiagnosticSourceListener(_handlerFactory(listener.Name));


            var disposable = _isEnabledFilter == null
                ? listener.Subscribe((IObserver<KeyValuePair<string, object>>) diagnosticSourceListener)
                : listener.Subscribe((IObserver<KeyValuePair<string, object>>) diagnosticSourceListener,
                    _isEnabledFilter);

            lock (_listenerSubscriptions)
            {
                _listenerSubscriptions.Add(disposable);
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
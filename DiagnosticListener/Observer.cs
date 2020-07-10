using System;
using System.Collections.Generic;

namespace DiagnosticListener
{
    public class Observer : IObserver<KeyValuePair<string, object>>, IDisposable
    {
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
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
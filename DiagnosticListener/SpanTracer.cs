using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DiagnosticListener
{
    public class SpanTracer : IDisposable
    {
        private readonly Activity _activity;

        private static readonly Dictionary<Activity, SpanTracer> ActivitySpanTable =
            new Dictionary<Activity, SpanTracer>();

        private readonly object lck = new object();
        private AsyncLocal<List<(string, object)>> _attributes;

        public SpanTracer(Activity activity)
        {
            _activity = activity;
        }

        public List<(string, object)> GetAttributes()
        {
            return _attributes.Value;
        }

        public void SetAttribute(string key, object value)
        {
            object obj = value;
            if (value == null)
                obj = (object) string.Empty;
            lock (this.lck)
            {
                if (this._attributes == null || _attributes.Value == null)
                {
                    this._attributes = new AsyncLocal<List<(string, object)>>();
                    _attributes.Value = new List<(string, object)>();
                }

                this._attributes.Value.Add((key, value));
            }
        }

        public IDisposable BeginScope()
        {
            _activity.Start(); //Activity created here will automatically related with parent activity and inherit the baggage from parent.
            if (!SpanTracer.ActivitySpanTable.TryAdd(_activity, this))
            {
                throw new Exception($"{_activity.Id} already used by another listener");
            }

            return (IDisposable) this;
        }

        public SpanTracer Current()
        {
            Activity current = Activity.Current;

            SpanTracer spanSdk;
            var valueExist = ActivitySpanTable.TryGetValue(current, out spanSdk);

            return current == null || !valueExist
                ? throw new InvalidOperationException()
                : spanSdk;
        }

        private void EndScope()
        {
            _activity.Stop();
            SpanTracer.ActivitySpanTable.Remove(_activity);
            return;
        }

        public void Dispose()
        {
            EndScope();
        }
    }
}
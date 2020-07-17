using System.Diagnostics;

namespace DiagnosticListener.ListenerHandlers
{
    public class SomeOtherListener : SqlClientDiagnosticListener
    {
        public const string DiagnosticName = "Sql.Brekdown.SomeOtherListener";

        public const string Activity1 = "Sql.Brekdown.SomeOtherListener.Activity1";
        public const string Activity2 = "Sql.Brekdown.SomeOtherListener.Activity2";

        public SomeOtherListener(string name) : base(name)
        {
        }


        public override void ProcessEvent(Activity activity, object payload)
        {
            var eventAttributes = Tracer.Current().GetAttributes();
        }

        public class SourceContext
        {
            public string A { get; set; }
            public string B { get; set; }
        }
    }
}
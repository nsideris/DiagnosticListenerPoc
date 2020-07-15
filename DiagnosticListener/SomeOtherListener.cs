using System.Diagnostics;
using System.Threading.Tasks;

namespace DiagnosticListener
{
    public class SomeOtherListener : SqlClientDiagnosticListener
    {
        public SomeOtherListener(string name) : base(name)
        {
        }

        public override Task ProcessEvent(Activity activity, object payload)
        {
            throw new System.NotImplementedException();
        }
    }
}
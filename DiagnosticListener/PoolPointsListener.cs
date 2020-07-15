using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DiagnosticListener
{
    public class PoolPointsListener : SqlClientDiagnosticListener
    {
        public const string DiagnosticName = "Sql.Brekdown.PoolPoints";

        public PoolPointsListener(string name) : base(name)
        {
        }


        public override async Task ProcessEvent(Activity activity, object payload)
        {
            var context = payload as SourceContext;

            await AddToDatabase(context);
        }


        public async Task AddToDatabase(SourceContext context)
        {
            //Todo SQL INSERTS ....
        }

        public class SourceContext
        {
            public string A { get; set; }
            public string B { get; set; }
        }


        public class Formatter
        {
            public void FormatToSql()
            {
            }
        }
    }
}
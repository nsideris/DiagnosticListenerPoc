using System.Diagnostics;
using System.Threading.Tasks;

namespace DiagnosticListener.ListenerHandlers
{
    public class PoolPointsListener : SqlClientDiagnosticListener
    {
        public const string DiagnosticName = "Sql.Brekdown.PoolPoints";

        public const string Activity1 = "Sql.Brekdown.PoolPoints.Activity1";
        public const string Activity2 = "Sql.Brekdown.PoolPoints.Activity2";

        public PoolPointsListener(string name) : base(name)
        {
        }


        public override void ProcessEvent(Activity activity, object payload)
        {
            var eventAttributes = Tracer.Current().GetAttributes();

            var sour = new SourceContext();
            foreach (var attribute in eventAttributes)
            {
                switch (attribute.Item1)
                {
                    case Activity1:
                        HandleActivity1((SourceContext) attribute.Item2);
                        break;
                    case Activity2:
                        HandleActivity2((SourceContext) attribute.Item2);
                        break;
                }

                //Todo construct the sql object here
            }

            Task.Run(async () => await AddToDatabase(sour));
        }

        private void HandleActivity2(SourceContext attributeItem2) //Mapper to SQL entities
        {
        }

        private void HandleActivity1(SourceContext attributeItem2) //Mapper to SQL entities
        {
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
    }
}
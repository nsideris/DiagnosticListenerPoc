//using System.Diagnostics;
//using Microsoft.VisualBasic;

//namespace DiagnosticListener
//{
//    public class ActivityStarter
//    {
//        private static Activity StartActivity<T>(T context)
//        {
//            var activity = new Activity(Microsoft.VisualBasic.Constants.ConsumerActivityName);

//            if (!context.MessageHeaders.TryGetValue(
//                Microsoft.VisualBasic.Constants.TraceParentHeaderName,
//                out var requestId))
//            {
//                context.MessageHeaders.TryGetValue(
//                    Microsoft.VisualBasic.Constants.RequestIdHeaderName,
//                    out requestId);
//            }

//            if (!string.IsNullOrEmpty(requestId))
//            {
//                // This is the magic 
//                activity.SetParentId(requestId);

//                if (context.MessageHeaders.TryGetValue(
//                    Microsoft.VisualBasic.Constants.TraceStateHeaderName,
//                    out var traceState))
//                {
//                    activity.TraceStateString = traceState;
//                }
//            }

//            // The current activity gets an ID with the W3C format
//            activity.Start();

//            return activity;
//        }
//    }
//}
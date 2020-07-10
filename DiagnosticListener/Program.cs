using DiagnosticListenerSample;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DiagnosticListener
{
    class Program
    {
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
    }
}
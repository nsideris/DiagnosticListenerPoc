using System;
using System.Diagnostics;
using DiagnosticListener;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DiagnosticListenerSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<HostingDiagnosticHandler>();
            services.AddSingleton<ICalculator>(x => new Calculator());

            var diagnosticSourceSubscriber = new DiagnosticSourceSubscriber(
                name => new PoolPointsListener(name),
                x => x.Name == PoolPointsListener.DiagnosticName, null);
            diagnosticSourceSubscriber.Subscribe();

            var diagnosticSourceSubscriber1 = new DiagnosticSourceSubscriber(
                name => new SomeOtherListener(name),
                x => x.Name == SomeOtherListener.DiagnosticName, null);
            diagnosticSourceSubscriber1.Subscribe();


            var pr = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async context => { throw new InvalidOperationException(); });
        }
    }
}
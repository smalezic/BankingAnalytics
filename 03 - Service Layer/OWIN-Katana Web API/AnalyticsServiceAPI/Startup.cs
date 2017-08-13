using ADS.BankingAnalytics.AnalyticsServiceAPI.AutofacComposition;
using ADS.BankingAnalytics.AnalyticsServiceAPI.Middleware;
using Owin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI
{
    using AppFunc = Func<IDictionary<String, Object>, Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var middleware = new Func<AppFunc, AppFunc>(MyMiddleware);
            //app.Use(middleware);

            //app.Use(async (ctx, next) =>
            //{
            //    Console.WriteLine("Incoming request: " + ctx.Request.Path);
            //    await next();
            //    Console.WriteLine("Outgoing request: " + ctx.Request.Path);
            //});

            //app.Use(async (ctx, next) => {
            //    await ctx.Response.WriteAsync("<html><head></head><body>Hello World</bpdy></html>");
            //});

            var options = new MiddlewareOptions
            {
                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopwatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
                    watch.Stop();
                    Console.WriteLine("Request took: " + watch.ElapsedMilliseconds + " ms");
                }
            };



            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            Bootstrapper.Run(config);
            app.UseWebApi(config);

            //var config = new HttpConfiguration();
            //config.MapHttpAttributeRoutes();
            //app.UseWebApi(config);

            ////app.Use<ControllerMiddleware>(options);
            //app.UseWebApi(options);
            //app.Use<OwinApplication>();
        }

        //public AppFunc MyMiddleware(AppFunc next)
        //{
        //    AppFunc appFunc = async (IDictionary<String, Object> environment) =>
        //    {
        //        var response = environment["owin.ResponseBody"] as Stream;

        //        using (var writer = new StreamWriter(response))
        //        {
        //            await writer.WriteAsync("<h1>Hello from my first middleware</h1>");
        //        }

        //        await next.Invoke(environment);
        //    };

        //    return appFunc;
        //}
    }
}

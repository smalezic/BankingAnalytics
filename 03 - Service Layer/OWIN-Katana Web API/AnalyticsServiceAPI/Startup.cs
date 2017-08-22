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
            
        }
    }
}

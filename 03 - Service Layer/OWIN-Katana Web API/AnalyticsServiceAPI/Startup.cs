using Owin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI
{
    using AppFunc = Func<IDictionary<String, Object>, Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var middleware = new Func<AppFunc, AppFunc>(MyMiddleware);
            app.Use(middleware);
        }

        public AppFunc MyMiddleware(AppFunc next)
        {
            AppFunc appFunc = async (IDictionary<String, Object> environment) =>
            {
                var response = environment["owin.ResponseBody"] as Stream;

                using (var writer = new StreamWriter(response))
                {
                    await writer.WriteAsync("<h1>Hello from my first middleware</h1>");
                }

                await next.Invoke(environment);
            };

            return appFunc;
        }
    }
}

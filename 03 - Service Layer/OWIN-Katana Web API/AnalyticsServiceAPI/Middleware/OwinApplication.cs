using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<System.String, System.Object>,
    System.Threading.Tasks.Task
>;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI.Middleware
{
    public class OwinApplication : MiddlewareBase
    {
        public OwinApplication(AppFunc next)
            : base (next)
        {

        }

        public override async Task Invoke(IDictionary<String, Object> environment)
        {
            var ctx = new OwinContext(environment);
            await ctx.Response.WriteAsync("<html><head></head><body>Hello World</bpdy></html>");
        }
    }
}

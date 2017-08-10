using ADS.BankingAnalytics.AnalyticsServiceAPI.Middleware;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin
{
    public static class MiddlewareExtensions
    {
        public static void UseWebApi(this IAppBuilder app, MiddlewareOptions options = null)
        {
            if(options == null)
            {
                options = new MiddlewareOptions();
            }

            app.Use<ControllerMiddleware>(options);
        }
    }
}

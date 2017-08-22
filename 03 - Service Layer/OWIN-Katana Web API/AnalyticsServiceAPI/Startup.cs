using ADS.BankingAnalytics.AnalyticsServiceAPI.AutofacComposition;
using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI
{
    using AppFunc = Func<IDictionary<String, Object>, Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            Bootstrapper.Run(config);
            app.UseWebApi(config);
        }
    }
}

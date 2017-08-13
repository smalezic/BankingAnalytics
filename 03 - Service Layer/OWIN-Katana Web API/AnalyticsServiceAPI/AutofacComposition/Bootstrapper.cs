using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI.AutofacComposition
{
    public class Bootstrapper
    {
        public static void Run(HttpConfiguration config)
        {
            // Configure Autofac
            //AutofacWebApiConfig.Initialize(GlobalConfiguration.Configuration);
            AutofacWebApiConfig.Initialize(config);
        }
    }
}

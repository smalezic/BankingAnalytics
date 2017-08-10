using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI.Middleware
{
    public class MiddlewareOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }
        public Action<IOwinContext> OnOutgoingRequest { get; set; }
    }
}

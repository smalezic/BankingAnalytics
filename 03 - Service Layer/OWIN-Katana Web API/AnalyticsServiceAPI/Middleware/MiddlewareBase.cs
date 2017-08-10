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
    public abstract class MiddlewareBase
    {
        protected AppFunc _next;

        protected MiddlewareBase(AppFunc next)
        {
            _next = next;
        }

        public abstract Task Invoke(IDictionary<String, Object> environment);
    }
}

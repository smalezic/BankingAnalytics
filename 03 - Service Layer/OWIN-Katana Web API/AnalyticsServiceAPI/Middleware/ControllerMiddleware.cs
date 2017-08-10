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
    public class ControllerMiddleware : MiddlewareBase
    {
        private MiddlewareOptions _options;

        public ControllerMiddleware(AppFunc next)
            : base(next)
        {

        }

        public ControllerMiddleware(AppFunc next, MiddlewareOptions options)
            : this(next)
        {
            _options = options;

            if(_options.OnIncomingRequest == null)
            {
                _options.OnIncomingRequest = (ctx) =>
                {
                    Console.WriteLine("Incoming request: " + ctx.Request.Path);
                };
            }

            if (_options.OnOutgoingRequest == null)
            {
                _options.OnOutgoingRequest = (ctx) =>
                {
                    Console.WriteLine("Outgoing request: " + ctx.Request.Path);
                };
            }
        }

        public override  async Task Invoke(IDictionary<String, Object> environment)
        {
            var ctx = new OwinContext(environment);

            _options.OnIncomingRequest(ctx);
            await _next(environment);
            _options.OnOutgoingRequest(ctx);
        }
    }
}

using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.ObjectModel;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities.ContextFactory;
using ADS.BankingAnalytics.Logging.LoggingInterface;
using ADS.BankingAnalytics.Logging.NLogLogger;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI.Controllers
{
    [RoutePrefix("api")]
    public class ImporterController : ApiController
    {
        private IWorker _worker;
        
        public ImporterController(IWorker worker)
        {
            _worker = worker;
        }

        [Route("hello")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            if(_worker == null)
            {
                IFactory factory = new Factory();
                DbContext context = factory.Context;
                ILogger logger = new Logger();

                IGenericRepositoryActivity activity = new GenericRepositoryActivity(context, logger);
                _worker = new Worker(activity, logger);
            }
            var x = _worker.FindEntity<Organization>(1);
            return Content(System.Net.HttpStatusCode.OK, "Hello from Web Api");
        }
    }
}

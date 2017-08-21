using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.ObjectModel;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities.ContextFactory;
using ADS.BankingAnalytics.Logging.LoggingInterface;
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
            var x = _worker.FindEntity<Organization>(1);
            return Content(System.Net.HttpStatusCode.OK, "Hello from Web Api, " + x.Name);
        }
    }
}

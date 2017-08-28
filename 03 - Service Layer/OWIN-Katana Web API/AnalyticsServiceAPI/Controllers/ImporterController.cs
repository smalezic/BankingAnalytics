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
using System.Net;
using Newtonsoft.Json;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI.Controllers
{
    [RoutePrefix("api/Importer")]
    public class ImporterController : ApiController
    {
        private IWorker _worker;
        
        public ImporterController(IWorker worker)
        {
            _worker = worker;
        }

        [Route("FindUnit/{id}")]
        [HttpGet]
        public IHttpActionResult FindUnit(int id)
        {
            var x = _worker.FindUnit(id);
            var ser = JsonConvert.SerializeObject(x.Expansion);
            x.Expansion = null;
            var ser1 = JsonConvert.SerializeObject(x);

            return Content(HttpStatusCode.OK, ser + "|" + ser1);
        }

        [Route("GetAllOrganizations")]
        [HttpGet]
        public IHttpActionResult GetAllOrganizations()
        {
            return Content(HttpStatusCode.OK, _worker.GetAllOrganizations());
        }

        [Route("GetUnits/{organizationId}")]
        [HttpGet]
        public IHttpActionResult GetUnits(int organizationId)
        {
            return Content(HttpStatusCode.OK, _worker.GetUnits(organizationId));
        }

        [Route("SaveOrganization")]
        [HttpPost]
        public IHttpActionResult SaveOrganization(Organization org)
        {
            var orgDb = _worker.SaveSimpleEntity(org);
            return Content(HttpStatusCode.OK, orgDb);
        }
        
        [Route("SaveUnits")]
        [HttpPost]
        public IHttpActionResult SaveUnits(List<Unit> units)
        {
            var retVal = _worker.SaveUnits(units);
            return Content(HttpStatusCode.OK, retVal);
        }
    }
}

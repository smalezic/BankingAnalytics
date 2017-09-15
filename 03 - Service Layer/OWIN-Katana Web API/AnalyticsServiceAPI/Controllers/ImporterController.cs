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
using Newtonsoft.Json.Linq;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI.Controllers
{
    [RoutePrefix("api/Importer")]
    public class ImporterController : ApiController
    {
        #region Fields

        private IWorker _worker;

        #endregion Fields

        #region Constructors

        public ImporterController(IWorker worker)
        {
            _worker = worker;
        }

        #endregion Constructors

        #region Exposed Methods

        #region Organization & Unit

        [Route("GetAllOrganizations")]
        [HttpGet]
        public IHttpActionResult GetAllOrganizations()
        {
            return Content(HttpStatusCode.OK, _worker.GetAllOrganizations());
        }

        [Route("SaveOrganization")]
        [HttpPost]
        public IHttpActionResult SaveOrganization(Organization org)
        {
            var orgDb = _worker.SaveSimpleEntity(org);
            return Content(HttpStatusCode.OK, orgDb);
        }

        [Route("FindUnit/{id}")]
        [HttpGet]
        public IHttpActionResult FindUnit(int id)
        {
            var unit = _worker.FindUnit(id);
            
            var serializedExpansion = JsonConvert.SerializeObject(
                unit.Expansion,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

            unit.Expansion = null;
            var serializedUnit = JsonConvert.SerializeObject(unit);

            return Content(HttpStatusCode.OK, serializedExpansion + "|" + serializedUnit);
        }

        [Route("GetUnits/{organizationId}")]
        [HttpGet]
        public IHttpActionResult GetUnits(int organizationId)
        {
            return Content(HttpStatusCode.OK, _worker.GetUnits(organizationId));
        }

        [Route("SaveUnits")]
        [HttpPost]
        public IHttpActionResult SaveUnits([FromBody] String units)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var deserialized = JsonConvert.DeserializeObject<List<Unit>>(units, settings);

            var retVal = _worker.SaveUnits(deserialized);
            return Content(HttpStatusCode.OK, retVal);
        }

        [Route("GetAllUnitCategories")]
        [HttpGet]
        public IHttpActionResult GetAllUnitCategories()
        {
            return Content(HttpStatusCode.OK, _worker.GetAllUnitCategories());
        }

        [Route("SaveUnitCategory")]
        [HttpPost]
        public IHttpActionResult SaveUnitCategory(UnitCategory unitCategory)
        {
            var retVal = _worker.SaveSimpleEntity(unitCategory);
            return Content(HttpStatusCode.OK, retVal);
        }
        
        #endregion Unit & Organization

        #region Additional Fields

        [Route("GetAdditionalFieldDefinitions/{unitCategoryId}")]
        [HttpGet]
        public IHttpActionResult GetAdditionalFieldDefinitions(int unitCategoryId)
        {
            return Content(HttpStatusCode.OK, _worker.GetAdditionalFieldDefinitions(unitCategoryId));
        }

        [Route("SaveAdditionalFieldDefinitions")]
        [HttpPost]
        public IHttpActionResult SaveAdditionalFieldDefinitions([FromBody] String additionalFieldDefinitions)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var deserialized = JsonConvert.DeserializeObject<List<AdditionalFieldDefinition>>(additionalFieldDefinitions, settings);

            var retVal = _worker.SaveAdditionalFieldDefinitions(deserialized);
            return Content(HttpStatusCode.OK, retVal);
        }

        #endregion Additional Fields

        #endregion Exposed Methods
    }
}

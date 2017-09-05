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
        private IWorker _worker;
        
        public ImporterController(IWorker worker)
        {
            _worker = worker;
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

        [Route("GetAllOrganizations")]
        [HttpGet]
        public IHttpActionResult GetAllOrganizations()
        {
            return Content(HttpStatusCode.OK, _worker.GetAllOrganizations());
        }

        [Route("GetAllUnitCategories")]
        [HttpGet]
        public IHttpActionResult GetAllUnitCategories()
        {
            return Content(HttpStatusCode.OK, _worker.GetAllUnitCategories());
        }

        [Route("GetUnits/{organizationId}")]
        [HttpGet]
        public IHttpActionResult GetUnits(int organizationId)
        {
            return Content(HttpStatusCode.OK, _worker.GetUnits(organizationId));
        }

        [Route("GetAdditionalFieldDefinitions/{unitCategoryId}")]
        [HttpGet]
        public IHttpActionResult GetAdditionalFieldDefinitions(int unitCategoryId)
        {
            return Content(HttpStatusCode.OK, _worker.GetAdditionalFieldDefinitions(unitCategoryId));
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
        public IHttpActionResult SaveUnits([FromBody] String units)
        {
            var x = JsonConvert.DeserializeObject<List<Unit>>(units);
            var retVal = _worker.SaveUnits(null);
            return Content(HttpStatusCode.OK, retVal);
        }

        [Route("SaveSerializedUnits")]
        [HttpPost]
        public IHttpActionResult SaveSerializedUnits([FromBody] String units)
        {
            units = units.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
            JObject googleSearch = JObject.Parse(units);

            // get JSON result objects into a list
            IList<JToken> results = googleSearch["Expansion"]["AdditionalFields"].Children().ToList();

            // serialize JSON results into .NET objects
            IList<AdditionalField> searchResults = new List<AdditionalField>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                AdditionalField searchResult = result.ToObject<AdditionalField>();
                searchResults.Add(searchResult);
            }






            //var x = JsonConvert.DeserializeObject<List<Unit>>(units, new PersonConverter());
            var x = JsonConvert.DeserializeObject<List<Unit>>(units);

            var retVal = _worker.SaveUnits(x);
            return Content(HttpStatusCode.OK, retVal);
        }

        [Route("SaveUnitCategory")]
        [HttpPost]
        public IHttpActionResult SaveUnitCategory(UnitCategory unitCategory)
        {
            var retVal = _worker.SaveSimpleEntity(unitCategory);
            return Content(HttpStatusCode.OK, retVal);
        }
    }
}

using ADS.BankingAnalytics.DataEntities.ObjectModel;
using ADS.BankingAnalytics.HelperObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Client.WebApiClientHandler
{
    public class ImporterClient
    {
        #region Fields

        private HttpClient _client;

        #endregion Fields

        #region Constructor

        public ImporterClient(String hostUri)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(new Uri(hostUri), "api/Importer/")
            };
        }

        #endregion Constructor

        #region Controller's Methods invocations

        #region Organization & Unit

        public List<Organization> GetAllOrganizations()
        {
            var response = _client.GetAsync(_client.BaseAddress + "GetAllOrganizations/").Result;
            return response.Content.ReadAsAsync<List<Organization>>().Result;
        }

        public Organization SaveOrganization(Organization entity)
        {
            var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveOrganization/", entity).Result;
            return response.Content.ReadAsAsync<Organization>().Result;
        }
        
        public Unit GetUnit(int id)
        {
            var response = _client.GetAsync(_client.BaseAddress + "FindUnit/" + id.ToString()).Result;
            var x = response.Content.ReadAsAsync<String>().Result;

            var ser = x.Substring(0, x.IndexOf("|"));
            var ser1 = x.Substring(x.IndexOf("|") + 1);

            var ext = JsonConvert.DeserializeObject<ExpandableEntity>(ser);
            var expandedUnit = JsonConvert.DeserializeObject<Unit>(ser1);

            expandedUnit.Expansion = ext;

            return expandedUnit;
        }

        public Workbook GetWorkbook(int id)
        {
            var response = _client.GetAsync(_client.BaseAddress + "FindWorkbook/" + id.ToString()).Result;
            var x = response.Content.ReadAsAsync<String>().Result;

            var ser = x.Substring(0, x.IndexOf("|"));
            var ser1 = x.Substring(x.IndexOf("|") + 1);

            var ext = JsonConvert.DeserializeObject<ExpandableEntity>(ser);
            var expandedUnit = JsonConvert.DeserializeObject<Workbook>(ser1);

            expandedUnit.Expansion = ext;

            return expandedUnit;
        }

        public List<Unit> GetUnits(int organizationId)
        {
            var response = _client.GetAsync(_client.BaseAddress + "GetUnits/" + organizationId.ToString() + "/").Result;
            return response.Content.ReadAsAsync<List<Unit>>().Result;
        }

        public bool SaveUnits(List<Unit> units)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string serialized = JsonConvert.SerializeObject(units, settings);
            var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveUnits/", serialized).Result;
            return response.Content.ReadAsAsync<bool>().Result;
        }

        /// <summary>
        /// This method exists for testing purpose only!
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool SaveUnits(String unit)
        {
            var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveUnits/", unit).Result;
            return response.Content.ReadAsAsync<bool>().Result;
        }

        public List<UnitCategory> GetUnitCategories(int organizationId)
        {
            var response = _client.GetAsync(_client.BaseAddress + "GetUnitCategories/" + organizationId.ToString() + "/").Result;
            return response.Content.ReadAsAsync<List<UnitCategory>>().Result;
        }

        public UnitCategory SaveUnitCategory(UnitCategory entity)
        {
            var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveUnitCategory/", entity).Result;
            return response.Content.ReadAsAsync<UnitCategory>().Result;
        }

        #endregion Unit & Organization

        #region KPI Operations

        public List<WorkbookTemplate> GetAllWorkbookTemplates()
        {
            var response = _client.GetAsync(_client.BaseAddress + "GetAllWorkbookTemplates/").Result;
            return response.Content.ReadAsAsync<List<WorkbookTemplate>>().Result;
        }

        public bool SaveWorkbook(Workbook workbook)
        {
            var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveWorkbook/", workbook).Result;
            return response.Content.ReadAsAsync<bool>().Result;
        }

        public WorkbookTemplate SaveWorkbookTemplate(WorkbookTemplate entity)
        {
            var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveWorkbookTemplate/", entity).Result;
            return response.Content.ReadAsAsync<WorkbookTemplate>().Result;
        }

        public int UploadFile(Workbook workbook, byte[] fileContent)
        {
            //HttpRequestMessage message = new HttpRequestMessage();
            //message.Content = new ByteArrayContent(fileContent);
            //var response = _client.PostAsync(_client.BaseAddress + "UploadFile/", message.Content).Result;
            //return response.Content.ReadAsAsync<bool>().Result;

            var transport = new WorkbookTransport()
            {
                Workbook = workbook,
                Content = fileContent
            };

            var response = _client.PostAsJsonAsync(_client.BaseAddress + "UploadFile/", transport).Result;
            return response.Content.ReadAsAsync<int>().Result;
        }

        #endregion KPI Operations

        #region Additional Fields

        public List<AdditionalFieldDefinition> GetAdditionalFieldDefinitions(int unitCategoryId)
        {
            var response = _client.GetAsync(_client.BaseAddress + "GetAdditionalFieldDefinitions/" + unitCategoryId.ToString() + "/").Result;
            return response.Content.ReadAsAsync<List<AdditionalFieldDefinition>>().Result;
        }

        public bool SaveAdditionalFieldDefinitions(ExpandableEntityType expandableEntityType)
        {
            var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveAdditionalFieldDefinitions/", expandableEntityType).Result;
            return response.Content.ReadAsAsync<bool>().Result;
        }

        //public bool SaveAdditionalFieldDefinitions(List<AdditionalFieldDefinition> additionalFieldDefinition)
        //{
        //    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        //    string serialized = JsonConvert.SerializeObject(additionalFieldDefinition, settings);
        //    var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveAdditionalFieldDefinitions/", serialized).Result;
        //    return response.Content.ReadAsAsync<bool>().Result;
        //}

        #endregion Additional Fields

        #endregion Controller's Methods invocations
    }
}

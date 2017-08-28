using ADS.BankingAnalytics.DataEntities.ObjectModel;
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

        public List<Organization> GetAllOrganizations()
        {
            var response = _client.GetAsync(_client.BaseAddress + "GetAllOrganizations/").Result;
            return response.Content.ReadAsAsync<List<Organization>>().Result;
        }

        public List<Unit> GetUnits(int organizationId)
        {
            var response = _client.GetAsync(_client.BaseAddress + "GetUnits/" + organizationId.ToString() + "/").Result;
            return response.Content.ReadAsAsync<List<Unit>>().Result;
        }

        public Organization SaveSimpleEntity(Organization entity)
        {
            var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveOrganization/", entity).Result;
            return response.Content.ReadAsAsync<Organization>().Result;
        }

        public bool SaveUnits(List<Unit> units)
        {
            var response = _client.PostAsJsonAsync(_client.BaseAddress + "SaveUnits/", units).Result;
            return response.Content.ReadAsAsync<bool>().Result;
        }

        #endregion Controller's Methods invocations
    }
}

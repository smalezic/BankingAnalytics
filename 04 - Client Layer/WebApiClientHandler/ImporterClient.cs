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

        #region Controller's Methods invokations

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Unit GetUnit(int id)
        {
            var response = _client.GetAsync(_client.BaseAddress + "hello/").Result;
            return response.Content.ReadAsAsync<Unit>().Result;
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

        #endregion Controller's Methods invokations
    }
}

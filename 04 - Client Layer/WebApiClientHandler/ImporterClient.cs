using ADS.BankingAnalytics.DataEntities.ObjectModel;
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
        private String _hostUri;

        public ImporterClient(String hostUri)
        {
            _hostUri = hostUri;
        }

        public Unit GetUnit(int id)
        {
            HttpResponseMessage response;

            using(var client = CreateClient())
            {
                response = client.GetAsync(client.BaseAddress + "hello/").Result;
            }

            var result = response.Content.ReadAsAsync<Unit>().Result;
            return result;
        }

        private HttpClient CreateClient()
        {
            return new HttpClient()
            {
                BaseAddress = new Uri(new Uri(_hostUri), "api/Importer/")
            };
        }
    }
}

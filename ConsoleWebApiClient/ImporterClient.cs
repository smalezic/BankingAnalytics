using ADS.BankingAnalytics.DataEntities.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Client.ConsoleWebApiClient
{
    public class ImporterClient
    {
        private String _hostUri;

        public ImporterClient(String hostUri)
        {
            _hostUri = hostUri;
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/hello/");
            return client;
        }

        public Unit GetUnit(int id)
        {
            HttpResponseMessage response;

            using(var client = CreateClient())
            {
                response = client.GetAsync(client.BaseAddress).Result;
            }

            var result = response.Content.ReadAsAsync<Unit>().Result;
            return result;
        }
    }
}

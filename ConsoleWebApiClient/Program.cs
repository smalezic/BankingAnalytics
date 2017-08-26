using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Client.ConsoleWebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ImporterClient("http://localhost:8081");

            int unitId = 1;
            Console.WriteLine("Get the Unit with Id - {0}", unitId);

            var unit = client.GetUnit(unitId);
            Console.WriteLine(unit.ToString());

            Console.Write("Press 'Enter' to finish");
            Console.ReadLine();
        }
    }
}

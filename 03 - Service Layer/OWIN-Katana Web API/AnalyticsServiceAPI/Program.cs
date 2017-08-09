using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<Startup>("http://localhost:8086");

            Console.WriteLine("Server is started. Press Enter to quit.");
            Console.ReadLine();
        }
    }
}

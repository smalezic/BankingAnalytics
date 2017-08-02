using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.DataEntities.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.BankingAnalytics.Logging;

using NLog;

namespace ADS.BankingAnalytics.Client.ConsoleApp
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            IGenericRepositoryActivity repository = new GenericRepositoryActivity();
            IWorker worker = new Worker(repository);

            //Organization org = new Organization()
            //{
            //    Name = "Test"
            //};

            //var savedOrg = worker.Save(org);

            //Unit unit = new Unit()
            //{
            //    Organization = org
            //};

            //var savedUnit = worker.Save(unit);

            //Unit childUnit = new Unit()
            //{
            //    Organization = org,
            //    ParentUnit = unit
            //};

            //var savedChildUnit = worker.Save(childUnit);

            //Console.WriteLine(savedOrg.ToString());
            //Console.WriteLine(savedUnit.ToString());
            //Console.WriteLine(savedChildUnit.ToString());




            //var org = worker.FindEntity<Organization>(1);
            //var entity = worker.FindEntity<Unit>(2);

            //Console.WriteLine(org.ToString());
            //Console.WriteLine(entity.ToString());




            //ILogger logger = new NLogLogger();
            //logger.Trace("Upis u log fajl");

            _logger.Info("Test");




            Console.Write("Press 'Enter' to finish");
            Console.ReadLine();
        }
    }
}
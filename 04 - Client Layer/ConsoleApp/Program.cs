using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.DataEntities.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.BankingAnalytics.Logging;
using ADS.BankingAnalytics.Logging.LoggingInterface;
using ADS.BankingAnalytics.Logging.NLogLogger;
using ADS.BankingAnalytics.Common.CompositionRoot;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities.ContextFactory;
using Microsoft.EntityFrameworkCore;

//using NLog;

namespace ADS.BankingAnalytics.Client.ConsoleApp
{
    class Program
    {
        //private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            CompositionModule fabricModule = new CompositionModule();

            fabricModule.Initialize();

            IDbContextFactory factory = new DbContextFactory();
            DbContext context = factory.Context;

            ILogger logger = fabricModule.Resolve<ILogger>();
            IGenericRepositoryActivity repositoryActivity = fabricModule.ResolveRepositoryActivity(context, logger);
            IWorker worker = fabricModule.ResolveWorker(repositoryActivity, logger);



            worker.FindUnit(1);



            //// Create AdditionalFieldDefinition
            //var def = new AdditionalFieldDefinition
            //{
            //    Name = "Name",
            //    IsMandatory = true
            //};

            //// Create ExpandableEntity
            //var expEntity = new ExpandableEntity
            //{
            //    MetaEntityType = "Unit",
            //    MetaEntityId = 1,
            //};

            //expEntity.AdditionalFieldDefinitions.Add(def);

            //var savedExp = worker.SaveExp(expEntity);





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



            //
            //var org = worker.FindEntity<Organization>(1);
            //var entity = worker.FindEntity<Unit>(2);

            //Console.WriteLine(org.ToString());
            //Console.WriteLine(entity.ToString());
            //



            //ILogger logger = new Logger("Business");
            //logger.Trace("Upis u log fajl - {0}:{1}", 1, 2);
            //logger.Trace("Upis u log fajl - Poruka");
            //logger.Warn("Business message - {0}", "new filter");

            //ILogger logger2 = new Logger("Console");
            //logger2.Info("Test");




            Console.Write("Press 'Enter' to finish");
            Console.ReadLine();
        }
    }
}
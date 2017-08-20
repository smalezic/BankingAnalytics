using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.DataBroker;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.Logging.LoggingInterface;
using ADS.BankingAnalytics.Logging.NLogLogger;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI.AutofacComposition
{
    public class AutofacWebApiConfig
    {
        public static IContainer _container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        internal static void Initialize(object globalConfiguration)
        {
            throw new NotImplementedException();
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<OrganizationalStructureDbContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            //builder.RegisterType<DbFactory>()
            //       .As<IDbFactory>()
            //       .InstancePerRequest();

            //builder.RegisterGeneric(typeof(GenericRepository<>))
            //       .As(typeof(IGenericRepository<>))
            //       .InstancePerRequest();

            // Register implementations of interfaces here
            builder.RegisterType<Worker>().As<IWorker>();
            builder.RegisterType<GenericRepositoryActivity>().As<IGenericRepositoryActivity>();
            builder.RegisterType<Logger>().As<ILogger>();
            
            //Set the dependency resolver to be Autofac.  
            _container = builder.Build();

            return _container;
        }
    }
}

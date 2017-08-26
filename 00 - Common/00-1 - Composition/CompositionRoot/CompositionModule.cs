using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.Logging.LoggingInterface;
using ADS.BankingAnalytics.Logging.NLogLogger;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Reflection;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities.ContextFactory;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities.ExpandableEntityFactory;

namespace ADS.BankingAnalytics.Common.CompositionRoot
{
    public class CompositionModule : ICompositionModule
    {
        #region Fields
        
        private static IContainer _container { get; set; }

        #endregion Fields

        #region Initialize

        public void Initialize()
        {
            try
            {
                RegisterServices(new ContainerBuilder());
            }
            catch
            {
                throw;
            }
        }

        public void Initialize(ContainerBuilder builder)
        {
            try
            {
                RegisterServices(builder);
            }
            catch
            {
                throw;
            }
        }

        public static void Initialize(HttpConfiguration config, Assembly assembly)
        {
            Initialize(config, RegisterServices(new ContainerBuilder(), assembly));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder, Assembly assembly = null)
        {
            if (assembly != null)
            {
                //Register Web API controllers.
                builder.RegisterApiControllers(assembly);
            }

            //builder.RegisterType<OrganizationalStructureDbContext>()
            //       .As<DbContext>()
            //       .InstancePerRequest();

            // Register implementations of interfaces
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>();
            builder.RegisterType<Worker>().As<IWorker>();
            builder.RegisterType<GenericRepositoryActivity>().As<IGenericRepositoryActivity>();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<ExpandableEntityCreator>().As<IExpandableEntityCreator>();

            // Build the container
            _container = builder.Build();

            return _container;
        }

        #endregion Initialize

        #region Resolve

        public T Resolve<T>() where T : class
        {
            try
            {
                ILifetimeScope clientLifetimeScope = _container.BeginLifetimeScope();

                return clientLifetimeScope.Resolve<T>();
            }
            catch
            {
                throw;
            }
        }

        public IWorker ResolveWorker(IGenericRepositoryActivity repositoryActivity, ILogger logger)
        {
            try
            {
                var paramList = new List<ResolvedParameter>
                {
                    new ResolvedParameter(
                            (pi, ctx) => pi.ParameterType == typeof(IGenericRepositoryActivity) && pi.Name == "genericRepository",
                            (pi, ctx) => repositoryActivity
                        ),
                    new ResolvedParameter(
                            (pi, ctx) => pi.ParameterType == typeof(ILogger) && pi.Name == "logger",
                            (pi, ctx) => logger
                        )
                };
                ILifetimeScope clientLifetimeScope = _container.BeginLifetimeScope();

                return clientLifetimeScope.Resolve<IWorker>(paramList);
            }
            catch
            {
                throw;
            }
        }

        public IGenericRepositoryActivity ResolveRepositoryActivity(DbContext context, ILogger logger)
        {
            try
            {
                var paramList = new List<ResolvedParameter>
                {
                    new ResolvedParameter(
                            (pi, ctx) => pi.ParameterType == typeof(DbContext) && pi.Name == "context",
                            (pi, ctx) => context
                        ),
                    new ResolvedParameter(
                            (pi, ctx) => pi.ParameterType == typeof(ILogger) && pi.Name == "logger",
                            (pi, ctx) => logger
                        )
                };
                ILifetimeScope clientLifetimeScope = _container.BeginLifetimeScope();

                return clientLifetimeScope.Resolve<IGenericRepositoryActivity>(paramList);
            }
            catch
            {
                throw;
            }
        }

        #endregion Resolve
    }
}

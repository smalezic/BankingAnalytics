using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.Logging.LoggingInterface;
using ADS.BankingAnalytics.Logging.NLogLogger;
using Autofac;
using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Common.CompositionRoot
{
    public class FabricModule : IFabricModule
    {
        #region Fields
        
        private static IContainer _container { get; set; }

        #endregion Fields

        #region Load

        public void Load()
        {
            try
            {
                Load(new ContainerBuilder());
            }
            catch
            {
                throw;
            }
        }

        public void Load(ContainerBuilder builder)
        {
            try
            {
                // Register implementations of interfaces here
                builder.RegisterType<Worker>().As<IWorker>();
                builder.RegisterType<GenericRepositoryActivity>().As<IGenericRepositoryActivity>();
                builder.RegisterType<Logger>().As<ILogger>();

                // Build the container
                _container = builder.Build();
            }
            catch
            {
                throw;
            }
        }

        #endregion Load

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

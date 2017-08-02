using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using Autofac;
using Autofac.Core;
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
            catch (Exception exc)
            {
                //_logger.Error("Error - {0}", exc);
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

                // Build the container
                _container = builder.Build();
            }
            catch (Exception exc)
            {
                //_logger.Error("Error - {0}", exc);
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
            catch (Exception exc)
            {
                //_logger.Error("Error - {0}", exc);
                throw;
            }
        }

        public IWorker ResolveWorker(IGenericRepositoryActivity repositoryActivity)
        {
            try
            {
                var paramList = new List<ResolvedParameter>
                {
                    new ResolvedParameter(
                            (pi, ctx) => pi.ParameterType == typeof(IGenericRepositoryActivity) && pi.Name == "genericRepository",
                            (pi, ctx) => repositoryActivity
                        )
                };
                ILifetimeScope clientLifetimeScope = _container.BeginLifetimeScope();

                return clientLifetimeScope.Resolve<IWorker>(paramList);
            }
            catch (Exception exc)
            {
                //_logger.Error("Error - {0}", exc);
                throw;
            }
        }

        //public IDispatcher ResolveDispatcher(IWorker worker, String folderName)
        //{
        //    try
        //    {
        //        var paramList = new List<ResolvedParameter>
        //        {
        //            new ResolvedParameter(
        //                    (pi, ctx) => pi.ParameterType == typeof(IWorker) && pi.Name == "worker",
        //                    (pi, ctx) => worker
        //                ),
        //            new ResolvedParameter(
        //                    (pi, ctx) => pi.ParameterType == typeof(String) && pi.Name == "folderName",
        //                    (pi, ctx) => folderName
        //                )
        //        };
        //        ILifetimeScope clientLifetimeScope = _container.BeginLifetimeScope();

        //        return clientLifetimeScope.Resolve<IDispatcher>(paramList);
        //    }
        //    catch (Exception exc)
        //    {
        //        _logger.Error("Error - ", exc);
        //        throw;
        //    }
        //}

        #endregion Resolve
    }
}

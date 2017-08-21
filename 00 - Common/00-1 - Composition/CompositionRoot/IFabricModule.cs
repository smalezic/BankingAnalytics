using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.Logging.LoggingInterface;
using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ADS.BankingAnalytics.Common.CompositionRoot
{
    public interface IFabricModule
    {
        void Initialize();
        void Initialize(ContainerBuilder builder);

        T Resolve<T>() where T : class;
        IWorker ResolveWorker(IGenericRepositoryActivity repositoryActivity, ILogger logger);
        IGenericRepositoryActivity ResolveRepositoryActivity(DbContext context, ILogger logger);
    }
}

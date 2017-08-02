using ADS.BankingAnalytics.Business.OrganizationManager;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Common.CompositionRoot
{
    public interface IFabricModule
    {
        void Load();
        void Load(ContainerBuilder builder);

        T Resolve<T>() where T : class;
        IWorker ResolveWorker(IGenericRepositoryActivity repositoryActivity);
        IGenericRepositoryActivity ResolveRepositoryActivity(DbContext context);
    }
}

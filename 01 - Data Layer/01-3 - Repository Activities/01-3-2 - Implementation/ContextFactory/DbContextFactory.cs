using ADS.BankingAnalytics.DataEntities.DataBroker;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.RepositoryActivities.ContextFactory
{
    public class DbContextFactory : IDbContextFactory
    {
        #region Fields
        
        #endregion Fields

        #region IFactory Interface Implementation

        public DbContext Context
        {
            get { return new OrganizationalStructureDbContext(); }
        }

        #endregion IFactory Interface Implementation
    }
}

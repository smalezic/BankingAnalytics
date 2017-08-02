using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.RepositoryActivities.ContextFactory
{
    public interface IFactory
    {
        DbContext Context { get; }
    }
}

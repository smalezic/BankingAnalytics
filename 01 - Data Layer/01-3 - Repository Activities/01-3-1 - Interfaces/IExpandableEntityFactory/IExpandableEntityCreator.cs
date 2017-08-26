using ADS.BankingAnalytics.DataEntities.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.RepositoryActivities.ExpandableEntityFactory
{
    public interface IExpandableEntityCreator
    {
        MetaEntity Expand(MetaEntity entity);
    }
}

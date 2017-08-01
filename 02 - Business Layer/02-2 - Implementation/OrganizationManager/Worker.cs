using ADS.BankingAnalytics.DataEntities.ObjectModel;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Business.OrganizationManager
{
    public class Worker : IWorker
    {
        #region Fields

        private IGenericRepositoryActivity _genericRepository;

        #endregion Fields

        #region Constructor

        public Worker(IGenericRepositoryActivity genericRepository)
        {
            this._genericRepository = genericRepository;
        }

        #endregion Constructor

        #region IWorker Interface Implementation

        public MetaEntity Save(MetaEntity entity)
        {
            return _genericRepository.Save<MetaEntity>(entity, entity.Id);
        }

        public TEntity FindEntity<TEntity>(int id) where TEntity : class
        {
            return _genericRepository.GetById<TEntity>(id);
        }

        #endregion IWorker Interface Implementation
    }
}

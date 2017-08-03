using ADS.BankingAnalytics.DataEntities.ObjectModel;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.Logging.LoggingInterface;
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

        // Instance of repository activity
        private IGenericRepositoryActivity _genericRepository;

        // Instance of ILogger
        private readonly ILogger _logger;

        #endregion Fields

        #region Constructor

        public Worker(IGenericRepositoryActivity genericRepository, ILogger logger)
        {
            _genericRepository = genericRepository;
            _logger = logger;
        }

        #endregion Constructor

        #region IWorker Interface Implementation

        public MetaEntity Save(MetaEntity entity)
        {
            _logger.Trace("Saving entity with Id - {0}", entity.Id);
            return _genericRepository.Save<MetaEntity>(entity, entity.Id);
        }

        public TEntity FindEntity<TEntity>(int id) where TEntity : class
        {
            _logger.Trace("Fetching entity with Id - {0}", id);
            return _genericRepository.GetById<TEntity>(id);
        }

        #endregion IWorker Interface Implementation
    }
}

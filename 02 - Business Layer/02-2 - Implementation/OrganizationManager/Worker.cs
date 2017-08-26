using ADS.BankingAnalytics.DataEntities.ObjectModel;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities.ExpandableEntityFactory;
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

        private IExpandableEntityCreator _expansionCreator;

        #endregion Fields

        #region Constructor

        public Worker(IGenericRepositoryActivity genericRepository, ILogger logger, IExpandableEntityCreator expansionCreator)
        {
            _genericRepository = genericRepository;
            _logger = logger;
            _expansionCreator = expansionCreator;
        }

        #endregion Constructor

        #region IWorker Interface Implementation

        public List<Organization> GetAllOrganizations()
        {
            List<Organization> retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'GetAllOrganizations'");

                retVal = _genericRepository.GetAll<Organization>().ToList();
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                retVal = null;
            }

            _logger.Debug("Method 'GetAllOrganizations' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            
            return retVal;
        }

        public List<Unit> GetUnits(int organizationId)
        {
            List<Unit> retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'GetUnits'");
                _logger.Trace("Parameter: organizationId - {0}", organizationId);

                retVal = _genericRepository.GetByCriteria<Unit>(
                    it => it.OrganizationId == organizationId
                    ).ToList();
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                retVal = null;
            }

            _logger.Debug("Method 'GetUnits' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            
            return retVal;
        }

        public MetaEntity Save(MetaEntity entity)
        {
            _logger.Trace("Saving entity with Id - {0}", entity.Id);
            return _genericRepository.Save<MetaEntity>(entity, entity.Id);
        }

        public Unit FindUnit(int id)
        {
            Unit retVal = null;

            try
            {
                _logger.Trace("Fetching unit with Id - {0}", id);
                retVal = _genericRepository.GetById<Unit>(id);
                retVal = (Unit) _expansionCreator.Expand(retVal);
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                throw;
            }

            return retVal;
        }

        public ExpandableEntity SaveExp(ExpandableEntity entity)
        {
            ExpandableEntity retVal;

            try
            {
                retVal = _genericRepository.Save<ExpandableEntity>(entity, entity.Id);

                // Save inner collections
                foreach(var fieldDefinition in entity.AdditionalFieldDefinitions)
                {
                    _genericRepository.Save<AdditionalFieldDefinition>(fieldDefinition);
                }

                foreach (var field in entity.AdditionalFields)
                {
                    _genericRepository.Save<AdditionalField>(field);
                }
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                retVal = null;
            }

            return retVal;
        }

        #endregion IWorker Interface Implementation
    }
}

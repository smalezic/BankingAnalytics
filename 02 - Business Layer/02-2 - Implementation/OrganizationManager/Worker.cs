using ADS.BankingAnalytics.DataEntities.ObjectModel;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities.ExpandableEntityFactory;
using ADS.BankingAnalytics.Logging.LoggingInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;

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

        public bool SaveUnits(List<Unit> units)
        {
            bool retVal = true;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'SaveCollectionOfSimpleEntities'");

                units.ForEach(it =>
                {
                    SaveUnit(it);
                });
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                retVal = false;
            }

            _logger.Debug("Method 'SaveCollectionOfSimpleEntities' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
        }

        public Unit SaveUnit(Unit unit)
        {
            Unit retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'SaveUnit'");

                if(unit.ParentUnit != null)
                {
                    var parentUnit = SaveUnit(unit.ParentUnit);
                    unit.ParentUnitId = parentUnit.Id;
                }

                // Check if a unit in the same organization and with the same name already exists
                var unitDb = _genericRepository.GetByCriteria<Unit>(
                        it => it.OrganizationId == unit.OrganizationId
                            && it.Name.ToLower().Trim() == unit.Name.ToLower().Trim()
                    )
                    .FirstOrDefault();

                if(unitDb == null)
                {
                    unitDb = new Unit();
                }

                // Update the existing entity or create the new one with the data from the passed entity
                unitDb.InjectFrom<PrimitiveTypesExcludeId>(unit);
                
                // Save the entity
                retVal = (Unit)SaveSimpleEntity(unitDb);
            }
            catch (Exception exc)
            {
                retVal = null;
                _logger.Error(exc);
            }

            _logger.Debug("Method 'SaveUnit' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
        }

        public MetaEntity SaveSimpleEntity(MetaEntity entity)
        {
            MetaEntity retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'SaveSimpleEntity'");

                _logger.Trace("Saving entity with Id - {0}", entity.Id);
                retVal = _genericRepository.Save<MetaEntity>(entity, entity.Id);

            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                retVal = null;
            }

            _logger.Debug("Method 'SaveSimpleEntity' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
        }

        public ExpandableEntity SaveExpandableEntity(ExpandableEntity entity)
        {
            ExpandableEntity retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'SaveExpandableEntity'");

                retVal = _genericRepository.Save<ExpandableEntity>(entity, entity.Id);

                // Save inner collections
                foreach (var fieldDefinition in entity.ExpandableEntityType.AdditionalFieldDefinitions)
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

            _logger.Debug("Method 'SaveExpandableEntity' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
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

        #endregion IWorker Interface Implementation
    }
}

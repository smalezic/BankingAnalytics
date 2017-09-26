using ADS.BankingAnalytics.DataEntities.ObjectModel;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities;
using ADS.BankingAnalytics.DataEntities.RepositoryActivities.ExpandableEntityFactory;
using ADS.BankingAnalytics.Logging.LoggingInterface;
using ADS.BankingAnalytics.HelperObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using System.IO;
using ADS.BankingAnalytics.Utility.FileUtility;
using System.Data;

namespace ADS.BankingAnalytics.Business.OrganizationManager
{
    public class Worker : IWorker
    {
        #region Fields

        private IGenericRepositoryActivity _genericRepository;
        private readonly ILogger _logger;
        private IExpandableEntityCreator _expansionCreator;
        private IExcelFileTool _excelFileTool;

        #endregion Fields

        #region Constructor

        public Worker(
            IGenericRepositoryActivity genericRepository,
            ILogger logger,
            IExpandableEntityCreator expansionCreator,
            IExcelFileTool excelFileTool)
        {
            _genericRepository = genericRepository;
            _logger = logger;
            _expansionCreator = expansionCreator;
            _excelFileTool = excelFileTool;
        }

        #endregion Constructor

        #region IWorker Interface Implementation

        #region Organization & Unit

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

        public Unit FindUnit(int id)
        {
            Unit retVal = null;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'FindUnit'");
                _logger.Info("Fetching unit with Id - {0}", id);

                retVal = _genericRepository.GetById<Unit>(id);
                retVal = (Unit)_expansionCreator.Expand(retVal);
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                throw;
            }

            _logger.Debug("Method 'FindUnit' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
        }

        public List<Unit> GetUnits(int organizationId)
        {
            List<Unit> retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'GetUnits'");
                _logger.Info("Parameter: organizationId - {0}", organizationId);

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
                _logger.Debug("Entered method 'SaveUnits'");

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

            _logger.Debug("Method 'SaveUnits' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
        }

        public Unit SaveUnit(Unit unit)
        {
            Unit retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'SaveUnit'");

                if (unit.ParentUnit != null)
                {
                    var parentUnit = SaveUnit(unit.ParentUnit);
                    unit.ParentUnitId = parentUnit.Id;
                }

                Unit unitDb;

                // Check if a unit in the same organization and with the same name already exists
                unitDb = _genericRepository.GetByCriteria<Unit>(
                        it => it.OrganizationId == unit.OrganizationId
                            && it.Name.ToLower().Trim() == unit.Name.ToLower().Trim()
                    )
                    .FirstOrDefault();

                if (unitDb == null)
                {
                    unitDb = new Unit();
                }

                // Update the existing entity or create the new one with the data from the passed entity
                unitDb.InjectFrom<PrimitiveTypesExcludeId>(unit);

                // Save the entity
                retVal = (Unit)SaveSimpleEntity(unitDb);

                ((ExpandableEntity)unit.Expansion).MetaEntityId = retVal.Id;
                ((ExpandableEntity)unit.Expansion).MetaEntityType = retVal.TypeName;

                SaveExpandableEntity((ExpandableEntity)unit.Expansion);
            }
            catch (Exception exc)
            {
                retVal = null;
                _logger.Error(exc);
            }

            _logger.Debug("Method 'SaveUnit' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
        }

        public List<UnitCategory> GetUnitCategories(int organizationId)
        {
            List<UnitCategory> retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'GetUnitCategories'");
                _logger.Info("Parameter: organizationId - {0}", organizationId);

                retVal = _genericRepository.GetAll<UnitCategory>(it => it.OrganizationId == organizationId).ToList();
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                retVal = null;
            }

            _logger.Debug("Method 'GetUnitCategories' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);

            return retVal;
        }

        #endregion Organization & Unit

        #region KPI Operations

        public bool SaveWorkbook(Workbook workbook)
        {
            bool retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'SaveWorkbook'");

                Workbook workbookDb;

                // Check if a unit in the same organization and with the same name already exists
                workbookDb = _genericRepository.GetByCriteria<Workbook>(
                        it => it.UnitId == workbook.UnitId
                            && it.Name.ToLower().Trim() == workbook.Name.ToLower().Trim()
                    )
                    .FirstOrDefault();

                if (workbookDb == null)
                {
                    workbookDb = new Workbook();
                }

                // Update the existing entity or create the new one with the data from the passed entity
                workbookDb.InjectFrom<PrimitiveTypesExcludeId>(workbook);

                // Save the entity
                var savedWorkbook = (Workbook)SaveSimpleEntity(workbookDb);

                ((ExpandableEntity)workbook.Expansion).MetaEntityId = savedWorkbook.Id;
                ((ExpandableEntity)workbook.Expansion).MetaEntityType = savedWorkbook.TypeName;

                SaveExpandableEntity((ExpandableEntity)workbook.Expansion);

                retVal = true;
            }
            catch (Exception exc)
            {
                retVal = false;
                _logger.Error(exc);
            }

            _logger.Debug("Method 'SaveWorkbook' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
        }

        public bool UploadFile(WorkbookTransport transport)
        {
            bool retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'UploadFile'");

                var workbook = transport.Workbook;
                var dt = _excelFileTool.GetFileContent(transport.Content);

                var workbookTemplate = _genericRepository.GetById<WorkbookTemplate>(workbook.WorkbookTemplateId.Value);
                workbookTemplate = (WorkbookTemplate) _expansionCreator.ExpandType(workbookTemplate);

                IList<AdditionalFieldDefinition> additionalFieldDefinitions = null;
                if(workbookTemplate.Expansion != null)
                {
                    var expandableType = (ExpandableEntityType)workbookTemplate.Expansion;
                    additionalFieldDefinitions = expandableType.AdditionalFieldDefinitions.ToList();
                }
                else
                {
                    // TODO: Do proper handling here!
                    throw new NullReferenceException();
                }

                List<AdditionalField> addFields = new List<AdditionalField>(additionalFieldDefinitions.Count());
                
                // TODO: Process the content of the excel file
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr != null && dr.ItemArray != null && dr.ItemArray.Length > 2)
                    {
                        var name = dr[0].GetType() != typeof(System.DBNull) ? (String) dr[0] : String.Empty; // name of the data
                        var description = dr[1].GetType() != typeof(System.DBNull) ? (String) dr[1] : String.Empty; // description
                        var val = dr[2].GetType() != typeof(System.DBNull) ? (String) dr[2] : String.Empty; // value for processing

                        if(String.IsNullOrWhiteSpace(val))
                        {
                            continue;
                        }

                        // Find the field in WorkbookTemplate
                        var addFieldDef = additionalFieldDefinitions
                            .Where(it => it.Name == name)
                            .FirstOrDefault();

                        var addField = new AdditionalField()
                        {
                            StringValue = val,
                            AdditionalFieldDefinitionId = addFieldDef.Id
                        };

                        addFields.Add(addField);
                    }
                }
                
                //var expandable = new ExpandableEntity()
                //{
                //    MetaEntityId = workbook.Id,
                //    MetaEntityType = workbook.TypeName,
                //    AdditionalFields = addFields
                //};

                var expandable = new ExpandableEntity();

                addFields.ForEach(it =>
                {
                    expandable.AdditionalFields.Add(it);
                });
                
                workbook.Expansion = expandable;

                SaveWorkbook(workbook);









                retVal = true;
            }
            catch (Exception exc)
            {
                retVal = false;
                _logger.Error(exc);
            }

            _logger.Debug("Method 'UploadFile' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
        }

        #endregion KPI Operations

        #region Additional Fields

        public List<AdditionalFieldDefinition> GetAdditionalFieldDefinitions(int unitCategoryId)
        {
            List<AdditionalFieldDefinition> retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'GetAdditionalFieldDefinitions'");
                _logger.Info("Parameter: unitCategoryId - {0}", unitCategoryId);

                retVal = _genericRepository.GetByCriteria<AdditionalFieldDefinition>(
                    it =>
                        it.ExpandableEntityTypeId == unitCategoryId
                        && it.DeletedAt == null
                    ).ToList();
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                retVal = null;
            }

            _logger.Debug("Method 'GetAdditionalFieldDefinitions' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);

            return retVal;
        }

        //public bool SaveAdditionalFieldDefinitions(MetaEntity metaEntity, List<AdditionalFieldDefinition> additionalFieldDefinitions)
        public bool SaveAdditionalFieldDefinitions(ExpandableEntityType expandableEntityType)
        {
            bool retVal = true;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'SaveAdditionalFieldDefinitions'");

                var expandableEntityTypeFromDB = _genericRepository.GetByCriteria<ExpandableEntityType>(
                    it =>
                        it.Id == expandableEntityType.MetaEntityId
                        && it.MetaEntityType == expandableEntityType.MetaEntityType
                    )
                    .FirstOrDefault();

                if(expandableEntityTypeFromDB == null)
                {
                    expandableEntityTypeFromDB = new ExpandableEntityType()
                    {
                        MetaEntityId = expandableEntityType.MetaEntityId,
                        MetaEntityType = expandableEntityType.MetaEntityType
                    };
                }

                var savedExpandableEntityType = _genericRepository.Save<ExpandableEntityType>(expandableEntityTypeFromDB);

                expandableEntityType.AdditionalFieldDefinitions.ToList().ForEach(it =>
                {
                    it.ExpandableEntityTypeId = savedExpandableEntityType.Id;
                    SaveSimpleEntity<AdditionalFieldDefinition>(it);
                });
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                retVal = false;
            }

            _logger.Debug("Method 'SaveAdditionalFieldDefinitions' has been completed in {0}ms", (DateTime.Now - startTime).TotalMilliseconds);
            return retVal;
        }

        #endregion Additional Fields

        #region Common Methods

        public TEntity SaveSimpleEntity<TEntity>(TEntity entity) where TEntity : MetaEntity
        {
            TEntity retVal;
            var startTime = DateTime.Now;

            try
            {
                _logger.Debug("Entered method 'SaveSimpleEntity'");
                _logger.Info("Saving entity with Id - {0}", entity.Id);

                retVal = _genericRepository.Save<TEntity>(entity, entity.Id);
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
                //foreach (var fieldDefinition in entity.AdditionalFieldDefinitions)
                //{
                //    _genericRepository.Save<AdditionalFieldDefinition>(fieldDefinition);
                //}

                foreach (var field in entity.AdditionalFields)
                {
                    field.ExpandableEntityId = retVal.Id;
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

        #endregion Common Methods

        #endregion IWorker Interface Implementation
    }
}

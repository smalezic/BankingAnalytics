using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.BankingAnalytics.DataEntities.ObjectModel;

namespace ADS.BankingAnalytics.Business.OrganizationManager
{
    public interface IWorker
    {
        #region Organization & Unit

        List<Organization> GetAllOrganizations();
        Unit FindUnit(int id);
        List<Unit> GetUnits(int organizationId);
        bool SaveUnits(List<Unit> entities);
        Unit SaveUnit(Unit unit);
        List<UnitCategory> GetUnitCategories(int organizationId);

        #endregion Organization & Unit

        #region KPI Operations

        bool SaveWorkbook(Workbook workbook);
        bool UploadFile(byte[] content);

        #endregion KPI Operations

        #region Additional Fields

        List<AdditionalFieldDefinition> GetAdditionalFieldDefinitions(int unitCategoryId);
        bool SaveAdditionalFieldDefinitions(ExpandableEntityType expandableEntityType);

        #endregion Additional Fields

        #region Common Methods

        TEntity SaveSimpleEntity<TEntity>(TEntity entity) where TEntity : MetaEntity;
        ExpandableEntity SaveExpandableEntity(ExpandableEntity entity);

        #endregion Common Methods
    }
}

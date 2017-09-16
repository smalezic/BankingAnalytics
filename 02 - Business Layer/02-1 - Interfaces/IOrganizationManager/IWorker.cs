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
        List<UnitCategory> GetAllUnitCategories();

        #endregion Organization & Unit

        #region Additional Fields

        List<AdditionalFieldDefinition> GetAdditionalFieldDefinitions(int unitCategoryId);
        bool SaveAdditionalFieldDefinitions(List<AdditionalFieldDefinition> additionalFieldDefinitions);

        #endregion Additional Fields

        #region Common Methods

        MetaEntity SaveSimpleEntity(MetaEntity entity);
        ExpandableEntity SaveExpandableEntity(ExpandableEntity entity);

        #endregion Common Methods
    }
}

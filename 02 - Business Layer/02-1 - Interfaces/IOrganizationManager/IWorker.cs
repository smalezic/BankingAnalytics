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
        List<Organization> GetAllOrganizations();
        List<UnitCategory> GetAllUnitCategories();
        List<Unit> GetUnits(int organizationId);

        bool SaveUnits(List<Unit> entities);

        MetaEntity SaveSimpleEntity(MetaEntity entity);
        ExpandableEntity SaveExpandableEntity(ExpandableEntity entity);

        Unit FindUnit(int id);
    }
}

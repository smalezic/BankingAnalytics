using ADS.BankingAnalytics.DataEntities.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.RepositoryActivities.ExpandableEntityFactory
{
    public class ExpandableEntityCreator: IExpandableEntityCreator
    {
        #region Fields

        private IGenericRepositoryActivity _genericRepository;

        #endregion Fields

        #region Constructor

        public ExpandableEntityCreator(IGenericRepositoryActivity genericRepository)
        {
            _genericRepository = genericRepository;
        }

        #endregion Constructor

        public MetaEntity Expand(MetaEntity entity)
        {
            //entity.Expansion = _genericRepository.GetByCriteria<ExpandableEntity>(
            //        it =>
            //            it.MetaEntityId == entity.Id
            //            && it.MetaEntityType == entity.TypeName,
            //        it => it.ExpandableEntityType.AdditionalFieldDefinitions,
            //        it => it.AdditionalFields
            //    )
            //    .FirstOrDefault();

            //return entity;

            return null;
        }
    }
}

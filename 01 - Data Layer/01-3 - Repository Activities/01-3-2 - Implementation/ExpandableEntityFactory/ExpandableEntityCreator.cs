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
            //        it => it.AdditionalFields
            //    )
            //    .FirstOrDefault();

            //return entity;

            entity.Expansion = _genericRepository.GetAdditionalFields(entity);
            return entity;
        }

        public MetaEntity ExpandType(MetaEntity entity)
        {
            entity.Expansion = _genericRepository.GetByCriteria<ExpandableEntityType>(
                    it =>
                        it.MetaEntityId == entity.Id
                        && it.MetaEntityType == entity.TypeName,
                    it => it.AdditionalFieldDefinitions
                )
                .FirstOrDefault();

            return entity;
        }
    }
}

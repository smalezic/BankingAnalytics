using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ADS.BankingAnalytics.DataEntities.RepositoryActivities
{
    public interface IGenericRepositoryActivity
    {
        #region Fetch

        TEntity GetById<TEntity>(object[] pk, params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>(params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class;
        TEntity GetById<TEntity>(int id) where TEntity : class;
        IEnumerable<TEntity> GetByCriteria<TEntity>(
            Expression<Func<TEntity, bool>> criteria,
            params Expression<Func<TEntity, object>>[] includeStatements
            ) where TEntity : class;
        IEnumerable<TEntity> GetJoinnedWithCriteria<TEntity, K>(Func<TEntity, bool> criteria) where TEntity : class where K : class;

        #endregion Fetch

        #region Insert & Update

        TEntity Save<TEntity>(TEntity entity, params object[] pk) where TEntity : class;

        #endregion Insert & Update
    }
}

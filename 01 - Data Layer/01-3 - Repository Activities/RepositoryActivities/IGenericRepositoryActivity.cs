using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ADS.BankingAnalytics.DataEntities.RepositoryActivities
{
    public interface IGenericRepositoryActivity
    {
        #region Fetch

        T GetById<T>(object[] pk, params Expression<Func<T, object>>[] includeExpressions) where T : class;
        IQueryable<T> GetAll<T>(params Expression<Func<T, object>>[] includeExpressions) where T : class;
        IEnumerable<T> GetByCriteria<T>(
            Expression<Func<T, bool>> criteria,
            params Expression<Func<T, object>>[] includeStatements
            ) where T : class;
        IEnumerable<T> GetJoinnedWithCriteria<T, K>(Func<T, bool> criteria) where T : class where K : class;

        #endregion Fetch

        #region Insert & Update

        T Save<T>(T entity, params object[] pk) where T : class;

        #endregion Insert & Update
    }
}

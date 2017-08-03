using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ADS.BankingAnalytics.DataEntities.RepositoryActivities
{
    public interface IGenericRepositoryActivity
    {
        #region Fetching Data

        /// <summary>
        /// Fetching a entity and related ones based on includeExpressions
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="pk"></param>
        /// <param name="includeExpressions"></param>
        /// <returns></returns>
        TEntity GetById<TEntity>(object[] pk, params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class;

        /// <summary>
        /// Fethcing a antity by Id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById<TEntity>(int id) where TEntity : class;

        /// <summary>
        /// Fetching all entities of a type and related ones based on includeExpressions
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="includeExpressions"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAll<TEntity>
            (
                params Expression<Func<TEntity, object>>[] includeExpressions
            ) where TEntity : class;

        /// <summary>
        /// Fetching entities of a type and related ones by criteria
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criteria"></param>
        /// <param name="includeStatements"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetByCriteria<TEntity>
            (
                Expression<Func<TEntity, bool>> criteria,
                params Expression<Func<TEntity, object>>[] includeStatements
            ) where TEntity : class;

        /// <summary>
        /// Joins two types of entities and fetching the result data based on criteria
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetJoinnedWithCriteria<TEntity, KEntity>(Func<TEntity, bool> criteria) where TEntity : class where KEntity : class;

        #endregion Fetching Data

        #region Saving changes

        /// <summary>
        /// Saving the changes in a entity: insert, update and delete
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        TEntity Save<TEntity>(TEntity entity, params object[] pk) where TEntity : class;

        #endregion Saving changes
    }
}

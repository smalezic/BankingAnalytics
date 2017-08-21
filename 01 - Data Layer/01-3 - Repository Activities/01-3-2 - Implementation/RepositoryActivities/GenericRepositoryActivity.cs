using ADS.BankingAnalytics.DataEntities.RepositoryActivities.ContextFactory;
using ADS.BankingAnalytics.Logging.LoggingInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ADS.BankingAnalytics.DataEntities.RepositoryActivities
{
    public class GenericRepositoryActivity : IGenericRepositoryActivity
    {
        #region Fields

        // Instance of DbContext
        private DbContext _context;

        // Instance of ILogger
        private readonly ILogger _logger;

        #endregion Fields

        #region Constructors

        public GenericRepositoryActivity(IFactory contextFactory, ILogger logger)
        {
            _context = contextFactory.Context;
            _logger = logger;
        }

        #endregion Constructors

        #region IGenericRepositoryActivity Interface Implementation

        #region Fetching Data

        /// <summary>
        /// Fetching a entity and related ones based on includeExpressions
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="pk"></param>
        /// <param name="includeExpressions"></param>
        /// <returns></returns>
        public TEntity GetById<TEntity>(object[] pk, params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class
        {
            return _context.Set<TEntity>().Find(pk);
        }

        /// <summary>
        /// Fethcing a antity by Id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById<TEntity>(int id) where TEntity : class
        {
            _logger.Trace("Find entity by Id - {0}", id);
            return _context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Fetching all entities of a type and related ones based on includeExpressions
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="includeExpressions"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll<TEntity>(params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class
        {
            var retVal = _context.Set<TEntity>();

            if (includeExpressions.Any())
            {
                var set = includeExpressions
                  .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                    (retVal, (current, expression) => current.Include(expression));
            }

            return retVal;
        }

        /// <summary>
        /// Fetching entities of a type and related ones by criteria
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criteria"></param>
        /// <param name="includeStatements"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetByCriteria<TEntity>(
            Expression<Func<TEntity, bool>> criteria,
            params Expression<Func<TEntity, object>>[] includeStatements
            ) where TEntity : class
        {
            IQueryable<TEntity> retVal = _context.Set<TEntity>();

            if (criteria != null)
            {
                retVal = retVal.Where(criteria);
            }

            foreach (var includeStatement in includeStatements)
            {
                retVal = retVal.Include(includeStatement);
            }

            return retVal;
        }

        /// <summary>
        /// Joins two types of entities and fetching the result data based on criteria
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="KEntity"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetJoinnedWithCriteria<TEntity, KEntity>(Func<TEntity, bool> criteria) where TEntity : class where KEntity : class
        {
            throw new NotImplementedException();

            //return context.Sellings
            //        .Join(context.Actions,
            //            selling => selling.Id,
            //            action => action.Id,
            //            (selling, action) => new { Selling = selling, Action = action }
            //        );
        }

        #endregion Fetching Data

        #region Saving changes

        /// <summary>
        /// Saving the changes in a entity: insert, update and delete
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        public TEntity Save<TEntity>(TEntity entity, params object[] pk) where TEntity : class
        {
            var entry = _context.Entry<TEntity>(entity);

            switch (entry.State)
            {
                case EntityState.Added:
                    // Leave it as it is
                    break;

                case EntityState.Deleted:
                    // It's not to be deleted after all
                    entry.State = EntityState.Modified;
                    break;

                case EntityState.Detached:
                    // Let's see if it really exists in Db
                    TEntity foundEntity = null;
                    if (pk != null && pk.Length > 0)
                    {
                        // Ako je pk tipa int proveriti da li je razlicito od 0, ukoliko nije int ulazi u blok
                        if (pk.Any(it => it != null && (it.GetType() == typeof(int) && ((int)it) > 0) || (it.GetType() != typeof(int))))
                        {
                            foundEntity = _context.Set<TEntity>().Find(pk);
                        }
                    }
                    if (foundEntity == null)
                    {
                        entry.State = EntityState.Added;
                    }
                    else
                    {
                        entry = _context.Entry(foundEntity);
                        entry.CurrentValues.SetValues(entity);
                        entry.State = EntityState.Modified;
                    }
                    break;

                case EntityState.Modified:
                    // Leave it as it is
                    break;

                case EntityState.Unchanged:
                    // Leave it as it is
                    break;

                default:
                    break;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException enValEx)
            {
                //TODO: Do proper logging of DbContext exception!

                //_logger.FatalFormat("Saving an entry of type '{0}' has failed because of entity validation.", typeof(TEntity).FullName);
                //_logger.FatalFormat("Error (StackTrace) - {0}", enValEx.StackTrace);
                //_logger.FatalFormat("Error (InnerException) - {0}", enValEx.InnerException);
                //_logger.FatalFormat("Error (Message) - {0}", enValEx.Message);

                throw enValEx;
            }
            catch (Exception exc)
            {
                //_logger.FatalFormat("Error (StackTrace) - {0}", exc.StackTrace);
                //_logger.FatalFormat("Error (InnerException) - {0}", exc.InnerException);
                //_logger.FatalFormat("Error (Message) - {0}", exc.Message);

                throw exc;
            }

            return entry.Entity;
        }

        #endregion Saving changes

        #endregion Interface Implementation

        #region Private Methods



        #endregion Private Methods
    }
}

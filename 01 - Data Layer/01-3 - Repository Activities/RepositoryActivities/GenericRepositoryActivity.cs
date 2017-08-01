using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ADS.BankingAnalytics.DataEntities.DataBroker;

namespace ADS.BankingAnalytics.DataEntities.RepositoryActivities
{
    public class GenericRepositoryActivity : IGenericRepositoryActivity
    {
        #region Fields

        //private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private OrganizationalStructureDbContext _context;

        #endregion Fields

        #region Constructors

        public GenericRepositoryActivity()
        {
            _context = new OrganizationalStructureDbContext();
        }

        #endregion Constructors

        #region Interface Implementation

        public TEntity GetById<TEntity>(object[] pk, params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class
        {
            return _context.Set<TEntity>().Find(pk);
        }

        public TEntity GetById<TEntity>(int id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

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

        public IEnumerable<TEntity> GetJoinnedWithCriteria<TEntity, K>(Func<TEntity, bool> criteria) where TEntity : class where K : class
        {
            throw new NotImplementedException();

            //return context.Sellings
            //        .Join(context.Actions,
            //            selling => selling.Id,
            //            action => action.Id,
            //            (selling, action) => new { Selling = selling, Action = action }
            //        );
        }

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
            //catch (System.Data.Entity.Validation.DbEntityValidationException enValEx)
            catch (Microsoft.EntityFrameworkCore.DbUpdateException enValEx)
            {
                //TODO: Do proper logging of DbContext exception!

                //_logger.FatalFormat("Saving an entry of type '{0}' has failed because of entity validation.", typeof(TEntity).FullName);
                //_logger.FatalFormat("Error (StackTrace) - {0}", enValEx.StackTrace);
                //_logger.FatalFormat("Error (InnerException) - {0}", enValEx.InnerException);
                //_logger.FatalFormat("Error (Message) - {0}", enValEx.Message);

                throw enValEx;
            }
            catch (Exception exc) // for debugging
            {
                //_logger.FatalFormat("Error (StackTrace) - {0}", exc.StackTrace);
                //_logger.FatalFormat("Error (InnerException) - {0}", exc.InnerException);
                //_logger.FatalFormat("Error (Message) - {0}", exc.Message);

                throw exc;
            }

            return entry.Entity;
        }

        #endregion Interface Implementation

        #region Private Methods



        #endregion Private Methods
    }
}

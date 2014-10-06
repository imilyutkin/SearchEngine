using System;
using System.Linq;
using MilyutkinI.Repository.Contracts;

namespace MilyutkinI.Repository
{
    /// <summary>
    /// Represents BaseRepository class
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected BaseRepository(ISourceContext sourceContext)
        {
            SourceContext = sourceContext;
        }

        /// <summary>
        /// Gets the sourceContext.
        /// </summary>
        /// <value>
        /// sourceContext to work with db.
        /// </value>
        protected ISourceContext SourceContext
        {
            get;
            set;
        }

        /// <summary>
        /// Saves entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TEntity Save(TEntity entity)
        {
            return SourceContext.Save(entity) as TEntity;
        }

        /// <summary>
        /// Loads the entity by id.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TEntity Load(TEntity entity)
        {
            return SourceContext.Load<TEntity>(entity.Id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            return SourceContext.Update(entity);
         }

        /// <summary>
        /// Deletes entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TEntity entity)
        {
            SourceContext.Delete(entity);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return SourceContext.GetAll<TEntity>();
        }

        /// <summary>
        /// Gets entities by query.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <returns></returns>
        public IQueryable<TEntity> GetBy(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public abstract void Dispose();
    }
}

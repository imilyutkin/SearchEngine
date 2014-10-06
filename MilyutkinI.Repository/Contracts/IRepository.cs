using System;
using System.Linq;

namespace MilyutkinI.Repository.Contracts
{
    /// <summary>
    /// Represents interface to repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> : IDisposable
    {
        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TEntity Save(TEntity entity);

        /// <summary>
        /// Loads the entity by id.
        /// </summary>
        /// <returns></returns>
        TEntity Load(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Deletes entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Gets entities by query.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <returns></returns>
        IQueryable<TEntity> GetBy(Func<TEntity, bool> predicate);
    }
}

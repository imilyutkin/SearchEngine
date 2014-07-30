using System;
using System.Linq;

namespace MilyutkinI.Repository.Contracts
{
    /// <summary>
    /// Interface to Context IContext
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        IEntity Save(IEntity entity);

        /// <summary>
        /// Loads entity by id.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        TSet Load<TSet>(int id) where TSet : class, IEntity;

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TSet Update<TSet>(TSet entity) where TSet : class, IEntity;

        /// <summary>
        /// Deletes specified entity.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <param name="entity">The entity.</param>n
        void Delete<TSet>(TSet entity) where TSet : class, IEntity;

        /// <summary>
        /// Gets all entites.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <returns></returns>
        IQueryable<TSet> GetAll<TSet>() where TSet : class, IEntity;

        /// <summary>
        /// Gets the by query.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        IQueryable<TSet> GetByQuery<TSet>(Func<TSet, Boolean> predicate) where TSet : class, IEntity;
    }
}

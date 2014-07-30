using System;
using System.Data.Entity;
using System.Linq;
using MilyutkinI.Repository.Contracts;
using SearchEngine.DomainModels.Extensions;
using SearchEngine.DomainModels.Models;

namespace SearchEngine.DomainModels.Context
{
    public class SearchEngineSourceContext : DbContext, ISourceContext
    {
        public SearchEngineSourceContext() : base("DefaultConnection")
        {
        }

        public DbSet<Url> Urls
        {
            get;
            set;
        }

        public DbSet<UrlLink> Links
        {
            get;
            set;
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public IEntity Save(IEntity entity)
        {
            var savedEntity = (IEntity)Set(entity.GetType()).Add(entity);
            SaveChanges();
            return savedEntity;
        }

        /// <summary>
        /// Loads the entity by id.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        TSet ISourceContext.Load<TSet>(int id)
        {
            return Set<TSet>().Find(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TSet Update<TSet>(TSet entity) where TSet : class, IEntity
        {
            var oldEntity = ((ISourceContext)this).Load<TSet>(entity.Id);
            Entry(oldEntity).CurrentValues.SetValues(entity);
            SaveChanges();
            return entity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<TSet>(TSet entity) where TSet : class, IEntity
        {
            Set<TSet>().Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <returns></returns>
        public IQueryable<TSet> GetAll<TSet>() where TSet : class, IEntity
        {
            return Set<TSet>().AsQueryable();
        }

        /// <summary>
        /// Gets the by query.
        /// </summary>
        /// <typeparam name="TSet">The type of the set.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IQueryable<TSet> GetByQuery<TSet>(Func<TSet, bool> predicate) where TSet : class, IEntity
        {
            return Set<TSet>().FindPredicate(predicate);
        }
    }
}

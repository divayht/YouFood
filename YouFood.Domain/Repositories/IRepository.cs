using System;
using System.Linq;
using System.Linq.Expressions;

namespace YouFood.Domain.Repositories
{
    public interface IRepository<TEntity, TId>
    {
        /// <summary>
        /// Get all the entities stored in this repository
        /// </summary>
        /// <returns>All the entities in this repository</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get the single entity with the associated id.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The entity or null</returns>
        TEntity Get(TId id);

        /// <summary>
        /// Get the single entity with the associated id.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>The entity or null</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add a new entity in this repository.
        /// </summary>
        /// <param name="entity">The entity to add</param>
        void Add(TEntity entity);

        /// <summary>
        /// Save changes in the repository.
        /// </summary>
        void SaveOrUpdate();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true if the entity is successfully deleted, otherwise false</returns>
        void Delete(TEntity entity);

        //void Update(TEntity entity);
    }
}

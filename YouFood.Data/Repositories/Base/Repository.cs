using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

using YouFood.Domain.Repositories;
using YouFood.Domain.Model.Base;

namespace YouFood.Data.Repositories.Base
{
    public abstract class Repository<TEntity, TId, TContext> : BaseRepository<TContext>, IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : IComparable<TId>
        where TContext : DbContext
    {
        public DbSet<TEntity> Entity { get; set; }

        public IQueryable<TEntity> GetAll()
        {
            return Entity;
        }

        public TEntity Get(TId id)
        {
            return Entity.Where(e => e.Id.CompareTo(id) == 0).FirstOrDefault();
        }

        public IQueryable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return this.Entity.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            this.Entity.Add(entity);
        }

        public void SaveOrUpdate()
        {
            try
            {
                base.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception("Playtem fatal error while saving data");
            }
        }

        public void Update(TEntity entity)
        {
            this.Entity.Attach(entity);
            SaveOrUpdate();
        }

        public void Delete(TEntity entity)
        {
            this.Entity.Remove(entity);
            SaveOrUpdate();
        }
    }
}

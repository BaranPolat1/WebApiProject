using Core.Entity;
using Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Repository.Concrete
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity:class where TContext:DbContext,new()
    {
        public void Add(TEntity item)
        {
            using(var db = new TContext())
            {
               var addedEntity = db.Entry(item);
                addedEntity.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> exp)
        {
            using (var db = new TContext())
            {
                return db.Set<TEntity>().Any(exp);
            }
        }

        public void Delete(TEntity item)
        {
            using (var db = new TContext())
            {
                var deletedEntity = db.Entry(item);
                deletedEntity.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

       

        public TEntity Get(Expression<Func<TEntity, bool>> exp)
        {
            using (var db = new TContext())
            {
                return db.Set<TEntity>().FirstOrDefault(exp);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> exp = null)
        {
            using (var db = new TContext())
            {
                return exp == null ? db.Set<TEntity>().ToList() : db.Set<TEntity>().Where(exp).ToList();
            }
        }

        public void Update(TEntity item)
        {
            using (var db = new TContext())
            {
                var updatedEntity = db.Entry(item);
                updatedEntity.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}

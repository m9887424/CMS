using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL.Interface;
using CMS.Domain;
using System.Data.Entity;
using System.Linq.Expressions;
// 需先至 NuGet 安裝 EntityFramework

namespace CMS.DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal NorthwindEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            context = new NorthwindEntities();
            dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            //dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }
        
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            if(predicate != null)
                return dbSet.AsQueryable().Where(predicate);
            else
                return dbSet.AsQueryable();
        }
        public TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
    }
}

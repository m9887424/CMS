using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CMS.DAL.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        TEntity GetByID(object id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
    }
}

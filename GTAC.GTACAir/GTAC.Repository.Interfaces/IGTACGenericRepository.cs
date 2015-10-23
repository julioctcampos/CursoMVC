using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.Repository.Interfaces
{
    public interface IGTACGenericRepository<TEntity, TKey>
        where TEntity : class
    {
        List<TEntity> SelectAll();
        TEntity SelectByKey(TKey key);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteByKey(TKey key);
    }
}
